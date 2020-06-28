using System;
using System.Collections.Generic;
using System.Text;

namespace tiktaktoe
{
    public static class Program
    {
        private struct TokenPlacement
        {
            public int Row{get; set;}
            public int Column {get; set;}
        }

        private static List<TokenPlacement> XWins = new List<TokenPlacement>
        {
            new TokenPlacement{Row=0, Column=0}, // Upper Left
            new TokenPlacement{Row=0, Column=2}, // Upper Right
            new TokenPlacement{Row=1, Column=1}, // Center
            new TokenPlacement{Row=1, Column=2}, // Middle Right
            new TokenPlacement{Row=2, Column=2} // Bottom Right
        };
        private static List<TokenPlacement> OWins = new List<TokenPlacement>
        {
            new TokenPlacement{Row=0, Column=0}, // Upper Left
            new TokenPlacement{Row=1, Column=0}, // Middle Left
            new TokenPlacement{Row=2, Column=1}, // Bottom Left
        };
        private static List<TokenPlacement> itsATie = new List<TokenPlacement>
        {
            new TokenPlacement{Row=0, Column=0}, // Upper Left
            new TokenPlacement{Row=0, Column=2}, // Upper Right
            new TokenPlacement{Row=1, Column=1}, // Center
            new TokenPlacement{Row=1, Column=2}, // Middle Right
            new TokenPlacement{Row=2, Column=2} // Bottom Right
        };
        //you dont get UI stuff on unit tests
        //think of a small project that you want to tackle
        //TODO: input validation for if anything iso utside parameter of array, add some other strategies as in O wins or theres a tie (we already have x wins (line15)
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, " + String.Join(" and ", args));
            bool autoMode = false;
            List<TokenPlacement> strategy = new List<TokenPlacement>();
            if (args.Length==1 && args[0] == "XWins")
            {
                autoMode = true;
                strategy = XWins;
                Console.WriteLine("In automatic mode, playing as XWins");
            }
            Board board = new Board();

            Console.WriteLine("Player1: X, Player2: O");
            int turncount = 0;
            do
            {
                Console.WriteLine(board.FormatBoard());
                Token currentToken;
                if (turncount % 2 == 0)
                {
                    currentToken = Token.X;
                }
                else
                {
                    currentToken = Token.O;
                }
                bool isPlayerValid = false;
                while (isPlayerValid != true)
                {
                    int playerRow;
                    int playerColumn;
                    if (!autoMode)
                    {
                        Console.WriteLine("Player " + currentToken + " please input your placement for row");
                        playerRow = int.Parse(Console.ReadLine());
                        if (playerRow < 0 && playerRow > 2)
                        {
                            Console.WriteLine("This is outside of bounds please input a number between 0 and 2");
                        }
                        Console.WriteLine("Player " + currentToken + " please input your placement for Column");
                        playerColumn = int.Parse(Console.ReadLine());
                        if (playerColumn < 0 && playerColumn > 2 )
                        {
                            Console.WriteLine("This is outside of bounds please input a number between 0 and 2");
                        }
                    }
                    else {
                        playerRow = strategy[turncount].Row;
                        playerColumn = strategy[turncount].Column;
                    }
                    isPlayerValid = board.UpdateBoard(playerRow, playerColumn, currentToken);
                    if (!isPlayerValid)
                    {
                        Console.WriteLine("\nI am sorry this spot is already taken choose another!");
                    }
                }

                turncount++;
            } while (!board.HasWon() && !board.IsTied());
            Console.WriteLine(board.FormatBoard());
            if (board.IsTied())
            {
                Console.WriteLine("Game is tied!");
            }
            else if (board.HasWon(Token.X))
            {
                Console.Write("Congratulations Player X you have won!\n");
            }
            else if (board.HasWon(Token.O))
            {
                Console.Write("Congratulations Player O you have won!\n");
            }
        }
    }
}
