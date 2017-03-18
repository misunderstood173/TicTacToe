using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace TicTacToe
{
    class TicTacToeGame
    {
        int boardSize;
        int howManyInARow;
        Player winner;
        List<Tuple<int, int>> winningCells;
        private Type[,] board;
        private Player currentPlayer;
        private Player player1;
        private Player player2;

        public Player CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }
        }
        public Player Player1
        {
            get
            {
                return player1;
            }
        }
        public Player Player2
        {
            get
            {
                return player2;
            }
        }
        public Player Winner
        {
            get
            {
                return winner;
            }
        }
        public List<Tuple<int, int>> WinningCells
        {
            get
            {
                return winningCells;
            }
        }

        public Type playerAt(int row, int column)
        {
            return board[row, column];
         }
        public TicTacToeGame(int boardSize = 3, Type firstPlayer = Type.player1, int howManyInARow = 3,
            String player1Sign = "X", String player2Sign = "O")
        {
            player1 = new Player(Type.player1, player1Sign);
            player2 = new Player(Type.player2, player2Sign);
            Play(boardSize, firstPlayer, howManyInARow);
        }

        public void Play(int boardSize = 3, Type firstPlayer = Type.player1, int howManyInARow = 3)
        {
            this.boardSize = boardSize;
            this.howManyInARow = howManyInARow;
            winner = new Player(Type.noValue);
            winningCells = new List<Tuple<int, int>>();
            board = new Type[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    board[i, j] = Type.noValue;

            currentPlayer = (firstPlayer == Type.player2) ? player2 : player1;
        }

        private Type winnerType(int row, int column)
        {
            if (rowWinner(row) != Type.noValue) return rowWinner(row);

            if (columnWinner(column) != Type.noValue) return columnWinner(column);

            if (firstDiagonalWinner(row, column) != Type.noValue) return firstDiagonalWinner(row, column);

            if (secondDiagonalWinner(row, column) != Type.noValue) return secondDiagonalWinner(row, column);

            return Type.noValue;
        }
        private Type rowWinner(int row)      
        {
            for (int i = 0; i < boardSize - howManyInARow + 1; i++)
            {
                Type winner = board[row, i];
                int counter = 1;
                for (int j = i + 1; j < i + howManyInARow; j++)
                {
                    if (winner == board[row, j])
                        counter++;
                }
                if (counter == howManyInARow && winner != Type.noValue)
                {
                    winningCells.Clear();
                    for (int j = i; j < boardSize && board[row, j] == board[row, i] ; j++)
                        winningCells.Add(Tuple.Create(row, j));
                    return winner;
                }
            }
            return Type.noValue;
        }
        private Type columnWinner(int column)      
        {
            for (int i = 0; i < boardSize - howManyInARow + 1; i++)
            {
                Type winner = board[i, column];
                int counter = 1;
                for (int j = i + 1; j < i + howManyInARow; j++)
                    if (winner == board[j, column])
                        counter++;
                if (counter == howManyInARow && winner != Type.noValue)
                {
                    winningCells.Clear();
                    for (int j = i; j < boardSize && board[j, column] == board[i, column]; j++)
                        winningCells.Add(Tuple.Create(j, column));
                    return winner;
                }
            }
            return Type.noValue;
        }
        private Type firstDiagonalWinner(int row, int column)      
        {
            if(row >= column)
            {
                row = row - column;
                column = 0;
            }
            else
            {
                column = column - row;
                row = 0;
            }
            for (int i = 0; i + Math.Max(row, column) < boardSize - howManyInARow + 1; i++)
            {
                Type winner = board[row + i, column + i];
                int counter = 1;
                for (int j = 1; j < howManyInARow; j++)
                    if (winner == board[row + i + j, column + i + j])
                        counter++;
                if (counter == howManyInARow && winner != Type.noValue)
                {
                    winningCells.Clear();
                    for (int j = 0; Math.Max(row + i + j, column + i + j) < boardSize
                        && board[row + i + j, column + i + j] == board[row + i, column + i]; j++)
                    {
                        winningCells.Add(Tuple.Create(row + i + j, column + i + j));
                    }
                    return winner;
                }
            }

            return Type.noValue;
        }
        private Type secondDiagonalWinner(int row, int column)    
        {
            int bias = 0;
            if (row + column > boardSize - 1)
            {
                row = row + column - boardSize + 1;
                column = boardSize - 1;
                bias = boardSize - row - howManyInARow + 1;
            }
            else
            {
                column = column + row;
                row = 0;
                bias = column + 1 - howManyInARow + 1;
            }
            for (int i = 0; i < bias; i++)
            {
                Type winner = board[row + i, column - i];
                int counter = 1;
                for (int j = 1; j < howManyInARow; j++)
                    if (winner == board[row + i + j, column - i - j])
                        counter++;
                if (counter == howManyInARow && winner != Type.noValue)
                {
                    winningCells.Clear();
                    for (int j = 0; row + i + j < boardSize && column - i - j >= 0
                        && board[row + i + j, column - i - j] == board[row + i, column - i]; j++)
                        winningCells.Add(Tuple.Create(row + i + j, column - i - j));
                    return winner;
                }
            }

            return Type.noValue;
        }

        public void Act(int row, int column)
        {
            if (row < 0 || row >= boardSize || column < 0 || column >= boardSize) return;
            if (!isEmptyCell(row, column)) return;
            if (gameEnded()) return;

            board[row, column] = CurrentPlayer.Type;
            winner = GetPlayerByType(winnerType(row, column));
            if (winner.Type != Type.noValue) winner.setScore(winner.Score + 1);
            nextPlayersTurn();
        }
        public Player GetPlayerByType(Type playerType)
        {
            if (playerType == Type.player1) return player1;
            if (playerType == Type.player2) return player2;
            else return new Player(Type.noValue);
        }
        public bool isEmptyCell(int row, int column)
        {   
            if (board[row, column] == Type.noValue)
                return true;
            return false;
        }
        public bool gameEnded()
        {
            if (winner.Type == Type.noValue)
                return false;
            return true;
        }
        public bool isDraw()
        {
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    if(board[i, j] == Type.noValue)
                        return false;
            return true;
        }
        private void nextPlayersTurn()
        {
            if (CurrentPlayer == player1) currentPlayer = player2;
            else if (CurrentPlayer == player2) currentPlayer = player1;
        }
    }
}
