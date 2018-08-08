
using System;

namespace ConnectFour
{
    class Board
    {
        public readonly int Rows = 6;
        public readonly int Columns = 7;
        private readonly Space[,] _board;

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
                        Console.Write(board[row, column].Disc.ToString());
                    }
                }
                Console.Write("| \n");
            }
        }

        public Space[] GetColumn(int column)
        {
            return null;
        }
    }
}
