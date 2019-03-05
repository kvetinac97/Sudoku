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
                    number = 32;
                    break;
                case 3:
                    number = 38;
                    break;
                case 4:
                    number = 42;
                    break;
            }

            board = board.GetSolution().Clone();

            board.CutCells(number);
            return board;
        }

        // INTERNAL | Odstranění políček z pole
        private void CutCells(int number)
        {
            int cut = 0;
            int recursionTimes = 0;

            while (cut < number && recursionTimes < 100)
            {
                recursionTimes++;
                List<int> randomData = ShuffleList(new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

                int col = randomData[0];
                int row = randomData[1];

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
            if (!IsValid())
                return null;

            if (IsSolved())
                return this;

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

        int seed = -1;
        private List<int> ShuffleList(List<int> list)
        {
            List<int> result = new List<int>();
            int originalCount = list.Count;

            if (seed == -1)
                seed = DateTime.Now.Millisecond;
            else
                seed++;

            Random random = new Random(seed);
            while (result.Count < originalCount)
            {
                int randomIndex = random.Next(list.Count);
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

            for (int row = 0; row < 9; row++)
                for (int col = 0; col < 9; col++)
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
                int selectedIndex = int.Parse(reader.ReadLine().Trim());
                gameForm.selectedField = new Point(selectedIndex % 9, selectedIndex / 9);

                SudokuBoard originalBoard = new SudokuBoard();
                string sudokuText = reader.ReadLine().Trim();
                int col = 0, row = 0;

                foreach (char letter in sudokuText)
                {
                    int val = int.Parse(letter.ToString());
                    originalBoard.SetValue(col++, row, val);

                    if (col == 9)
                    {
                        col = 0;
                        row++;
                    }
                }

                gameForm.originalBoard = originalBoard.Clone();

                SudokuBoard board = new SudokuBoard();
                string boardText = reader.ReadLine().Trim();
                int bcol = 0, brow = 0;

                foreach (char bletter in boardText)
                {
                    int bval = int.Parse(bletter.ToString());
                    board.SetValue(bcol++, brow, bval);

                    if (bcol == 9)
                    {
                        bcol = 0;
                        brow++;
                    }
                }

                gameForm.board = board.Clone();

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
