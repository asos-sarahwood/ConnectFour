using System;
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

        public void Play(int columnNumber)
        {
            GetPlayerDetails();
            var column = _board.GetColumn(columnNumber);
            for (var x = 5; x >= 0; x--)
            {
                var space = column[x];
                if (space.Disc is null)
                {
                    space.Disc = new Disc() {Colour = DiscColour.R};
                }
            }
        }

        private void GetPlayerDetails()
        {
            playerInfo playerOne = new playerInfo();
            playerInfo playerTwo = new playerInfo();
            Console.WriteLine("Let's Play");
            Console.WriteLine("Player one, please enter your name: ");
            playerTwo.playerName = Console.ReadLine();
            playerOne.playerDisc = DiscColour.R;
            Console.WriteLine("Player Two please enter your name: ");
            playerTwo.playerName = Console.ReadLine();
            playerOne.playerDisc = DiscColour.Y;
        }
    }
}
