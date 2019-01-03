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
using System.Xml;

namespace Sudoku
{
    public partial class StartGameForm : Form
    {
        private string selectedSave = null;

        public StartGameForm()
        {
            InitializeComponent();
        }

        //Načtení her do seznamu
        private void LoadSavedGames(object sender, EventArgs e)
        {
            savedGames.Items.Clear();

            foreach (FileInfo fileInfo in new DirectoryInfo(Program.SAVE_PATH).GetFiles("*.xml"))
                savedGames.Items.Add(Path.GetFileNameWithoutExtension(fileInfo.Name));
        }

        //Otevře složku s uloženými hrami
        private void openSavedFolder(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Program.SAVE_PATH);
        }

        private void SavedGameSelected(object sender, EventArgs e)
        {
            string saveName = (string) savedGames.SelectedItem;
            selectedSave = saveName;

            difficulty.Hide();
            deleteSave.Show();
            newPlayGame.Text = "SPUSTIT HRU";
        }

        private void deleteSavedGame(object sender, EventArgs e)
        {
            File.Delete(Path.Combine(Program.SAVE_PATH, selectedSave + ".xml"));
            selectedSave = null;

            difficulty.Hide();
            deleteSave.Hide();
            newPlayGame.Text = "NOVÁ HRA";

            LoadSavedGames(null, null);
        }

        private void startGame(object sender, EventArgs e)
        {
            if (selectedSave != null)
            {
                GameForm gameForm = new GameForm(selectedSave);
                gameForm.Show();
                Close();
            }
            else
            {
                GameForm gameForm = new GameForm("");
                gameForm.name = Prompt.ShowDialog("Jméno hry:", "Sudoku");
                //ToDo tady pokračovat

                switch (difficulty.SelectedItem)
                {
                    case "Prázdné Sudoku":
                        
                        break;

                }
            }
        }
    }
}
