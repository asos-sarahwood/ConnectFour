using System.Data;

namespace ConnectFour
{
    class Game
    {
        private readonly Board _board;
       
        public Game(int rows, int columns)
        {
           _board = new Board(rows, columns);
            
        }

       
    }
}
