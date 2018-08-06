using System.Data;

namespace ConnectFour
{
    class Game
    {
        private readonly Board _board;
       
        public Game()
        {
           _board = new Board();            
        }

        public override string ToString()
        {
            return _board.ToString();
        }
    }
}
