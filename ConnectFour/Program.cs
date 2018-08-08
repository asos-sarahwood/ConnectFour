using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Game connectFour = new Game();
            
         

            while (!connectFour.HasWinner)
            {
                var column = Console.ReadLine();
                connectFour.Play(Int32.Parse(column));
                
            }
        }
    }
}
