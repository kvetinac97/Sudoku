using SudokuSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuBoard
    {

        private Board board;
        private int seed = -1;

        public SudokuBoard (Board board, int seed = -1)
        {
            this.board = board;
            this.seed = -1;
        }

        public Board GetBoard()
        {
            return board;
        }

        public static SudokuBoard Empty()
        {
            Board board = new Board();
            return new SudokuBoard(board);
        }

        public static SudokuBoard Create(int difficulty)
        {
            int seed = new Random((int)Math.Round((DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds)).Next(int.MaxValue);
            return new SudokuBoard(Factory.Puzzle(seed, 0, difficulty * 3, difficulty * 5), seed);
        }

        public SudokuBoard GetSolution()
        {
            if (board.IsSolved)
                return this;

            if (seed != -1)
            {
                return new SudokuBoard(Factory.Solution(seed), seed);
            }

            return new SudokuBoard(board.Fill.Sequential());
        }

        //TODO zkontrolovat jestli funguje
        public static void LoadIntoGameForm(GameForm gameForm, string fileName)
        {
            using (StreamReader reader = new StreamReader(new FileStream(Path.Combine(Program.SAVE_PATH,
                fileName + ".sudoku"), FileMode.Open)))
            {
                gameForm.name = reader.ReadLine().Trim();
                gameForm.timeStarted = int.Parse(reader.ReadLine().Trim());

                int seed = int.Parse(reader.ReadLine().Trim());
                string sudokuText = reader.ReadLine().Trim();

                Board board = new Board();
                for (int i = 0; i < 81; i++)
                {
                    if (sudokuText[i] == '-')
                        continue;

                    board.PutCell(i, int.Parse(sudokuText[i].ToString()));
                    i++;
                }
            
                gameForm.board = new SudokuBoard(board, seed);
                gameForm.solution = gameForm.board.GetSolution();
            }
        }

    }
}
