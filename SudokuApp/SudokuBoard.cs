using SudokuSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuBoard
    {

        private Board board { get; }
        private int seed = -1;

        public SudokuBoard (Board board, int seed = -1)
        {
            this.board = board;
            this.seed = -1;
        }

        public static SudokuBoard empty()
        {
            return new SudokuBoard(new Board());
        }

        public static SudokuBoard create(int difficulty)
        {
            int seed = new Random((int)Math.Round((DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds)).Next(int.MaxValue);
            return new SudokuBoard(Factory.Puzzle(seed, 0, difficulty * 3, difficulty * 5), seed);
        }

        public SudokuBoard getSolution()
        {
            if (board.IsSolved)
                return this;

            if (!board.IsValid)
                return null;

            switch (board.CountSolutions())
            {
                case 0:
                    return null;
                case 1:
                    if (seed != -1)
                    {
                        return new SudokuBoard(Factory.Solution(seed), seed);
                    }
                        return Factory.Solution(seed);
                    goto default;
                default:
                    return Factory.Puzzle(board, new Random(), 0, 0, 0);
            }
        }

        public static void LoadIntoGameForm(GameForm gameForm, string fileName)
        {
            //TODO 
            /*using (XmlReader xr = XmlReader.Create(fileInfo.FullName))
            {
                GameForm gameForm = new GameForm("");
                string actualElement = null;

                while (xr.Read())
                {
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        actualElement = xr.Name;
                        if (actualElement == "field")
                        {

                        }
                        //if (xr.Name == "xxx") yy = xr.GetAttribute("zzz");
                    }
                    else if (xr.NodeType == XmlNodeType.Text)
                    {
                        if (actualElement == "name")
                        {
                            gameForm.name = xr.Value;
                        }
                        //if (actualElement == "xxx") yy = xr.Value;
                    }
                    else if (xr.NodeType == XmlNodeType.EndElement)
                    {
                        actualElement = null;
                    }
                }
            }*/
        }

    }
}
