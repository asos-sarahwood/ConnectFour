using System;

namespace ConnectFour
{
    class Board
    {

        public readonly int Rows;
        public readonly int Columns;
        private readonly Space[,] _board;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _board = new Space[rows, columns];
           

        }

    }
}
