namespace Sudoku
{
    partial class GameForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.sudokuBoard = new System.Windows.Forms.TableLayoutPanel();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeElapsed = new System.Windows.Forms.Label();
            this.stepBack = new System.Windows.Forms.Button();
            this.stepForward = new System.Windows.Forms.Button();
            this.hintButton = new System.Windows.Forms.Button();
            this.autoSolveButton = new System.Windows.Forms.Button();
            this.endGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sudokuBoard
            // 
            this.sudokuBoard.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.sudokuBoard.ColumnCount = 9;
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.sudokuBoard.Location = new System.Drawing.Point(17, 12);
            this.sudokuBoard.Name = "sudokuBoard";
            this.sudokuBoard.RowCount = 9;
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.sudokuBoard.Size = new System.Drawing.Size(374, 372);
            this.sudokuBoard.TabIndex = 0;
            this.sudokuBoard.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.sudokuBoard_CellPaint);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(414, 36);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(164, 25);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "Čas od spuštění: ";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timeElapsed
            // 
            this.timeElapsed.AutoSize = true;
            this.timeElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeElapsed.Location = new System.Drawing.Point(621, 36);
            this.timeElapsed.Name = "timeElapsed";
            this.timeElapsed.Size = new System.Drawing.Size(62, 25);
            this.timeElapsed.TabIndex = 2;
            this.timeElapsed.Text = "00:00";
            // 
            // stepBack
            // 
            this.stepBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepBack.Location = new System.Drawing.Point(419, 73);
            this.stepBack.Name = "stepBack";
            this.stepBack.Size = new System.Drawing.Size(264, 34);
            this.stepBack.TabIndex = 3;
            this.stepBack.Text = "ZPĚT";
            this.stepBack.UseVisualStyleBackColor = true;
            // 
            // stepForward
            // 
            this.stepForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepForward.Location = new System.Drawing.Point(419, 113);
            this.stepForward.Name = "stepForward";
            this.stepForward.Size = new System.Drawing.Size(264, 32);
            this.stepForward.TabIndex = 4;
            this.stepForward.Text = "DALŠÍ";
            this.stepForward.UseVisualStyleBackColor = true;
            // 
            // hintButton
            // 
            this.hintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintButton.Location = new System.Drawing.Point(419, 214);
            this.hintButton.Name = "hintButton";
            this.hintButton.Size = new System.Drawing.Size(264, 39);
            this.hintButton.TabIndex = 5;
            this.hintButton.Text = "NÁPOVĚDA";
            this.hintButton.UseVisualStyleBackColor = true;
            // 
            // autoSolveButton
            // 
            this.autoSolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoSolveButton.Location = new System.Drawing.Point(419, 260);
            this.autoSolveButton.Name = "autoSolveButton";
            this.autoSolveButton.Size = new System.Drawing.Size(264, 38);
            this.autoSolveButton.TabIndex = 6;
            this.autoSolveButton.Text = "UKÁZAT ŘEŠENÍ";
            this.autoSolveButton.UseVisualStyleBackColor = true;
            // 
            // endGameButton
            // 
            this.endGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endGameButton.Location = new System.Drawing.Point(419, 304);
            this.endGameButton.Name = "endGameButton";
            this.endGameButton.Size = new System.Drawing.Size(264, 38);
            this.endGameButton.TabIndex = 7;
            this.endGameButton.Text = "ZAVŘÍT HRU";
            this.endGameButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(417, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "––––––––––––––––––––––––––––––––";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 401);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endGameButton);
            this.Controls.Add(this.autoSolveButton);
            this.Controls.Add(this.hintButton);
            this.Controls.Add(this.stepForward);
            this.Controls.Add(this.stepBack);
            this.Controls.Add(this.timeElapsed);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.sudokuBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Hra - ";
            this.Load += new System.EventHandler(this.SudokuApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel sudokuBoard;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label timeElapsed;
        private System.Windows.Forms.Button stepBack;
        private System.Windows.Forms.Button stepForward;
        private System.Windows.Forms.Button hintButton;
        private System.Windows.Forms.Button autoSolveButton;
        private System.Windows.Forms.Button endGameButton;
        private System.Windows.Forms.Label label1;
    }
}

