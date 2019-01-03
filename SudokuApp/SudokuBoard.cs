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

        private Board board;

        public static SudokuBoard empty()
        {
            Board board = new Board();
            return new SudokuBoard();
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
