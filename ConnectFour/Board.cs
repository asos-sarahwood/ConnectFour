
using System;

namespace ConnectFour
{
    class Board
    {
        public readonly int Rows = 7;
        public readonly int Columns = 8;
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
            for (int row = 1; row < Rows; row++)
            {
                Console.Write("");
                for (int column = 1; column < Columns; column++)
                {
                    if (board[row, column].Disc == null)
                    {
                        Console.Write("|_");
                    }
                    else
                    {
                        Console.Write("|{0}",board[row, column].Disc.ToString());
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
                discColour = DiscColour.R
            };
            Console.WriteLine("Player Two please enter your name: ");
            PlayerTwo = new Player
            {
                playerName = Console.ReadLine(),
                discColour = DiscColour.Y
            };
            Console.WriteLine("{0} is playing with red discs", PlayerOne.playerName);
            Console.WriteLine("{0} is playing with yellow discs", PlayerTwo.playerName);
            activePlayer = PlayerOne;
        }

        public void Play()
        {
            GetPlayerDetails();
            bool winner;
            var full = 0;
            var again = 0;
            do
            {
                var playerOnesChosenColumn = GetChosenColumn();
                CheckNextAvailableRow(playerOnesChosenColumn, _board, activePlayer);
                DrawBoard(_board);
                CheckForWinner(_board, PlayerOne);
                winner = CheckForWinner(_board, activePlayer);
                if (winner == true)
                {
                    PlayerHasWon(activePlayer);
                    again = restart(_board);
                    if (again == 2)
                    {
                        break;
                    }
                }

                var playerTwosChosenColumn = GetChosenColumn();
                CheckNextAvailableRow(playerTwosChosenColumn, _board, activePlayer);
                DrawBoard(_board);
                winner = CheckForWinner(_board, activePlayer);
                if (winner == true)
                {
                    PlayerHasWon(activePlayer);
                    again = restart(_board);
                    if (again == 2)
                    {
                        break;
                    }
                }
                full = FullBoard(_board);
                if (full == 7)
                {
                    Console.WriteLine("The board is full, it is a draw!");
                    again = restart(_board);
                }
            } while (again != 2);
        }

        static int FullBoard(Space[,] board)
        {
            int full;
            full = 0;
            for (int i = 1; i <= 7; ++i)
            {
                if (board[1, i] != null)
                    ++full;
            }
            return full;
        }

        private bool CheckForWinner(Space[,] board, Player currentPlayer)
        {          
            bool winner = false;
            var discChecker = currentPlayer.discColour;

            for (int A = 6; A >= 1; --A)
            {
                for (int B = 7; B >= 1; --B)
                {
                    var disc = board[A, B].Disc;
                    if (disc != null)
                    {
                        if (disc.Colour == discChecker &&
                            board[A - 1, B - 1]?.Disc.Colour == discChecker &&
                            board[A - 2, B - 2]?.Disc.Colour == discChecker &&
                            board[A - 3, B - 3]?.Disc.Colour == discChecker)
                        {
                            winner = true;
                        }
                    }
                }
            }
            return winner;
        }

        static void PlayerHasWon(Player activePlayer)
        {
            Console.WriteLine(activePlayer.playerName + " Connected Four, You Win!");
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

        public void CheckNextAvailableRow(int columnChosen, Space[,] board, Player active)
        {
            bool dropped = false;
            for (int i = Rows - 1; i > 0; i--)
            {            
                if (board[i, columnChosen].Disc == null && dropped == false)
                {
                    board[i, columnChosen].Disc = new Disc {Colour = active.discColour};
                    dropped = true;
                }
            }
        }

        static int restart(Space[,] board)
        {
            int restart;
            Console.WriteLine("Would you like to restart? Yes(1) No(2): ");
            restart = Convert.ToInt32(Console.ReadLine());
            if (restart == 1)
            {
                for (int i = 1; i <= 6; i++)
                {
                    for (int ix = 1; ix <= 7; ix++)
                    {
                        board[i, ix] = null;
                    }
                }
            }
            else
                Console.WriteLine("Goodbye!");
            return restart;
        }
    }
}
