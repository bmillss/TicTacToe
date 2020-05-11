using ImTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace program.cs
{
    public class Board
    {

        Token[,] boardarray = new Token[3, 3];

        public string InitializeBoard()
        {
            for (int i = 0; i < boardarray.GetLength(0); i++)
            {
                for (int j = 0; j < boardarray.GetLength(1); j++)
                {
                    boardarray[i, j] = Token.Blank;
                }
            }
            return string.Empty;
        }
        public void PrintBoard()
        {
            for (int i = 0; i < boardarray.GetLength(0); i++)
            {
                for (int j = 0; j < boardarray.GetLength(1); j++)
                {
                    Console.Write(boardarray[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }

        }
    }
}
    

