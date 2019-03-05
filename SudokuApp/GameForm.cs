using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class GameForm : Form
    {

        // === PROMĚNNÉ ===
        public string name;
        private bool onMainThread;

        public SudokuBoard originalBoard, board;
        public Point selectedField;

        public Stack<SudokuTah> previous = new Stack<SudokuTah>();
        public Stack<SudokuTah> next = new Stack<SudokuTah>();
        // === PROMĚNNÉ ===

        // === LOAD ===
        public GameForm(bool onMainThread = false)
        {
            InitializeComponent();
            this.onMainThread = onMainThread;
        }
        private void SudokuApp_Load(object sender, EventArgs e)
        {
            //Název formuláře
            Text = "Hra - " + name;
            //Nastavení vybraného pole
            if (selectedField.X == -1 && selectedField.Y == -1)
                selectedField = board.FirstEmpty();

            for (int gridCol = 0; gridCol < 3; gridCol++)
            {
                for (int gridRow = 0; gridRow < 3; gridRow++)
                {
                    TableLayoutPanel panel = new TableLayoutPanel();
                    panel.Name = "Grid_" + gridCol + "_" + gridRow;
                    panel.RowCount = 3;
                    panel.ColumnCount = 3;

                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));

                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));

                    panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                    panel.Width = sudokuBoard.Width / 3;
                    panel.Height = sudokuBoard.Height / 3;

                    panel.CellPaint += OnCellPaint;
                    sudokuBoard.Controls.Add(panel, gridCol, gridRow);
                }
            }

            //Načtení pole z dat
            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row < 9; row++)
                {
                    Label label = new Label()
                    {
                        Name = col + "_" + row
                    };

                    int val = board.GetValue(col, row);

                    label.ForeColor = (originalBoard.GetValue(col, row) != 0) ? Color.Black : Color.Blue;
                    label.Text = val == 0 ? "" : ""+val;
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    label.Font = new Font(label.Font.FontFamily, 20);
                    label.Size = new Size(40, 40);
                    label.Click += PrekliknutiPole;

                    if (col == selectedField.X && row == selectedField.Y)
                        label.BackColor = Color.Yellow;

                    int gridCol = col / 3;
                    int gridRow = row / 3;
                    ((TableLayoutPanel) sudokuBoard.Controls["Grid_" + gridCol + "_" + gridRow]).Controls.Add(label, col % 3, row % 3);
                }
            }

            //Překreslení špatně zadaných polí
            RedrawFields(true);
        }
        private void SudokuBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), e.CellBounds);
        }
        private void OnCellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            string[] GridColRow = ((Control)sender).Name.Split('_');
            if (int.Parse(GridColRow[1]) != selectedField.X / 3 ||
                int.Parse(GridColRow[2]) != selectedField.Y / 3)
                return;

            if (selectedField.X % 3 != e.Column || selectedField.Y % 3 != e.Row)
                return;

            e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.CellBounds);
        }
        // === LOAD ===

        //Překliknutí vybraného pole
        private void PrekliknutiPole(object sender, EventArgs e)
        {
            //Zjistí staré pole
            string[] colRow = ((Label)sender).Name.Split('_');
            int col = int.Parse(colRow[0]), row = int.Parse(colRow[1]);
            
            //Nemůžeme upravovat stálé hodnoty ani překlikávat vyřešené Sudoku
            if (originalBoard.GetValue(col, row) != 0 || board.IsSolved())
                return;

            //Najde označené místo a zruší na něm označení
            GetLabelControl(selectedField.X, selectedField.Y).BackColor = Color.FromKnownColor(KnownColor.Control);
            sudokuBoard.Controls["Grid_" + selectedField.X / 3 + "_" + selectedField.Y / 3].Invalidate();

            //Nastaví nové pole
            selectedField = new Point(col, row);

            //Označí nové místo
            GetLabelControl(selectedField.X, selectedField.Y).BackColor = Color.Yellow;
            sudokuBoard.Controls["Grid_" + selectedField.X / 3 + "_" + selectedField.Y / 3].Invalidate();
        }

        // INTERNAL | Vykonání tahu
        private void VykonejTah(int col, int row, int value, bool redraw = true)
        {
            SudokuTah tah = new SudokuTah(row * 9 + col, board.GetValue(col, row), value);
            previous.Push(tah);

            GetLabelControl(col, row).Text = ("" + value).Replace("0", "");
            board.SetValue(col, row, value);

            if (redraw)
                RedrawFields();
        }
        // INTERNAL | Získání Controlu podle sloupce a řádku
        private Label GetLabelControl(int col, int row)
        {
            return (Label) sudokuBoard.Controls["Grid_" + (col / 3) + "_" + (row / 3)]
                .Controls[col + "_" + row];
        }

        //Překreslení pole
        private void RedrawFields(bool firstStart = false)
        {
            Dictionary<int, Point> used = new Dictionary<int, Point>();
            List<string> wrong = new List<string>();

            //Check sloupců
            for (int col = 0; col < 9; col++)
            {
                used.Clear();
                for (int row = 0; row < 9; row++)
                {
                    int num = board.GetValue(col, row);

                    if (num == 0)
                        continue;

                    if (used.ContainsKey(num))
                    {
                        Point usedPoint = used[num];
                        GetLabelControl(usedPoint.X, usedPoint.Y).ForeColor = Color.Red;
                        GetLabelControl(col, row).ForeColor = Color.Red;

                        wrong.Add(usedPoint.X + "_" + usedPoint.Y);
                        wrong.Add(col + "_" + row);
                    }
                    else
                    {
                        used.Add(num, new Point(col, row));

                        if (!wrong.Contains(col + "_" + row))
                            GetLabelControl(col, row).ForeColor = originalBoard.GetValue(col, row) == 0 ? Color.Blue : Color.Black;
                    }
                }
            }

            //Check řádků
            for (int row = 0; row < 9; row++)
            {
                used.Clear();
                for (int col = 0; col < 9; col++)
                {
                    int num = board.GetValue(col, row);

                    if (num == 0)
                        continue;

                    if (used.ContainsKey(num))
                    {
                        Point usedPoint = used[num];
                        GetLabelControl(usedPoint.X, usedPoint.Y).ForeColor = Color.Red;
                        GetLabelControl(col, row).ForeColor = Color.Red;

                        wrong.Add(usedPoint.X + "_" + usedPoint.Y);
                        wrong.Add(col + "_" + row);
                    }
                    else
                    {
                        used.Add(num, new Point(col, row));

                        if (!wrong.Contains(col + "_" + row))
                            GetLabelControl(col, row).ForeColor = originalBoard.GetValue(col, row) == 0 ? Color.Blue : Color.Black;
                    }
                }
            }

            //Check gridu
            for (int startCol = 0; startCol < 9; startCol += 3)
            {
                for (int startRow = 0; startRow < 9; startRow += 3)
                {
                    used.Clear();
                    for (int col = startCol; col < startCol + 3; col++)
                    {
                        for (int row = startRow; row < startRow + 3; row++)
                        {
                            int num = board.GetValue(col, row);

                            if (num == 0)
                                continue;

                            if (used.ContainsKey(num))
                            {
                                Point usedPoint = used[num];
                                GetLabelControl(usedPoint.X, usedPoint.Y).ForeColor = Color.Red;
                                GetLabelControl(col, row).ForeColor = Color.Red;

                                wrong.Add(usedPoint.X + "_" + usedPoint.Y);
                                wrong.Add(col + "_" + row);
                            }
                            else
                            {
                                used.Add(num, new Point(col, row));

                                if (!wrong.Contains(col + "_" + row))
                                    GetLabelControl(col, row).ForeColor = originalBoard.GetValue(col, row) == 0 ? Color.Blue : Color.Black;
                            }
                        }
                    }
                }
            }

            if (board.IsSolved())
            {
                if (selectedField.X != -1 && selectedField.Y != 1)
                    GetLabelControl(selectedField.X, selectedField.Y).BackColor
                        = Color.FromKnownColor(KnownColor.Control);

                selectedField = new Point(-1, -1);

                stepBack.Enabled = false;
                stepForward.Enabled = false;

                if (!firstStart)
                    MessageBox.Show("Gratulujeme! Sudoku bylo vyřešeno.");

                return;
            }

            stepBack.Enabled = previous.Count != 0;
            stepForward.Enabled = next.Count != 0;
        }

        //Vyplňování číslic do hry
        private void KlavesaStisknuta(object sender, KeyEventArgs e)
        {
            if (selectedField.X == -1 || selectedField.Y == -1) {
                MessageBox.Show("Vyberte prosím nejdříve pole.");
                return;
            }

            int num = -1;
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                case Keys.D1:
                    num = 1;
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    num = 2;
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    num = 3;
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    num = 4;
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    num = 5;
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    num = 6;
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    num = 7;
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    num = 8;
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    num = 9;
                    break;
                case Keys.Back:
                    num = 0;
                    break;
            }


            if (num != -1)
                VykonejTah(selectedField.X, selectedField.Y, num);
        }

        //Vrátit tah
        private void StepBack(object sender, EventArgs e)
        {
            SudokuTah tah = previous.Pop();
            VykonejTah(tah.GetIndex() % 9, tah.GetIndex() / 9, tah.GetOriginal(), false);
            next.Push(previous.Pop());

            PrekliknutiPole(new Label() { Name = (tah.GetIndex() % 9) + "_" + (tah.GetIndex() / 9) }, null);
            RedrawFields();
        }

        //Vrácení vráceného tahu
        private void StepForward(object sender, EventArgs e)
        {
            SudokuTah tah = next.Pop();
            VykonejTah(tah.GetIndex() % 9, tah.GetIndex() / 9, tah.GetOriginal(), false);

            PrekliknutiPole(new Label() { Name = (tah.GetIndex() % 9) + "_" + (tah.GetIndex() / 9) }, null);
            RedrawFields();
        }

        bool clickedClose = false;

        //Slušné zavření tlačítkem
        private void ClickCloseGameForm(object sender, EventArgs e)
        {
            clickedClose = true;
            
            if (onMainThread)
            {
                SaveGameFile();
                Hide();
            }
            else
                Close();

            new StartGameForm().Show();
        }

        //Zvířecí zavření křížkem
        private void CloseGameForm(object sender, EventArgs e)
        {
            if (sender is Button)
                clickedClose = false;

            //Uložíme jako poslední hru
            string saveFile = Path.Combine(Program.SAVE_PATH, "lastGame.txt");
            using (StreamWriter writer = new StreamWriter(new FileStream(saveFile, FileMode.Create)))
            {
                writer.Write(clickedClose ? "" : name);
                writer.Flush();
                writer.Close();
            }

            SaveGameFile();

            if (!clickedClose)
                Application.Exit();
        }

        private void SaveGameFile()
        {
            string saveFile = Path.Combine(Path.Combine(Program.SAVE_PATH, "games"), name + ".sudoku");
            using (StreamWriter writer = new StreamWriter(new FileStream(saveFile, FileMode.Create)))
            {
                writer.WriteLine(name);
                writer.WriteLine("" + (selectedField.Y * 9 + selectedField.X));

                writer.WriteLine(originalBoard.ToString());
                writer.WriteLine(board.ToString());

                writer.Flush();
                writer.Close();
            }
        }
    }
}
