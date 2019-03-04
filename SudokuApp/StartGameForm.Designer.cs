namespace Sudoku
{
    partial class StartGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartGameForm));
            this.newPlayGame = new System.Windows.Forms.Button();
            this.difficulty = new System.Windows.Forms.ComboBox();
            this.savedGamesTitle = new System.Windows.Forms.Label();
            this.closeSelection = new System.Windows.Forms.PictureBox();
            this.savedGames = new System.Windows.Forms.ListBox();
            this.deleteSave = new System.Windows.Forms.Button();
            this.savesFolder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closeSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.savesFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // newPlayGame
            // 
            this.newPlayGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPlayGame.Location = new System.Drawing.Point(970, 660);
            this.newPlayGame.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.newPlayGame.Name = "newPlayGame";
            this.newPlayGame.Size = new System.Drawing.Size(368, 63);
            this.newPlayGame.TabIndex = 1;
            this.newPlayGame.Text = "NOVÁ HRA";
            this.newPlayGame.UseVisualStyleBackColor = true;
            this.newPlayGame.Click += new System.EventHandler(this.StartGame);
            // 
            // difficulty
            // 
            this.difficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficulty.FormattingEnabled = true;
            this.difficulty.Items.AddRange(new object[] {
            "Prázdné Sudoku",
            "Jednoduchá",
            "Normální",
            "Obtížná",
            "Ultrahardcore"});
            this.difficulty.Location = new System.Drawing.Point(100, 660);
            this.difficulty.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.difficulty.Name = "difficulty";
            this.difficulty.Size = new System.Drawing.Size(616, 54);
            this.difficulty.TabIndex = 2;
            this.difficulty.Text = "Obtížnost...";
            // 
            // savedGamesTitle
            // 
            this.savedGamesTitle.AutoSize = true;
            this.savedGamesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savedGamesTitle.Location = new System.Drawing.Point(450, 35);
            this.savedGamesTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.savedGamesTitle.Name = "savedGamesTitle";
            this.savedGamesTitle.Size = new System.Drawing.Size(502, 97);
            this.savedGamesTitle.TabIndex = 3;
            this.savedGamesTitle.Text = "Uložené hry";
            this.savedGamesTitle.Click += new System.EventHandler(this.SavedGamesOutclicked);
            // 
            // closeSelection
            // 
            this.closeSelection.Image = global::Sudoku.Properties.Resources.cross;
            this.closeSelection.Location = new System.Drawing.Point(966, 52);
            this.closeSelection.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.closeSelection.Name = "closeSelection";
            this.closeSelection.Size = new System.Drawing.Size(64, 62);
            this.closeSelection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeSelection.TabIndex = 4;
            this.closeSelection.TabStop = false;
            this.closeSelection.Click += new System.EventHandler(this.HandleCloseButton);
            // 
            // savedGames
            // 
            this.savedGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savedGames.FormattingEnabled = true;
            this.savedGames.ItemHeight = 46;
            this.savedGames.Location = new System.Drawing.Point(100, 167);
            this.savedGames.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.savedGames.Name = "savedGames";
            this.savedGames.Size = new System.Drawing.Size(1234, 418);
            this.savedGames.TabIndex = 5;
            this.savedGames.SelectedIndexChanged += new System.EventHandler(this.SavedGameSelected);
            // 
            // deleteSave
            // 
            this.deleteSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSave.Location = new System.Drawing.Point(100, 658);
            this.deleteSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.deleteSave.Name = "deleteSave";
            this.deleteSave.Size = new System.Drawing.Size(368, 63);
            this.deleteSave.TabIndex = 6;
            this.deleteSave.Text = "SMAZAT HRU";
            this.deleteSave.UseVisualStyleBackColor = true;
            this.deleteSave.Visible = false;
            this.deleteSave.Click += new System.EventHandler(this.DeleteSavedGame);
            // 
            // savesFolder
            // 
            this.savesFolder.Image = global::Sudoku.Properties.Resources.folder;
            this.savesFolder.Location = new System.Drawing.Point(374, 52);
            this.savesFolder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.savesFolder.Name = "savesFolder";
            this.savesFolder.Size = new System.Drawing.Size(64, 62);
            this.savesFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.savesFolder.TabIndex = 7;
            this.savesFolder.TabStop = false;
            this.savesFolder.Click += new System.EventHandler(this.OpenSavedFolder);
            // 
            // StartGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 771);
            this.Controls.Add(this.savesFolder);
            this.Controls.Add(this.deleteSave);
            this.Controls.Add(this.savedGames);
            this.Controls.Add(this.closeSelection);
            this.Controls.Add(this.savedGamesTitle);
            this.Controls.Add(this.difficulty);
            this.Controls.Add(this.newPlayGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "StartGameForm";
            this.Text = "Sudoku - nová hra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HandleCloseWindow);
            this.Click += new System.EventHandler(this.SavedGamesOutclicked);
            ((System.ComponentModel.ISupportInitialize)(this.closeSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.savesFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button newPlayGame;
        private System.Windows.Forms.ComboBox difficulty;
        private System.Windows.Forms.Label savedGamesTitle;
        private System.Windows.Forms.PictureBox closeSelection;
        private System.Windows.Forms.ListBox savedGames;
        private System.Windows.Forms.Button deleteSave;
        private System.Windows.Forms.PictureBox savesFolder;
    }
}