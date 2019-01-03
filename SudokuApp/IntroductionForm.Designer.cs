namespace Sudoku
{
    partial class IntroductionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroductionForm));
            this.howToPlay = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.titleCopyright = new System.Windows.Forms.Label();
            this.showHowToPlay = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // howToPlay
            // 
            this.howToPlay.AutoSize = true;
            this.howToPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToPlay.Location = new System.Drawing.Point(12, 18);
            this.howToPlay.Name = "howToPlay";
            this.howToPlay.Size = new System.Drawing.Size(151, 24);
            this.howToPlay.TabIndex = 0;
            this.howToPlay.Text = "HOW_TO_PLAY";
            this.howToPlay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.howToPlay.Visible = false;
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(590, 177);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(102, 35);
            this.back.TabIndex = 1;
            this.back.Text = "ZPĚT";
            this.back.UseVisualStyleBackColor = true;
            this.back.Visible = false;
            this.back.Click += new System.EventHandler(this.howToPlay_hide);
            // 
            // play
            // 
            this.play.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play.Location = new System.Drawing.Point(226, 176);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(267, 63);
            this.play.TabIndex = 2;
            this.play.Text = "HRÁT";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.openStartDialog);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(155, 13);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(409, 97);
            this.title.TabIndex = 3;
            this.title.Text = "SUDOKU";
            // 
            // titleCopyright
            // 
            this.titleCopyright.AutoSize = true;
            this.titleCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleCopyright.Location = new System.Drawing.Point(371, 110);
            this.titleCopyright.Name = "titleCopyright";
            this.titleCopyright.Size = new System.Drawing.Size(163, 20);
            this.titleCopyright.TabIndex = 4;
            this.titleCopyright.Text = "by Ondřej Wrzecionko";
            // 
            // showHowToPlay
            // 
            this.showHowToPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showHowToPlay.Location = new System.Drawing.Point(226, 245);
            this.showHowToPlay.Name = "showHowToPlay";
            this.showHowToPlay.Size = new System.Drawing.Size(267, 63);
            this.showHowToPlay.TabIndex = 5;
            this.showHowToPlay.Text = "PRINCIP HRY";
            this.showHowToPlay.UseVisualStyleBackColor = true;
            this.showHowToPlay.Click += new System.EventHandler(this.howToPlay_show);
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(590, 354);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(102, 35);
            this.close.TabIndex = 6;
            this.close.Text = "ZAVŘÍT";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.closeGame);
            // 
            // IntroductionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 401);
            this.Controls.Add(this.close);
            this.Controls.Add(this.showHowToPlay);
            this.Controls.Add(this.titleCopyright);
            this.Controls.Add(this.title);
            this.Controls.Add(this.play);
            this.Controls.Add(this.back);
            this.Controls.Add(this.howToPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IntroductionForm";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label howToPlay;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label titleCopyright;
        private System.Windows.Forms.Button showHowToPlay;
        private System.Windows.Forms.Button close;
    }
}