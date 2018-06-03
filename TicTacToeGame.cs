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
        private Type[,] boardForAI;
        private Player currentPlayer;
        private Player player1;
        private Player player2;
        private int aiMoveCheck = 400;
        private int depth = 2;

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
        public TicTacToeGame(int boardSize = 3, Type player1Type = Type.player1, Type player2Type = Type.player2, 
            int firstPlayer = 1, int howManyInARow = 3,
            String player1Sign = "BLACK", String player2Sign = "WHITE")
        {
            player1 = new Player(player1Type, player1Sign);
            player2 = new Player(player2Type, player2Sign);
            Play(boardSize, firstPlayer, howManyInARow);
        }

        public void Play(int boardSize = 3, int firstPlayer = 1, int howManyInARow = 3)
        {
            this.boardSize = boardSize;
            this.howManyInARow = howManyInARow;
            winner = new Player(Type.noValue);
            winningCells = new List<Tuple<int, int>>();
            board = new Type[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    board[i, j] = Type.noValue;

            currentPlayer = (firstPlayer == 1) ? player1 : player2;
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
            if (playerType == player1.Type) return player1;
            if (playerType == player2.Type) return player2;
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

        public Tuple<int, int> getComputerMove()
        {

            Random rnd = new Random();
            int row, column;
            do
            {
                row = rnd.Next(0, boardSize);
                column = rnd.Next(0, boardSize);
            } while (board[row, column] != Type.noValue);

            //return new Tuple<int, int>(row, column);

            boardForAI = new Type[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    boardForAI[i, j] = board[i, j];

            analyzeGomoku(Type.computer);
            var result = bestGomokuMove(true, depth);
            Console.WriteLine("best move: x = " + result.Item1 + "  y = " + result.Item2);
            return new Tuple<int, int>(result.Item1, result.Item2);
        }

        private double analyzeGomoku(Type analysedTurn)
        {
            Type theOtherOne = analysedTurn == Type.computer ? Type.player1 : Type.computer;
            double result = analyzeHorizontalSetsForPlayer(Type.computer, analysedTurn);
            result = result - analyzeHorizontalSetsForPlayer(Type.player1, theOtherOne);
            result = result + analyzeVerticalSetsForPlayer(Type.computer, analysedTurn);
            result = result - analyzeVerticalSetsForPlayer(Type.player1, theOtherOne);
            result = result + analyzeFirstDiagonalSetsForPlayer(Type.computer, analysedTurn);
            result = result - analyzeFirstDiagonalSetsForPlayer(Type.player1, theOtherOne);
            result = result + analyzeSecondDiagonalSetsForPlayer(Type.computer, analysedTurn);
            result = result - analyzeSecondDiagonalSetsForPlayer(Type.player1, theOtherOne);
            Console.WriteLine(result);
            return result;
        }

        private double analyzeHorizontalSetsForPlayer(Type playerToCheck, Type current_turn)
        {
            double score = 0;
            int countConsecutive = 0;
            int openEnds = 0;
            
            for (int i = 0; i < boardSize; i++)
            {
                for (int a = 0; a < boardSize; a++)
                {
                    if (boardForAI[i,a] == playerToCheck)
                        countConsecutive++;
                    else if (boardForAI[i,a] == Type.noValue && countConsecutive > 0)
                    {
                        openEnds++;
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 1;
                    }
                    else if (boardForAI[i,a] == Type.noValue)
                        openEnds = 1;
                    else if (countConsecutive > 0)
                    {
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 0;
                    }
                    else openEnds = 0;
                }
                if (countConsecutive > 0)
                    score += gomokuShapeScore(countConsecutive,
                        openEnds, current_turn == playerToCheck);
                countConsecutive = 0;
                openEnds = 0;
            }
            return score;
        }

        private double analyzeVerticalSetsForPlayer(Type playerToCheck, Type current_turn)
        {
            double score = 0;
            int countConsecutive = 0;
            int openEnds = 0;

            for (int i = 0; i < boardSize; i++)
            {
                for (int a = 0; a < boardSize; a++)
                {
                    if (boardForAI[a, i] == playerToCheck)
                        countConsecutive++;
                    else if (boardForAI[a, i] == Type.noValue && countConsecutive > 0)
                    {
                        openEnds++;
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 1;
                    }
                    else if (boardForAI[a, i] == Type.noValue)
                        openEnds = 1;
                    else if (countConsecutive > 0)
                    {
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 0;
                    }
                    else openEnds = 0;
                }
                if (countConsecutive > 0)
                    score += gomokuShapeScore(countConsecutive,
                        openEnds, current_turn == playerToCheck);
                countConsecutive = 0;
                openEnds = 0;
            }
            return score;
        }

        private double analyzeFirstDiagonalSetsForPlayer(Type playerToCheck, Type current_turn)
        {
            double score = 0;
            int countConsecutive = 0;
            int openEnds = 0;

            for (int i = 0; i < boardSize; i++)
            {
                for (int a = 0; a + i < boardSize; a++)
                {
                    if (boardForAI[a, i + a] == playerToCheck)
                        countConsecutive++;
                    else if (boardForAI[a, i + a] == Type.noValue && countConsecutive > 0)
                    {
                        openEnds++;
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 1;
                    }
                    else if (boardForAI[a, i + a] == Type.noValue)
                        openEnds = 1;
                    else if (countConsecutive > 0)
                    {
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 0;
                    }
                    else openEnds = 0;
                }
                if (countConsecutive > 0)
                    score += gomokuShapeScore(countConsecutive,
                        openEnds, current_turn == playerToCheck);
                countConsecutive = 0;
                openEnds = 0;
            }

            for (int i = 0; i < boardSize; i++)
            {
                for (int a = 0; a + i < boardSize; a++)
                {
                    if (boardForAI[a + i, a] == playerToCheck)
                        countConsecutive++;
                    else if (boardForAI[a + i, a] == Type.noValue && countConsecutive > 0)
                    {
                        openEnds++;
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 1;
                    }
                    else if (boardForAI[a + i, a] == Type.noValue)
                        openEnds = 1;
                    else if (countConsecutive > 0)
                    {
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 0;
                    }
                    else openEnds = 0;
                }
                if (countConsecutive > 0)
                    score += gomokuShapeScore(countConsecutive,
                        openEnds, current_turn == playerToCheck);
                countConsecutive = 0;
                openEnds = 0;
            }

            return score;
        }

        private double analyzeSecondDiagonalSetsForPlayer(Type playerToCheck, Type current_turn)
        {
            double score = 0;
            int countConsecutive = 0;
            int openEnds = 0;

            for (int i = boardSize - 1; i >= 0; i--)
            {
                for (int a = 0; i - a >= 0; a++)
                {
                    if (boardForAI[a, i - a] == playerToCheck)
                        countConsecutive++;
                    else if (boardForAI[a, i - a] == Type.noValue && countConsecutive > 0)
                    {
                        openEnds++;
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 1;
                    }
                    else if (boardForAI[a, i - a] == Type.noValue)
                        openEnds = 1;
                    else if (countConsecutive > 0)
                    {
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 0;
                    }
                    else openEnds = 0;
                }
                if (countConsecutive > 0)
                    score += gomokuShapeScore(countConsecutive,
                        openEnds, current_turn == playerToCheck);
                countConsecutive = 0;
                openEnds = 0;
            }

            for (int i = boardSize - 1; i >= 0; i--)
            {
                for (int a = 0; boardSize - 1 - i + a < boardSize; a++)
                {
                    if (boardForAI[boardSize - a - 1, boardSize - 1 - i + a] == playerToCheck)
                        countConsecutive++;
                    else if (boardForAI[boardSize - a - 1, boardSize - 1 - i + a] == Type.noValue && countConsecutive > 0)
                    {
                        openEnds++;
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 1;
                    }
                    else if (boardForAI[boardSize - a - 1, boardSize - 1 - i + a] == Type.noValue)
                        openEnds = 1;
                    else if (countConsecutive > 0)
                    {
                        score += gomokuShapeScore(countConsecutive,
                            openEnds, current_turn == playerToCheck);
                        countConsecutive = 0;
                        openEnds = 0;
                    }
                    else openEnds = 0;
                }
                if (countConsecutive > 0)
                    score += gomokuShapeScore(countConsecutive,
                        openEnds, current_turn == playerToCheck);
                countConsecutive = 0;
                openEnds = 0;
            }

            return score;
        }

        private double gomokuShapeScore(int consecutive, int openEnds, bool currentTurn)
        {
            if (openEnds == 0 && consecutive < 5)
                return 0;
            switch (consecutive)
            {
                case 4:
                    switch (openEnds)
                    {
                        case 1:
                            if (currentTurn)
                                return 100000000;
                            return 50;
                        case 2:
                            if (currentTurn)
                                return 100000000;
                            return 500000;
                    }
                    break;
                case 3:
                    switch (openEnds)
                    {
                        case 1:
                            if (currentTurn)
                                return 7;
                            return 5;
                        case 2:
                            if (currentTurn)
                                return 10000;
                            return 50;
                    }
                    break;
                case 2:
                    switch (openEnds)
                    {
                        case 1:
                            return 2;
                        case 2:
                            return 5;
                    }
                    break;
                case 1:
                    switch (openEnds)
                    {
                        case 1:
                            return 0.5;
                        case 2:
                            return 1;
                    }
                    break;
                default:
                    return 200000000;
            }
            Console.WriteLine("fell through -> score 0");
            return 0;
        }

        private Tuple<int, int, double> bestGomokuMove(bool oTurn, int depth)
        {
            Type color = oTurn ? Type.computer : Type.player1;
            int xBest = -1, yBest = -1;
            double bestScore = oTurn ? -1000000000 : 1000000000;
            double analysis;
            bool analysedTurn = depth % 2 == 0 ? oTurn : !oTurn;
            Tuple<int, int>[] moves = Get_moves();

            for (int i = moves.Length - 1; i > moves.Length - aiMoveCheck - 1
                && i >= 0; i--)
            {
                boardForAI[moves[i].Item1, moves[i].Item2] = color;
                if (depth == 1)
                    analysis = analyzeGomoku(color);
                else
                {
                    analysis = bestGomokuMove(!oTurn, depth - 1).Item3;
                }
                boardForAI[moves[i].Item1, moves[i].Item2] = Type.noValue;
                if ((analysis > bestScore && oTurn) ||
                    (analysis < bestScore && !oTurn))
                {
                    bestScore = analysis;
                    xBest = moves[i].Item1;
                    yBest = moves[i].Item2;
                }
            }

            return new Tuple<int, int, double>(xBest, yBest, bestScore);
        }

        public Tuple<int, int>[] Get_moves()
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (boardForAI[i,j] == Type.noValue)
                    { 
                        moves.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            return moves.ToArray();
        }
    }
}
