using System.Data;

namespace ConnectFour
{
    class Game
    {
        private readonly Board _board;
        private readonly int rows = 6;
        private readonly int columns = 7;

        public Game(int rows, int columns)
        {
            this.columns = columns;
            this.rows = rows;
            _board = new Board(rows, columns);
            
        }
    }
}
