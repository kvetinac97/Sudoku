using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Sudoku
{
    public class SudokuBoard
    {

        //Data
        private int[,] data = new int[9,9];
        private int[,] solution = null;
        private bool multipleSolutions = false;

        //Konstruktor
        public SudokuBoard ()
        {
            for (int col = 0; col < 9; col++)
                for (int row = 0; row < 9; row++)
                    data[col,row] = 0;
        }

        //Vytvoří nový SudokuBoard dle zadané obtížnosti
        public static SudokuBoard Create(int difficulty)
        {
            SudokuBoard board = new SudokuBoard();
            int number;

            switch (difficulty){
                case 1:
                default:
                    number = 28;
                    break;
                case 2:
                    number = 40;
                    break;
                case 3:
                    number = 48;
                    break;
            }

            board.SolveBoard(board);
            board.CutCells(number);
            return board;
        }

        // INTERNAL | Odstranění políček z pole
        private void CutCells(int number)
        {
            int cut = 0;
            int recursionTimes = 0;

            while (cut != number && recursionTimes < 100)
            {
                recursionTimes++;
                int col = new Random((int)(DateTime.Now - new DateTime(2018, 1, 1)).TotalMilliseconds).Next(9);
                int row = new Random((int)(DateTime.Now - new DateTime(2018, 1, 1)).TotalMilliseconds).Next(9);

                if (data[col, row] == 0)
                    continue;

                SudokuBoard cloneBoard = Clone();
                cloneBoard.SetValue(col, row, 0);
                cloneBoard.SolveBoard(cloneBoard);

                if (cloneBoard.multipleSolutions || cloneBoard.solution == null)
                    continue;

                SetValue(col, row, 0);
                cut++;
            }
        }

        //Získá platné řešení aktuálního SudokuBoard
        public SudokuBoard GetSolution()
        {
            if (IsSolved())
                return this;

            if (solution == null)
                SolveBoard(this);

            if (solution == null)
                return null;

            SudokuBoard board = new SudokuBoard();
            board.data = board.solution = solution;
            return board;
        }

        //Vyřeší Sudoku
        public void SolveBoard(SudokuBoard board)
        {
            //Sudoku je vyřešeno a víme že řešení není jedno, nejedeme dále
            if (solution != null || multipleSolutions)
                return;

            if (!board.IsValid())
                return;

            //Vyplní všechna pole, která mají jen jednu možnost a najde pole s nejnižším počtem možností
            Point lowest = board.FindLowestPossibilities();

            if (board.IsSolved())
            {
                if (solution != null)
                    multipleSolutions = true;
                else
                    solution = board.data;

                return;
            }

            if (lowest.X == -1 || lowest.Y == -1)
                return;

            foreach (int num in board.FindPossibilities(lowest.X, lowest.Y))
            {

                SudokuBoard cloneBoard = board.Clone();
                cloneBoard.SetValue(lowest.X, lowest.Y, num);

                if (!cloneBoard.IsValid())
                    continue;

                SolveBoard(cloneBoard);
            }
        }

        //Řešení Sudoku
        public Point FindLowestPossibilities(bool autoFillOnes = true)
        {
            int lowestPossibilities = 10;
            Point lowest = new Point(-1, -1);

            List<int> selectCol = ShuffleList(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            List<int> selectRow = ShuffleList(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

            foreach (int col in selectCol)
            {
                foreach (int row in selectRow)
                {
                    if (data[col, row] != 0)
                        continue;

                    List<int> possibilities = FindPossibilities(col, row);
                    if (possibilities.Count == 1 && autoFillOnes)
                    {
                        SetValue(col, row, possibilities[0]);
                        continue;
                    }

                    if (possibilities.Count < lowestPossibilities)
                        lowest = new Point(col, row);
                }
            }

            return lowest;
        }
        private List<int> FindPossibilities(int col, int row)
        {
            List<int> possible = new List<int>();
            for (int num = 1; num <= 9; num++)
            {
                SudokuBoard cloneBoard = Clone();
                cloneBoard.SetValue(col, row, num);

                if (cloneBoard.IsValid())
                    possible.Add(num);
            }

            return ShuffleList(possible);
        }

        private List<int> ShuffleList(List<int> list)
        {
            List<int> result = new List<int>();
            int originalCount = list.Count;
            while (result.Count < originalCount)
            {
                int randomIndex = new Random((int)(DateTime.Now - new DateTime(2018, 1, 1)).TotalMilliseconds).Next(list.Count);
                result.Add(list[randomIndex]);
                list.RemoveAt(randomIndex);
            }

            return result;
        }

        // Je Sudoku platné? Je vyřešeno?
        public bool IsValid(bool filled = false)
        {
            for (int col = 0; col < 9; col++)
                if (!CheckCol(col, filled))
                    return false;

            for (int row = 0; row < 9; row++)
                if (!CheckRow(row, filled))
                    return false;

            for (int sCol = 0; sCol < 9; sCol += 3)
                for (int sRow = 0; sRow < 9; sRow += 3)
                    if (!CheckGrid(sCol, sRow, filled))
                        return false;

            return true;
        }
        public bool IsSolved()
        {
            return IsValid(true);
        }

        // INTERNAL | Je sloupec/řádek/mřížka platná?
        private bool CheckCol(int col, bool filled)
        {
            List<int> found = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int row = 0; row < 9; row++)
            {
                int num = data[col, row];
                if (num == 0)
                    if (filled)
                        return false;
                    else
                        continue;

                if (!found.Contains(num))
                    return false;

                found.Remove(num);
            }

            return found.Count == 0 || !filled;
        }
        private bool CheckRow(int row, bool filled)
        {
            List<int> found = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int col = 0; col < 9; col++)
            {
                int num = data[col, row];
                if (num == 0)
                    if (filled)
                        return false;
                    else
                        continue;

                if (!found.Contains(num))
                    return false;

                found.Remove(num);
            }

            return found.Count == 0 || !filled;
        }
        private bool CheckGrid(int startCol, int startRow, bool filled)
        {
            List<int> found = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int col = startCol; col < startCol + 3; col++)
            {
                for (int row = startRow; row < startRow + 3; row++)
                {
                    int num = data[col, row];
                    if (num == 0)
                        if (filled)
                            return false;
                        else
                            continue;

                    if (!found.Contains(num))
                        return false;

                    found.Remove(num);
                }
            }

            return found.Count == 0 || !filled;
        }

        //Nastaví / získá hodnotu v poli
        public void SetValue(int col, int row, int value)
        {
            if (value > 9 || value < 0)
                return;

            data[col, row] = value;
        }
        public int GetValue(int col, int row)
        {
            return data[col, row];
        }

        //Vrátí první prázdné pole, [-1, -1] v případě selhání
        public Point FirstEmpty()
        {
            for (int row = 0; row < 9; row++)
                for (int col = 0; col < 9; col++)
                    if (data[col, row] == 0)
                        return new Point(col, row);

            return new Point(-1, -1);
        }

        //Převede se na 81 znakový text
        public override string ToString()
        {
            string text = "";

            for (int col = 0; col < 9; col++)
                for (int row = 0; row < 9; row++)
                    text += data[col, row].ToString();

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

                int selectedIndex = int.Parse(reader.ReadLine().Trim());
                gameForm.selectedField = new Point(selectedIndex % 9, selectedIndex / 9);

                string sudokuText = reader.ReadLine().Trim();

                SudokuBoard board = new SudokuBoard();
                for (int i = 0; i < 81; i++)
                {
                    if (sudokuText[i] == '0')
                        continue;

                    board.SetValue(i % 9, i / 9, int.Parse(sudokuText[i].ToString()));
                    i++;
                }

                gameForm.originalBoard = board.Clone();
                gameForm.board = board;
                gameForm.solution = gameForm.board.GetSolution();

                //Načtení uložených tahů
                string[] previousTahy = reader.ReadLine().Trim().Split(':');

                foreach (string previousTah in previousTahy)
                {
                    SudokuTah tah = SudokuTah.FromString(previousTah.Split('-'));
                    gameForm.previous.Push(tah);
                    gameForm.board.SetValue(tah.GetIndex() % 9, tah.GetIndex() / 9, tah.GetNext());
                }

                reader.Close();
            }
        }

        // INTERNAL | Klonování
        public SudokuBoard Clone()
        {
            SudokuBoard newBoard = new SudokuBoard();
            for (int col = 0; col < 9; col++)
                for (int row = 0; row < 9; row++)
                    newBoard.data[col, row] = data[col, row];

            return newBoard;
        }

    }
}
