using System;
using System.Data;
using System.Media;

namespace ConnectFour
{
    class Game
    {
        public readonly Board _board;
      
        public Game()
        {
          _board = new Board();       
        }         
    }
}
