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

namespace Sudoku
{
    public partial class IntroductionForm : Form
    {

        public IntroductionForm()
        {
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
            Hide();
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

    }
}
