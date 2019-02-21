using SudokuSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class GameForm : Form
    {

        public string name;
        private bool onMainThread;

        public int timePlaying = 0;

        public SudokuBoard originalBoard, board, solution;
        int selectedRow = -1, selectedCol = -1;

        public Stack<SudokuTah> previous = new Stack<SudokuTah>();
        public Stack<SudokuTah> next = new Stack<SudokuTah>();

        public GameForm(bool onMainThread = false)
        {
            InitializeComponent();
            this.onMainThread = onMainThread;
        }

        private void SudokuApp_Load(object sender, EventArgs e)
        {
            //Vyhledání prvního volného pole
            for (int i = 0; i < 81; i++)
                if (board.GetBoard().GetCell(new Location(i)) == 0)
                {
                    selectedCol = i % 9;
                    selectedRow = i / 9;
                    break;
                }

            //Načtení pole z dat
            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row < 9; row++)
                {
                    Label label = new Label();
                    label.Name = col + "_" + row;

                    Location loc = new Location(col, row);
                    int val = board.GetBoard().GetCell(loc);

                    label.ForeColor = (val != 0 && originalBoard.GetBoard().GetCell(loc) == 0) ? Color.Blue : Color.Black;
                    label.Text = val == 0 ? "" : ""+val;
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    label.Font = new Font(label.Font.FontFamily, 20);
                    label.Size = new Size(40, 40);
                    label.Click += Label_Click;

                    if (col == selectedCol && row == selectedRow)
                        label.BackColor = Color.Yellow;

                    sudokuBoard.Controls.Add(label, col, row);
                }
            }
            
        }
        //Vykreslení ohraničení pole
        private void sudokuBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column != selectedCol || e.Row != selectedRow)
                return;

            e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.CellBounds);
        }

        //Překliknutí vybraného pole
        private void Label_Click(object sender, EventArgs e)
        {
            //Najde označené místo a zruší na něm označení
            Control previous = sudokuBoard.Controls[selectedCol + "_" + selectedRow];
            previous.BackColor = Color.FromKnownColor(KnownColor.Control);

            Rectangle rect = previous.Bounds;
            rect.Inflate(3, 0);
            sudokuBoard.Invalidate(rect);

            //Zjistí z parametrů události řádek a sloupec
            string[] colRow = ((Label)sender).Name.Split('_');
            selectedCol = int.Parse(colRow[0]);
            selectedRow = int.Parse(colRow[1]);

            //Označí nové místo
            Control next = sudokuBoard.Controls[selectedCol + "_" + selectedRow];
            next.BackColor = Color.Yellow;

            Rectangle rect2 = next.Bounds;
            rect2.Inflate(3, 0);
            sudokuBoard.Invalidate(rect2);
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
                writer.WriteLine("" + board.GetSeed());
                writer.WriteLine(originalBoard.ToString());
                
                //Uložení tahů
                string previousTahy = "";
                foreach (SudokuTah tah in previous)
                {
                    previousTahy = tah.ToString() + ":";
                }
                writer.WriteLine(previousTahy.Substring(0, previousTahy.Length - 1));

                writer.Flush();
                writer.Close();
            }
        }
    }
}
