using SudokuSharp;
using System;
using System.IO;

namespace Sudoku
{
    public class SudokuBoard
    {

        //Proměnné
        private Board board;
        private int seed = -1;

        //Konstruktor
        public SudokuBoard (Board board, int seed = -1)
        {
            this.board = board;
            this.seed = -1;
        }

        //Vrátí instanci boardu
        public Board GetBoard()
        {
            return board;
        }
        
        //Vrátí aktuální seed
        public int GetSeed()
        {
            return seed;
        }

        //Vytvoří prázdný SudokuBoard
        public static SudokuBoard Empty()
        {
            Board board = new Board();
            return new SudokuBoard(board);
        }

        //Vytvoří nový SudokuBoard dle zadané obtížnosti
        public static SudokuBoard Create(int difficulty)
        {
            int seed = new Random((int)Math.Round((DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds)).Next(int.MaxValue);
            return new SudokuBoard(Factory.Puzzle(seed, 0, difficulty * 3, difficulty * 5), seed);
        }

        //Získá platné řešení aktuálního SudokuBoard
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

        //Převede se na 81 znakový text
        public override string ToString()
        {
            Board board = new Board();
            string text = "";

            for (int i = 0; i < 81; i++)
            {
                text += board.GetCell(new Location(i)).ToString();
            }

            return text;
        }

        //Načtení dat ze souboru do GameFormu
        public static void LoadIntoGameForm(GameForm gameForm, string fileName)
        {
            string saveFolder = Path.Combine(Program.SAVE_PATH, "games");
            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);

            string saveFile = Path.Combine(saveFolder, fileName + ".sudoku");
            if (!File.Exists(saveFile))
                return;

            using (StreamReader reader = new StreamReader(new FileStream(saveFile, FileMode.Open)))
            {
                gameForm.name = reader.ReadLine().Trim();
                gameForm.timePlaying = int.Parse(reader.ReadLine().Trim());

                int seed = int.Parse(reader.ReadLine().Trim());
                string sudokuText = reader.ReadLine().Trim();

                Board board = new Board();
                for (int i = 0; i < 81; i++)
                {
                    if (sudokuText[i] == '0')
                        continue;

                    board.PutCell(i, int.Parse(sudokuText[i].ToString()));
                    i++;
                }
            
                gameForm.board = new SudokuBoard(board, seed);
                gameForm.solution = gameForm.board.GetSolution();

                reader.Close();
            }
        }

    }
}
