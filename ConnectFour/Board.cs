
using System;

namespace ConnectFour
{
    class Board
    {
        public readonly int Rows = 9;
        public readonly int Columns = 10;
        public readonly Space[,] _board;
        public Player activePlayer { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public Board()
        {
            _board = new Space[Rows, Columns];
            PopulateBoardWithSpaces();
        }

        private void PopulateBoardWithSpaces()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    _board[r, c] = new Space();
                }
            }
        }

        public void DrawBoard(Space[,] board)
        {
            for (int row = 1; row <= 6; row++)
            {
                Console.Write("");
                for (int column = 1; column <= 7; column++)
                {
                    if (board[row, column].State == SpaceState.N
                    )
                    {
                        Console.Write("|_");
                    }
                    else
                    {
                        Console.Write("|{0}", board[row, column].State.ToString());
                    }
                }
                Console.Write("| \n");
            }
        }

        public void GetPlayerDetails()
        {
            Console.WriteLine("Player one, please enter your name: ");
            PlayerOne = new Player
            {
                playerName = Console.ReadLine(),
                discColour = SpaceState.R
            };
            Console.WriteLine("Player Two please enter your name: ");
            PlayerTwo = new Player
            {
                playerName = Console.ReadLine(),
                discColour = SpaceState.Y
            };
            Console.WriteLine("{0} is playing with red discs", PlayerOne.playerName);
            Console.WriteLine("{0} is playing with yellow discs", PlayerTwo.playerName);
            activePlayer = PlayerOne;
        }

        public void Play()
        {
            bool winner = false;
            int boardFull = 0;
            GetPlayerDetails();
            while (winner == false)
            {
                var ChosenColumn = GetChosenColumn();
                CheckNextAvailableRow(ChosenColumn);
                DrawBoard(_board);
                winner = CheckForWinner();
                boardFull = BoardFull();
                if (winner is true)
                {
                    PlayerWin();
                }
                if (boardFull == 7)
                {
                    BoardIsFull();
                }
                SwitchPlayer();
            }
        }

        public int BoardFull()
        {
            int counter = 0;
            for (int column = 1; column <= 7; column++)
            {
                if (_board[1,column].State != SpaceState.N)
                {
                    counter++;
                }
            }

            return counter;
        }

        private void BoardIsFull()
        {
            Console.WriteLine("Draw! Start game again");
        }

        private bool CheckForWinner()
        {
            var discPlayed = activePlayer.discColour;

            for (int row = 6; row >= 1; --row)
            {

                for (int column = 7; column >= 1; --column)
                {
                    if (discPlayed == SpaceState.N)
                    {
                        break;
                    }
                    //check down 
                    if (_board[row,column].State == discPlayed &&
                        _board[row + 1, column].State == discPlayed &&
                        _board[row + 2, column].State == discPlayed &&
                        _board[row + 3, column].State == discPlayed
                    )
                    {
                        return true;
                    }

                    //check up
                    if (_board[row, column].State == discPlayed &&
                        _board[row - 1, column].State == discPlayed &&
                        _board[row - 2, column].State == discPlayed &&
                        _board[row - 3, column].State == discPlayed
                    )
                    {
                        return true;
                    }
                    //check right
                    if (_board[row, column].State == discPlayed &&
                        _board[row, column + 1].State == discPlayed &&
                        _board[row, column + 2].State == discPlayed &&
                        _board[row, column + 3].State == discPlayed
                    )
                    {
                        return true;
                    }
                    //check left
                    if (_board[row, column].State == discPlayed &&
                        _board[row, column - 1].State == discPlayed &&
                        _board[row, column - 2].State == discPlayed &&
                        _board[row, column - 3].State == discPlayed
                    )
                    {
                        return true;
                    }
                    //check diagonally 
                    if (_board[row, column].State == discPlayed &&
                        _board[row - 1, column - 1].State == discPlayed &&
                        _board[row - 2, column - 2].State == discPlayed &&
                        _board[row - 3, column - 3].State == discPlayed
                    )
                    {
                        return true;
                    }
                    //check diagonally
                    if (_board[row, column].State == discPlayed &&
                        _board[row + 1, column - 1].State == discPlayed &&
                        _board[row + 2, column - 2].State == discPlayed &&
                        _board[row + 3, column - 3].State == discPlayed
                    )
                    {
                        return true;
                    }
                    if (_board[row, column].State == discPlayed &&
                        _board[row + 1, column + 1].State == discPlayed &&
                        _board[row + 2, column + 2].State == discPlayed &&
                        _board[row + 3, column + 3].State == discPlayed
                    )
                    {
                        return true;
                    }
                    //check diagonally 
                    if (_board[row, column].State == discPlayed &&
                        _board[row - 1, column + 1].State == discPlayed &&
                        _board[row - 2, column + 2].State == discPlayed &&
                        _board[row - 3, column + 3].State == discPlayed
                    )
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void PlayerWin()
        {
            Console.WriteLine(activePlayer.playerName + ", You Win!");
        }

        public int GetChosenColumn()
        {
            int columnChosen;
            do
            {
                Console.WriteLine("{0}, enter a column number between 1 and 7: ", activePlayer.playerName);
                columnChosen = Convert.ToInt32(Console.ReadLine());
            } while (columnChosen < 1 || columnChosen > 7);

            return columnChosen;
        }

        public void CheckNextAvailableRow(int columnChosen)
        {
            bool dropped = false;
            for (int i = Rows - 3; i > 0; i--)
            {
                if (_board[i, columnChosen].State == SpaceState.N && dropped == false)
                {
                    _board[i, columnChosen].State = activePlayer.discColour;
                    dropped = true;                  
                }
            }
        }

        public void SwitchPlayer()
        {
            if (activePlayer == PlayerOne)
            {
                activePlayer = PlayerTwo;
            }
            else if (activePlayer == PlayerTwo)
            {
                activePlayer = PlayerOne;
            }
        }
    }
}
