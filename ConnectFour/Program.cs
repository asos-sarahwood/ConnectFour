using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play connect four!");

            Console.WriteLine();
          
            Game connectFour = new Game();
            connectFour._board.Play();
          
        }
    }
}
