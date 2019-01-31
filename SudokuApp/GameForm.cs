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

        public SudokuBoard board;
        public SudokuBoard solution;

        public Stack<SudokuBoard> previous = new Stack<SudokuBoard>();
        public Stack<SudokuBoard> next = new Stack<SudokuBoard>();

        public GameForm(bool onMainThread = false)
        {
            InitializeComponent();
            this.onMainThread = onMainThread;
        }

        private void SudokuApp_Load(object sender, EventArgs e)
        {
            Board board2 = Factory.Solution(new Random((int) 
                (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)))
                .TotalSeconds).Next(int.MaxValue));

            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row < 9; row++)
                {
                    Label label = new Label();
                    int val = board2.GetCell(new Location(col, row));

                    label.Text = val == 0 ? "" : ""+val;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Font = new Font(label.Font.FontFamily, 20);
                    label.Size = new Size(40, 40);
                    label.Click += Label_Click;

                    //if (col == 0 && row == 0)
                    //    label.BackColor = Color.Yellow;

                    sudokuBoard.Controls.Add(label, col, row);
                }
            }
            
        }

        private void Label_Click(object sender, EventArgs e)
        {
            sudokuBoard.Invalidate();
        }

        private void sudokuBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column != 0 || e.Row != 0)
                return;

            //e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.CellBounds);
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
                writer.WriteLine(board.ToString());

                writer.Flush();
                writer.Close();
            }
        }
    }
}
