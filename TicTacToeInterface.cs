using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{

    public partial class TicTacToeInterface : Form
    {
        int boardSize = 19;
        int howManyInARow = 5;
        int cellSize = 40;
        int spaceBetweenCells = 1;
        TicTacToeGame game;
        Label[,] board;

        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string received;
        public string textToSend;
        int port = 1234;

        bool isConnected = false;
        bool isClient = false;

        public TicTacToeInterface()
        {
            InitializeComponent();

            game = new TicTacToeGame(boardSize, Type.player1, Type.player2, 1, howManyInARow);
            InitWindow();
            CreateCells();
            labelNowMoving.Text = "Now moving: " + game.CurrentPlayer.Sign;
        }

        private void InitWindow()
        {
            checkPlayAgainstComputer.Location = new Point(boardSize * cellSize + 60, 35);
            labelFirstPlayer.Location = new Point(boardSize * cellSize + 60, 64);
            numericFirstPlayer.Location = new Point(boardSize * cellSize + 60 + labelFirstPlayer.Width + 10, 60);
            buttonNewGame.Location = new Point(boardSize * cellSize + 60, 80);
            buttonPlayAgain.Location = new Point(boardSize * cellSize + 60, 105);
            labelNowMoving.Location = new Point(boardSize * cellSize + 60, 150);
            labelPlayer1Score.Location = new Point(boardSize * cellSize + 60, 200);
            labelPlayer2Score.Location = new Point(boardSize * cellSize + 60, 220);

            buttonStartServer.Location = new Point(boardSize * cellSize + 60, 620);
            labelIP.Location = new Point(boardSize * cellSize + 60, 705);
            textBoxIPAddress.Location = new Point(boardSize * cellSize + 80, 700);
            buttonConnect.Location = new Point(boardSize * cellSize + 60, 725);

            UpdateScore();

            this.Size = new Size(boardSize * cellSize + buttonNewGame.Width + labelFirstPlayer.Width + numericFirstPlayer.Width + 10,
                                 boardSize * cellSize + 55);
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
                for (int j = 0; j < boardSize; j++)
                {
                    board[i, j] = new Label();
                    board[i, j].BackColor = SystemColors.ControlDarkDark;
                    board[i, j].Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    board[i, j].Location = new Point(10 + cellSize * j, 10 + cellSize * i);
                    board[i, j].Name = "label" + "r" + i + "c" + j;
                    board[i, j].Size = new Size(cellSize - spaceBetweenCells, cellSize - spaceBetweenCells);
                    board[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    board[i, j].Click += cellClicked;
                    this.Controls.Add(board[i, j]);
                }
        }

        void cellClicked(object sender, EventArgs e)
        {
            if (!isConnected ||
                isConnected && ((isClient && game.CurrentPlayer.Type == Type.player2) || (!isClient && game.CurrentPlayer.Type == Type.player1)))
            {
                Label lbl = (Label)sender;
                String cellName = lbl.Name;        //cellName = labelr<row>c<column>

                int row = Convert.ToInt16(cellName.Substring(cellName.IndexOf('r') + 1, cellName.IndexOf('c') - cellName.IndexOf('r') - 1));
                int column = Convert.ToInt16(cellName.Substring(cellName.IndexOf('c') + 1, cellName.Length - cellName.IndexOf('c') - 1));

                if (isConnected && !game.gameEnded())
                    SendMessage(cellName);

                PerformMove(row, column);

                if (game.CurrentPlayer.Type == Type.computer && !game.gameEnded())
                {
                    Tuple<int, int> move = game.getComputerMove();
                    PerformMove(move.Item1, move.Item2);
                }
            }

        }

        void PerformMove(int row, int column)
        {
            if (!game.gameEnded())
            {
                if (game.isEmptyCell(row, column))
                {
                    Label lbl = board[row, column];
                    switch (game.CurrentPlayer.Sign)
                    {
                        case "BLACK":
                            lbl.Image = Image.FromFile("black.png");
                            break;
                        case "WHITE":
                            lbl.Image = Image.FromFile("white.png");
                            break;

                        default:
                            lbl.Text = game.CurrentPlayer.Sign;
                            break;
                    }
                    ;
                }
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
            foreach (Tuple<int, int> cell in game.WinningCells)
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
            Type player2 = Type.player2;
            if (checkPlayAgainstComputer.Checked)
                player2 = Type.computer;
            game = new TicTacToeGame(boardSize, Type.player1, player2, firstPlayerID, howManyInARow);
            labelNowMoving.Text = "Now moving: " + game.CurrentPlayer.Sign;


            DisposeCells();
            InitWindow();
            CreateCells();


            if (game.CurrentPlayer.Type == Type.computer)
            {
                Tuple<int, int> move = game.getComputerMove();
                PerformMove(move.Item1, move.Item2);
            }
        }
        private void DisposeCells()
        {
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    board[i, j].Dispose();
        }

        private void buttonPlayAgain_Click(object sender, EventArgs e)
        {
            int firstPlayerID = Convert.ToInt16(numericFirstPlayer.Value);
            game.Play(boardSize, firstPlayerID, howManyInARow);

            DisposeCells();
            InitWindow();
            CreateCells();

            if (game.CurrentPlayer.Type == Type.computer)
            {
                Tuple<int, int> move = game.getComputerMove();
                PerformMove(move.Item1, move.Item2);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    received = STR.ReadLine();
                    string cellName = received;
                    int row = Convert.ToInt16(cellName.Substring(cellName.IndexOf('r') + 1, cellName.IndexOf('c') - cellName.IndexOf('r') - 1));
                    int column = Convert.ToInt16(cellName.Substring(cellName.IndexOf('c') + 1, cellName.Length - cellName.IndexOf('c') - 1));

                    PerformMove(row, column);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            client = listener.AcceptTcpClient();
            MessageBox.Show("Client connected. You are 'BLACK'");
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();

            isConnected = true;
            isClient = false;


            game = new TicTacToeGame(boardSize, Type.player1, Type.player2, 1, howManyInARow);
            labelNowMoving.Text = "Now moving: " + game.CurrentPlayer.Sign;

            DisposeCells();
            InitWindow();
            CreateCells();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            string ip = textBoxIPAddress.Text;
            if (ip.ToLower() == "localhost")
                ip = "127.0.0.1";
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ip), port);
            try
            {
                client.Connect(IpEnd);
                if (client.Connected)
                {
                    MessageBox.Show("Connected to server. You are 'WHITE'");
                    STR = new StreamReader(client.GetStream());
                    STW = new StreamWriter(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();

                    isConnected = true;
                    isClient = true;

                    game = new TicTacToeGame(boardSize, Type.player1, Type.player2, 1, howManyInARow);
                    labelNowMoving.Text = "Now moving: " + game.CurrentPlayer.Sign;

                    DisposeCells();
                    InitWindow();
                    CreateCells();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SendMessage(string message)
        {
            STW.WriteLine(message);
        }
    }
}
