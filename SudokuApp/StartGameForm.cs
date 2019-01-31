using System;
using System.IO;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class StartGameForm : Form
    {
        //Proměnné
        private string selectedSave = null;
        bool shouldOpenIntroduction = true;

        public StartGameForm()
        {
            InitializeComponent();
            LoadSavedGames();
        }

        //Načtení her do seznamu
        private void LoadSavedGames()
        {
            savedGames.Items.Clear();

            foreach (FileInfo fileInfo in new DirectoryInfo(Path.Combine(Program.SAVE_PATH, "games")).GetFiles("*.sudoku"))
                savedGames.Items.Add(Path.GetFileNameWithoutExtension(fileInfo.Name));
        }

        //Otevře složku s uloženými hrami
        private void openSavedFolder(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Path.Combine(Program.SAVE_PATH, "games"));
        }

        //Změna tlačítek po kliknutí na uloženou hru
        private void SavedGameSelected(object sender, EventArgs e)
        {
            string saveName = (string) savedGames.SelectedItem;
            selectedSave = saveName;

            difficulty.Hide();
            deleteSave.Show();
            newPlayGame.Text = "SPUSTIT HRU";
        }

        //Změna tlačítek po vykliknutí z uložené hry
        private void SavedGamesOutclicked(object sender, EventArgs e)
        {
            if (sender is ListBox && !difficulty.Visible)
                return;

            savedGames.SelectedIndex = -1;
            selectedSave = null;

            deleteSave.Hide();
            difficulty.Show();
            newPlayGame.Text = "NOVÁ HRA";
        }

        //Smazání uložené hry
        private void deleteSavedGame(object sender, EventArgs e)
        {
            File.Delete(Path.Combine(Program.SAVE_PATH, selectedSave + ".txt"));
            selectedSave = null;

            difficulty.Show();
            deleteSave.Hide();
            newPlayGame.Text = "NOVÁ HRA";

            LoadSavedGames();
        }

        //Spuštění hry
        private void startGame(object sender, EventArgs e)
        {
            if (selectedSave != null)
            {
                GameForm gameForm = new GameForm();
                SudokuBoard.LoadIntoGameForm(gameForm, selectedSave);
                gameForm.Show();

                shouldOpenIntroduction = false;
                Close();
            }
            else
            {
                GameForm gameForm = new GameForm();
                if (difficulty.SelectedIndex == -1)
                {
                    MessageBox.Show("Vyberte prosím platnou obtížnost!", "Neexistující obtížnost",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                gameForm.name = Prompt.ShowDialog("Jméno hry:", "Sudoku");

                int gameDifficulty = 1;
                switch (difficulty.SelectedItem)
                {
                    case "Prázdné Sudoku":
                        gameForm.board = SudokuBoard.Empty();
                        break;
                    case "Ultrahardcore":
                        gameDifficulty = 4;
                        goto default;
                    case "Obtížná":
                        gameDifficulty = 3;
                        goto default;
                    case "Normální":
                        gameDifficulty = 2;
                        goto default;
                    default:
                        gameForm.board = SudokuBoard.Create(gameDifficulty);
                        break;
                }

                gameForm.solution = gameForm.board.GetSolution();
                gameForm.Show();

                shouldOpenIntroduction = false;
                Close();
            }
        }

        //Zavření okna
        private void closeWindowHandle(object sender, EventArgs e)
        {
            if (!(e is FormClosingEventArgs))
            {
                Close();
                return;
            }

            if (shouldOpenIntroduction)
                new IntroductionForm().Show();
        }
    }
}
