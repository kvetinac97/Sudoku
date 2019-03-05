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
            this.stepBack = new System.Windows.Forms.Button();
            this.stepForward = new System.Windows.Forms.Button();
            this.autoSolveButton = new System.Windows.Forms.Button();
            this.endGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sudokuBoard
            // 
            this.sudokuBoard.ColumnCount = 3;
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.Location = new System.Drawing.Point(34, 23);
            this.sudokuBoard.Margin = new System.Windows.Forms.Padding(6);
            this.sudokuBoard.Name = "sudokuBoard";
            this.sudokuBoard.RowCount = 3;
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sudokuBoard.Size = new System.Drawing.Size(748, 715);
            this.sudokuBoard.TabIndex = 0;
            this.sudokuBoard.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.SudokuBoard_CellPaint);
            // 
            // stepBack
            // 
            this.stepBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepBack.Location = new System.Drawing.Point(838, 140);
            this.stepBack.Margin = new System.Windows.Forms.Padding(6);
            this.stepBack.Name = "stepBack";
            this.stepBack.Size = new System.Drawing.Size(528, 65);
            this.stepBack.TabIndex = 3;
            this.stepBack.Text = "ZPĚT";
            this.stepBack.UseVisualStyleBackColor = true;
            this.stepBack.Click += new System.EventHandler(this.StepBack);
            this.stepBack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KlavesaStisknuta);
            // 
            // stepForward
            // 
            this.stepForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepForward.Location = new System.Drawing.Point(838, 217);
            this.stepForward.Margin = new System.Windows.Forms.Padding(6);
            this.stepForward.Name = "stepForward";
            this.stepForward.Size = new System.Drawing.Size(528, 62);
            this.stepForward.TabIndex = 4;
            this.stepForward.Text = "DALŠÍ";
            this.stepForward.UseVisualStyleBackColor = true;
            this.stepForward.Click += new System.EventHandler(this.StepForward);
            this.stepForward.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KlavesaStisknuta);
            // 
            // autoSolveButton
            // 
            this.autoSolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoSolveButton.Location = new System.Drawing.Point(838, 398);
            this.autoSolveButton.Margin = new System.Windows.Forms.Padding(6);
            this.autoSolveButton.Name = "autoSolveButton";
            this.autoSolveButton.Size = new System.Drawing.Size(528, 73);
            this.autoSolveButton.TabIndex = 6;
            this.autoSolveButton.Text = "ZPĚT K VÝBĚRU";
            this.autoSolveButton.UseVisualStyleBackColor = true;
            this.autoSolveButton.Click += new System.EventHandler(this.ClickCloseGameForm);
            this.autoSolveButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KlavesaStisknuta);
            // 
            // endGameButton
            // 
            this.endGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endGameButton.Location = new System.Drawing.Point(838, 483);
            this.endGameButton.Margin = new System.Windows.Forms.Padding(6);
            this.endGameButton.Name = "endGameButton";
            this.endGameButton.Size = new System.Drawing.Size(528, 73);
            this.endGameButton.TabIndex = 7;
            this.endGameButton.Text = "ZAVŘÍT HRU";
            this.endGameButton.UseVisualStyleBackColor = true;
            this.endGameButton.Click += new System.EventHandler(this.CloseGameForm);
            this.endGameButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KlavesaStisknuta);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(834, 313);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 44);
            this.label1.TabIndex = 8;
            this.label1.Text = "––––––––––––––––––––––––––––––––";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 771);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endGameButton);
            this.Controls.Add(this.autoSolveButton);
            this.Controls.Add(this.stepForward);
            this.Controls.Add(this.stepBack);
            this.Controls.Add(this.sudokuBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseGameForm);
            this.Load += new System.EventHandler(this.SudokuApp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KlavesaStisknuta);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel sudokuBoard;
        private System.Windows.Forms.Button stepBack;
        private System.Windows.Forms.Button stepForward;
        private System.Windows.Forms.Button autoSolveButton;
        private System.Windows.Forms.Button endGameButton;
        private System.Windows.Forms.Label label1;
    }
}

