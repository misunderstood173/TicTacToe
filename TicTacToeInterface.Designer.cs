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
            this.labelNowMoving = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.checkPlayAgainstComputer = new System.Windows.Forms.CheckBox();
            this.buttonPlayAgain = new System.Windows.Forms.Button();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.labelIP = new System.Windows.Forms.Label();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.numericFirstPlayer)).BeginInit();
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
            // checkPlayAgainstComputer
            // 
            this.checkPlayAgainstComputer.AutoSize = true;
            this.checkPlayAgainstComputer.Location = new System.Drawing.Point(429, 48);
            this.checkPlayAgainstComputer.Name = "checkPlayAgainstComputer";
            this.checkPlayAgainstComputer.Size = new System.Drawing.Size(139, 17);
            this.checkPlayAgainstComputer.TabIndex = 4;
            this.checkPlayAgainstComputer.Text = "Play against computer ?";
            this.checkPlayAgainstComputer.UseVisualStyleBackColor = true;
            // 
            // buttonPlayAgain
            // 
            this.buttonPlayAgain.Location = new System.Drawing.Point(429, 142);
            this.buttonPlayAgain.Name = "buttonPlayAgain";
            this.buttonPlayAgain.Size = new System.Drawing.Size(138, 23);
            this.buttonPlayAgain.TabIndex = 5;
            this.buttonPlayAgain.Text = "Play Again";
            this.buttonPlayAgain.UseVisualStyleBackColor = true;
            this.buttonPlayAgain.Click += new System.EventHandler(this.buttonPlayAgain_Click);
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(431, 276);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(138, 23);
            this.buttonStartServer.TabIndex = 6;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(428, 331);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(17, 13);
            this.labelIP.TabIndex = 7;
            this.labelIP.Text = "IP";
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(451, 328);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(116, 20);
            this.textBoxIPAddress.TabIndex = 8;
            this.textBoxIPAddress.Text = "localhost";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(431, 354);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(136, 23);
            this.buttonConnect.TabIndex = 9;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // TicTacToeInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 387);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxIPAddress);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.buttonPlayAgain);
            this.Controls.Add(this.checkPlayAgainstComputer);
            this.Controls.Add(this.numericFirstPlayer);
            this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer1Score);
            this.Controls.Add(this.labelNowMoving);
            this.Controls.Add(this.labelFirstPlayer);
            this.Controls.Add(this.buttonNewGame);
            this.Name = "TicTacToeInterface";
            this.Text = "TicTacToe Game";
            ((System.ComponentModel.ISupportInitialize)(this.numericFirstPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Label labelFirstPlayer;
        private System.Windows.Forms.NumericUpDown numericFirstPlayer;
        private System.Windows.Forms.Label labelNowMoving;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer2Score;
        private System.Windows.Forms.CheckBox checkPlayAgainstComputer;
        private System.Windows.Forms.Button buttonPlayAgain;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Button buttonConnect;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

