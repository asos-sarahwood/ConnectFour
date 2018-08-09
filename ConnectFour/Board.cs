
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
            DrawBoard(_board);
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

        public void Play()
        {
            GetPlayerDetails();
            var chosenColumn = GetChosenColumn();
            CheckNextAvailableRow(chosenColumn, _board, activePlayer);
        }

        public void GetPlayerDetails()
        {
            Console.WriteLine("Player one, please enter your name: ");
            PlayerOne = new Player
            {
                playerName = Console.ReadLine(),
                playerDisc = DiscColour.R
            };
            Console.WriteLine("Player Two please enter your name: ");
            PlayerTwo = new Player
            {
                playerName = Console.ReadLine(),
                playerDisc = DiscColour.Y
            };
            Console.Clear();
            Console.WriteLine("{0} is playing with red discs", PlayerOne.playerName);
            Console.WriteLine("{0} is playing with yellow discs", PlayerTwo.playerName);
            Console.WriteLine();
            Console.WriteLine("Let's play!");
            Console.WriteLine();
            activePlayer = PlayerOne;

        }
        public int GetChosenColumn()
        {
            int columnChosen;
            Console.WriteLine(activePlayer.playerName);
            do
            {
                Console.WriteLine("{0}, enter a column number between 1 and 7: ", activePlayer.playerName);
                columnChosen = Convert.ToInt32(Console.ReadLine());
            } while (columnChosen < 1 || columnChosen > 7);

            return columnChosen;

        }

        public void CheckNextAvailableRow(int columnChosen, Space[,] board, Player active)
        {
            int rows = Rows;
            bool dropped = false;
            for (int i = rows - 1; i > 0; i--)
            {            
                if (board[i, columnChosen].Disc == null && dropped == false)
                {
                    board[i, columnChosen].Disc = new Disc {Colour = active.playerDisc};
                    dropped = true;
                }
            }
            DrawBoard(board);
        }
    }
}
