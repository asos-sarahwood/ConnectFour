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

        public bool HasWinner { get; set; }

        public override string ToString()
        {
            return _board.ToString();
        }

        public void Play(int columnNumber)
        {
            var column = _board.GetColumn(columnNumber);

            for (var x = 5; x >= 0; x--)
            {
                var space = column[x];
                if (space.Disc is null)
                {
                    space.Disc = new Disc(){Colour = DiscColour.Red};
                }
               
            }
        }

    }
}
