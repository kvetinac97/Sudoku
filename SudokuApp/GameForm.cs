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
        public int timePlaying = 0;

        public SudokuBoard originalBoard, board, solution;
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
            //Nastavení vybraného pole
            if (selectedField.X == -1 && selectedField.Y == -1)
                selectedField = board.FirstEmpty();

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

                    sudokuBoard.Controls.Add(label, col, row);
                }
            }
            
        }
        private void SudokuBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column != selectedField.X || e.Row != selectedField.Y)
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

            //Nemůžeme upravovat stálé hodnoty
            if (originalBoard.GetValue(col, row) != 0)
                return;

            //Najde označené místo a zruší na něm označení
            Control previous = sudokuBoard.Controls[selectedField.X + "_" + selectedField.Y];
            previous.BackColor = Color.FromKnownColor(KnownColor.Control);

            Rectangle rect = previous.Bounds;
            rect.Inflate(3, 3);
            sudokuBoard.Invalidate(rect);

            //Nastaví nové pole
            selectedField = new Point(col, row);

            //Označí nové místo
            Control next = sudokuBoard.Controls[selectedField.X + "_" + selectedField.Y];
            next.BackColor = Color.Yellow;

            Rectangle rect2 = next.Bounds;
            rect2.Inflate(3, 3);
            sudokuBoard.Invalidate(rect2);
        }

        //Použití nápovědy
        private void Napoveda(object sender, EventArgs e)
        {
            Point volny = board.FindLowestPossibilities(false);
            if (volny.X == -1 || volny.Y == -1)
            {
                MessageBox.Show("Sudoku je již vyřešeno.");
                return;
            }

            PrekliknutiPole(sudokuBoard.Controls[volny.X + "_" + volny.Y], null);
            VykonejTah(volny.X, volny.Y, solution.GetValue(volny.X, volny.Y));
            MessageBox.Show("Nápověda byla využita.");
        }

        // INTERNAL | Vykonání tahu
        private void VykonejTah(int col, int row, int value)
        {
            SudokuTah tah = new SudokuTah(row * 9 + col, board.GetValue(col, row), value);
            previous.Push(tah);

            sudokuBoard.Controls[col + "_" + row].Text = ("" + value).Replace("0", "");
            board.SetValue(col, row, value);
            RedrawFields();
        }

        //Překreslení pole v případě chybného zadání
        private void RedrawFields()
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
                        sudokuBoard.Controls[usedPoint.X + "_" + usedPoint.Y].ForeColor = Color.Red;
                        sudokuBoard.Controls[col + "_" + row].ForeColor = Color.Red;

                        wrong.Add(usedPoint.X + "_" + usedPoint.Y);
                        wrong.Add(col + "_" + row);
                    }
                    else
                    {
                        used.Add(num, new Point(col, row));

                        if (!wrong.Contains(col + "_" + row))
                            sudokuBoard.Controls[col + "_" + row].ForeColor = originalBoard.GetValue(col, row) == 0 ? Color.Blue : Color.Black;
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
                        sudokuBoard.Controls[usedPoint.X + "_" + usedPoint.Y].ForeColor = Color.Red;
                        sudokuBoard.Controls[col + "_" + row].ForeColor = Color.Red;

                        wrong.Add(usedPoint.X + "_" + usedPoint.Y);
                        wrong.Add(col + "_" + row);
                    }
                    else
                    {
                        used.Add(num, new Point(col, row));

                        if (!wrong.Contains(col + "_" + row))
                            sudokuBoard.Controls[col + "_" + row].ForeColor = originalBoard.GetValue(col, row) == 0 ? Color.Blue : Color.Black;
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
                                sudokuBoard.Controls[usedPoint.X + "_" + usedPoint.Y].ForeColor = Color.Red;
                                sudokuBoard.Controls[col + "_" + row].ForeColor = Color.Red;

                                wrong.Add(usedPoint.X + "_" + usedPoint.Y);
                                wrong.Add(col + "_" + row);
                            }
                            else
                            {
                                used.Add(num, new Point(col, row));

                                if (!wrong.Contains(col + "_" + row))
                                    sudokuBoard.Controls[col + "_" + row].ForeColor = originalBoard.GetValue(col, row) == 0 ? Color.Blue : Color.Black;
                            }
                        }
                    }
                }
            }
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
                    num = 1;
                    break;
                case Keys.NumPad2:
                    num = 2;
                    break;
                case Keys.NumPad3:
                    num = 3;
                    break;
                case Keys.NumPad4:
                    num = 4;
                    break;
                case Keys.NumPad5:
                    num = 5;
                    break;
                case Keys.NumPad6:
                    num = 6;
                    break;
                case Keys.NumPad7:
                    num = 7;
                    break;
                case Keys.NumPad8:
                    num = 8;
                    break;
                case Keys.NumPad9:
                    num = 9;
                    break;
                case Keys.Back:
                    num = 0;
                    break;
            }


            if (num != -1)
                VykonejTah(selectedField.X, selectedField.Y, num);
        }

        //Zavření formuláře - uložení hry
        private void CloseGameForm(object sender, EventArgs e)
        {
            string saveFile = Path.Combine(Program.SAVE_PATH, "lastGame.txt");
            using (StreamWriter writer = new StreamWriter(new FileStream(saveFile, FileMode.Create)))
            {
                writer.Write(name);
                writer.Flush();
                writer.Close();
            }

            SaveGameFile();

            if (!onMainThread && sender is Button)
            {
                Close();
                return;
            }
            else if (sender is Button)
                Hide();

            new StartGameForm().Show();
        }
        private void SaveGameFile()
        {
            string saveFile = Path.Combine(Path.Combine(Program.SAVE_PATH, "games"), name + ".sudoku");
            using (StreamWriter writer = new StreamWriter(new FileStream(saveFile, FileMode.Create)))
            {
                writer.WriteLine(name);
                writer.WriteLine("" + timePlaying);
                writer.WriteLine("" + (selectedField.Y * 9 + selectedField.X));
                writer.WriteLine(originalBoard.ToString());
                
                //Uložení tahů
                string previousTahy = "";
                foreach (SudokuTah tah in previous)
                {
                    previousTahy += tah.ToString() + ":";
                }
                writer.WriteLine(previousTahy.Substring(0, previousTahy.Length - 1));

                writer.Flush();
                writer.Close();
            }
        }
    }
}
