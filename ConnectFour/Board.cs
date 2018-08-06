using System;
using System.Diagnostics;
using System.Threading;

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
        }

        public override string ToString()
        {
            var boardString = " ";

            for (int  rowCounter = 0;  rowCounter <= Rows;  rowCounter++)
            {
                for (int columnCounter = 0; columnCounter <= Columns; columnCounter++)
                {
                    if (rowCounter == 0)
                    {
                        if (columnCounter != 0)
                        {
                            boardString += columnCounter;
                        }
                    }  
                    else
                    {
                       
                        if (columnCounter == 0)
                        {
                            boardString += rowCounter;
                        }
                        else
                        {
                            _board[rowCounter-1, columnCounter-1] = new Space();

                            boardString += "x";

                        }
                    }
                }

                boardString += "\n";
            }

            return boardString;
        }
    }
}
