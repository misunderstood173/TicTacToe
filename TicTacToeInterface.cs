using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{

    public partial class TicTacToeInterface : Form
    {
        int boardSize = 3;
        TicTacToeGame game;
        Label[,] board;
        public TicTacToeInterface()
        {
            InitializeComponent();

            game = new TicTacToeGame(boardSize);
            InitWindow();
            CreateCells();
            labelNowMoving.Text = "Now moving: " + game.CurrentPlayer.Sign;
        }

        private void InitWindow()
        {
            labelBoardSize.Location = new Point(boardSize * 120 + 60, 20);
            labelHowManyInARow.Location = new Point(boardSize * 120 + 60, 42);
            labelFirstPlayer.Location = new Point(boardSize * 120 + 60, 64);
            numericBoardSize.Location = new Point(boardSize * 120 + 60 + labelFirstPlayer.Width + 10, 16);
            numericHowManyInARow.Location = new Point(boardSize * 120 + 60 + labelFirstPlayer.Width + 10, 38);
            numericFirstPlayer.Location = new Point(boardSize * 120 + 60 + labelFirstPlayer.Width + 10, 60);
            buttonNewGame.Location = new Point(boardSize * 120 + 60, 80);
            labelNowMoving.Location = new Point(boardSize * 120 + 60, 150);
            labelPlayer1Score.Location = new Point(boardSize * 120 + 60, 200);
            labelPlayer2Score.Location = new Point(boardSize * 120 + 60, 220);

            UpdateScore();

            this.Size = new Size(boardSize * 120 + buttonNewGame.Width + labelFirstPlayer.Width + numericFirstPlayer.Width + 10,
                                 boardSize * 120 + 55);
        }

        private void UpdateScore()
        {
            labelPlayer1Score.Text = game.Player1.Sign + " : " + game.Player1.Score;
            labelPlayer2Score.Text = game.Player2.Sign + " : " + game.Player2.Score;
        }

        private void CreateCells()
        {
            board = new Label[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
                for(int j = 0; j < boardSize; j++) 
                {
                    board[i, j] = new Label();
                    board[i, j].BackColor = SystemColors.ControlDarkDark;
                    board[i, j].Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    board[i, j].Location = new Point(10 + 120 * j, 10 + 120 * i);
                    board[i, j].Name = "label" + "r" + i + "c" + j;
                    board[i, j].Size = new Size(115, 115);
                    board[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    board[i, j].Click += cellClicked;
                    this.Controls.Add(board[i, j]);
                }
        }

        void cellClicked(object sender, EventArgs e)   
        {
            Label lbl = (Label)sender;
            String cellName = lbl.Name;        //cellName = labelr<row>c<column>

            int row = Convert.ToInt16(cellName.Substring(cellName.IndexOf('r') + 1, cellName.IndexOf('c') - cellName.IndexOf('r') - 1));
            int column = Convert.ToInt16(cellName.Substring(cellName.IndexOf('c') + 1, cellName.Length - cellName.IndexOf('c') - 1));
            if (!game.gameEnded())
            {
                if(game.isEmptyCell(row, column))
                    lbl.Text = game.CurrentPlayer.Sign;
                game.Act(row, column);
                labelNowMoving.Text = "Now moving: " + game.CurrentPlayer.Sign;
            }

            if (game.gameEnded())
            {
                UpdateScore();
                ShowWinningCells();
                ShowWinner();
            }
            else if (game.isDraw())
                ShowDraw();
        }

        private void ShowWinningCells()
        {
            foreach (Tuple<int,int> cell in game.WinningCells)
            {
                board[cell.Item1, cell.Item2].BackColor = SystemColors.ControlLight;
            }
        }

        private void ShowWinner()
        {
            labelNowMoving.Text = "Winner: " + game.Winner.Sign;
            MessageBox.Show(game.Winner.Sign + " won");
        }

        private void ShowDraw()
        {
            labelNowMoving.Text = "No winner :(";
            MessageBox.Show("Draw");
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            int firstPlayerID = Convert.ToInt16(numericFirstPlayer.Value);
            int boardSize = Convert.ToInt16(numericBoardSize.Value);
            int howManyInARow = Convert.ToInt16(numericHowManyInARow.Value);
            game.Play(boardSize, (Type)firstPlayerID, howManyInARow);
            labelNowMoving.Text = "Now moving: " + game.CurrentPlayer.Sign;

            DisposeCells();
            this.boardSize = boardSize;
            InitWindow();
            CreateCells();
        }
        private void DisposeCells()
        {
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    board[i, j].Dispose();
        }

        private void numericHowManyInARow_ValueChanged(object sender, EventArgs e)
        {
            if (numericHowManyInARow.Value > numericBoardSize.Value)
                numericHowManyInARow.Value = numericBoardSize.Value;
        }

        private void numericBoardSize_ValueChanged(object sender, EventArgs e)
        {
            numericHowManyInARow_ValueChanged(sender, e);
        }
    }
}
