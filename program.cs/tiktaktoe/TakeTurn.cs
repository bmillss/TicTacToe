using program;
using System;
using System.Collections.Generic;
using System.Text;


namespace program.cs
{
    public class TakeTurn
    {
        public int X { get; set; }
        public int O { get; set; }
        public TakeTurn()
        {
            X = 0;
            O = 0;
        }
        public void DoTurn()
        {
            Console.WriteLine("Hello user, please input a location to place your token!");
            string tokenPlacement = Console.ReadLine();
            
            //TODO: finish method for taking a turn
        }
        
    }
}
