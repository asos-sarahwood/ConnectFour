﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Game connectFour = new Game();
            Console.Write(connectFour.ToString());

            while (!connectFour.HasWinner)
            {
                var column = Console.ReadLine();
                connectFour.Play(Int32.Parse(column));
                Console.WriteLine(connectFour.ToString());
            }
        }
    }
}
