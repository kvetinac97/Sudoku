using System;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class IntroductionForm : Form
    {

        private bool onMainThread;
        private bool shouldCloseApplication = false;

        public IntroductionForm(bool onMainThread = false)
        {
            this.onMainThread = onMainThread;
            this.shouldCloseApplication = !onMainThread;

            InitializeComponent();
        }

        //Načtení formuláře - vložíme do howToPlay text
        private void OnLoad(object sender, EventArgs e)
        {
            howToPlay.Text = "Cílem hry je doplnit chybějící čísla 1 až 9 v předem dané zčásti vyplněné tabulce.\n" +
                             "Tabulka je rozdělena na 9 × 9 polí, která jsou seskupena do 9 čtverců (3 × 3).\n" +
                             "K předem vyplněným číslům je třeba doplnit další čísla tak, aby platilo, že\n" +
                             "v každém řádku, v každém sloupci a v každém z devíti čtverců jsou použita vždy\n" +
                             "všechna čísla jedna až devět, ovšem každé číslo jen jednou. Pořadí čísel není\n" +
                             "důležité. Čísla se nesmějí opakovat v žádném sloupci, řadě ani malém čtverci.";
        }

        private void openStartDialog(object sender, EventArgs e)
        {
            StartGameForm startGame = new StartGameForm();
            startGame.Show();
            shouldCloseApplication = false;

            if (onMainThread)
                Hide();
            else
                Close();
        }

        // === HOW TO PLAY ===

        //Zobrazíme howToPlay
        private void howToPlay_show(object sender, EventArgs e)
        {
            howToPlay.Show();
            back.Show();

            title.Hide();
            titleCopyright.Hide();
            play.Hide();
            showHowToPlay.Hide();
        }

        //Schováme howToPlay
        private void howToPlay_hide(object sender, EventArgs e)
        {
            howToPlay.Hide();
            back.Hide();

            title.Show();
            titleCopyright.Show();
            play.Show();
            showHowToPlay.Show();
        }

        // === HOW TO PLAY ===

        //Zavření hry
        private void closeGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (shouldCloseApplication)
                closeGame(sender, e);
        }
    }
}
