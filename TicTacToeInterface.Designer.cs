namespace TicTacToe
{
    partial class TicTacToeInterface
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
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.labelFirstPlayer = new System.Windows.Forms.Label();
            this.numericFirstPlayer = new System.Windows.Forms.NumericUpDown();
            this.labelHowManyInARow = new System.Windows.Forms.Label();
            this.numericHowManyInARow = new System.Windows.Forms.NumericUpDown();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.numericBoardSize = new System.Windows.Forms.NumericUpDown();
            this.labelNowMoving = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericFirstPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHowManyInARow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoardSize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(429, 102);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(138, 23);
            this.buttonNewGame.TabIndex = 1;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // labelFirstPlayer
            // 
            this.labelFirstPlayer.AutoSize = true;
            this.labelFirstPlayer.Location = new System.Drawing.Point(426, 78);
            this.labelFirstPlayer.Name = "labelFirstPlayer";
            this.labelFirstPlayer.Size = new System.Drawing.Size(90, 13);
            this.labelFirstPlayer.TabIndex = 2;
            this.labelFirstPlayer.Text = "First Player (1 | 2):";
            this.labelFirstPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericFirstPlayer
            // 
            this.numericFirstPlayer.Location = new System.Drawing.Point(533, 76);
            this.numericFirstPlayer.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericFirstPlayer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericFirstPlayer.Name = "numericFirstPlayer";
            this.numericFirstPlayer.Size = new System.Drawing.Size(34, 20);
            this.numericFirstPlayer.TabIndex = 3;
            this.numericFirstPlayer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelHowManyInARow
            // 
            this.labelHowManyInARow.AutoSize = true;
            this.labelHowManyInARow.Location = new System.Drawing.Point(426, 52);
            this.labelHowManyInARow.Name = "labelHowManyInARow";
            this.labelHowManyInARow.Size = new System.Drawing.Size(100, 13);
            this.labelHowManyInARow.TabIndex = 2;
            this.labelHowManyInARow.Text = "How many in a row:";
            this.labelHowManyInARow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericHowManyInARow
            // 
            this.numericHowManyInARow.Location = new System.Drawing.Point(533, 50);
            this.numericHowManyInARow.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericHowManyInARow.Name = "numericHowManyInARow";
            this.numericHowManyInARow.Size = new System.Drawing.Size(34, 20);
            this.numericHowManyInARow.TabIndex = 3;
            this.numericHowManyInARow.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericHowManyInARow.ValueChanged += new System.EventHandler(this.numericHowManyInARow_ValueChanged);
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(426, 26);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(61, 13);
            this.labelBoardSize.TabIndex = 2;
            this.labelBoardSize.Text = "Board Size:";
            this.labelBoardSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericBoardSize
            // 
            this.numericBoardSize.Location = new System.Drawing.Point(533, 24);
            this.numericBoardSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBoardSize.Name = "numericBoardSize";
            this.numericBoardSize.Size = new System.Drawing.Size(34, 20);
            this.numericBoardSize.TabIndex = 3;
            this.numericBoardSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBoardSize.ValueChanged += new System.EventHandler(this.numericBoardSize_ValueChanged);
            // 
            // labelNowMoving
            // 
            this.labelNowMoving.AutoSize = true;
            this.labelNowMoving.Location = new System.Drawing.Point(426, 174);
            this.labelNowMoving.Name = "labelNowMoving";
            this.labelNowMoving.Size = new System.Drawing.Size(69, 13);
            this.labelNowMoving.TabIndex = 2;
            this.labelNowMoving.Text = "Now moving:";
            this.labelNowMoving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Location = new System.Drawing.Point(426, 209);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(44, 13);
            this.labelPlayer1Score.TabIndex = 2;
            this.labelPlayer1Score.Text = "player1:";
            this.labelPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Location = new System.Drawing.Point(426, 223);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(44, 13);
            this.labelPlayer2Score.TabIndex = 2;
            this.labelPlayer2Score.Text = "player2:";
            this.labelPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TicTacToeInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 378);
            this.Controls.Add(this.numericBoardSize);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.numericHowManyInARow);
            this.Controls.Add(this.labelHowManyInARow);
            this.Controls.Add(this.numericFirstPlayer);
            this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer1Score);
            this.Controls.Add(this.labelNowMoving);
            this.Controls.Add(this.labelFirstPlayer);
            this.Controls.Add(this.buttonNewGame);
            this.Name = "TicTacToeInterface";
            this.Text = "TicTacToe Game";
            ((System.ComponentModel.ISupportInitialize)(this.numericFirstPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHowManyInARow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoardSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Label labelFirstPlayer;
        private System.Windows.Forms.NumericUpDown numericFirstPlayer;
        private System.Windows.Forms.Label labelHowManyInARow;
        private System.Windows.Forms.NumericUpDown numericHowManyInARow;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.NumericUpDown numericBoardSize;
        private System.Windows.Forms.Label labelNowMoving;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer2Score;
    }
}

