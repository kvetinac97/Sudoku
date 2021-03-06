﻿using System;
using System.IO;
using System.Windows.Forms;

namespace Sudoku
{
    static class Program
    {

        //Cesta, kam se ukládají veškerá data %APPDATA%/Sudoku/...
        public static string SAVE_PATH;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SAVE_PATH = Path.Combine(Environment.GetFolderPath(
               Environment.SpecialFolder.ApplicationData), "Sudoku");
            string lastGameFilePath = Path.Combine(SAVE_PATH, "lastGame.txt");

            if (!Directory.Exists(SAVE_PATH))
                Directory.CreateDirectory(SAVE_PATH);

            if (File.Exists(lastGameFilePath))
            {
                using (StreamReader reader = new StreamReader(lastGameFilePath))
                {
                    string data = reader.ReadToEnd();
                    if (data.Length > 0)
                    {
                        DialogResult result = MessageBox.Show("Chcete otevřít poslední uloženou hru?", "Sudoku",
                            MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            GameForm gameForm = new GameForm(true);
                            SudokuBoard.LoadIntoGameForm(gameForm, data);
                            reader.Close();
                            Application.Run(gameForm);
                            return;
                        }
                        else
                        {
                            reader.Close();
                            File.Delete(lastGameFilePath);
                        }
                    }
                }
            }

            Application.Run(new IntroductionForm(true));
        }
    }
}
