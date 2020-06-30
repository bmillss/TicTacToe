using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tiktaktoe
{
    public static class Program
    {
        private struct TokenPlacement
        {
            public int Row { get; set; }
            public int Column { get; set; }
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
            new TokenPlacement{Row=2, Column=1}, // Bottom Center
            new TokenPlacement{Row=1, Column=2}, // Middle Right
            new TokenPlacement{Row=2, Column=2}, // Bottom Right
            new TokenPlacement{Row=1, Column=1}, // Center
        };

        private static List<TokenPlacement> itsATie = new List<TokenPlacement>
        {
            new TokenPlacement{Row=0, Column=0}, // Upper Left X
            new TokenPlacement{Row=0, Column=2}, // Upper Right O
            new TokenPlacement{Row=1, Column=1}, // Center X
            new TokenPlacement{Row=2, Column=2}, // Bottom Right O 
            new TokenPlacement{Row=1, Column=2}, // Middle Right X
            new TokenPlacement{Row=1, Column=0}, // Middle Left  O
            new TokenPlacement{Row=0, Column=1}, // Upper Middle X
            new TokenPlacement{Row=2, Column=1}, // Bottom middle O
            new TokenPlacement{Row=2, Column=0}, // Bottom Left X
        };
        //you dont get UI stuff on unit tests
        //TODO: input validation for if anything is outside parameter of array, add some other strategies as in O wins or theres a tie (we already have x wins (line15)
        public static void Main(string[] args)
        {
            bool autoMode = false;
            List<TokenPlacement> strategy = new List<TokenPlacement>();
            // Func is something that can take 0 or more parameters, and returns one parameter
            // Func<int> => no inputs, returns a number
            // Func<int> getNumberOfRows = () => 3;
            // Func<int, int> => takes one int, returns an int
            // Func<int, int> squared = (x) => x*x;
            // Func<int, int, int> => takes two integers, returns one
            // Func<int, int, int> add = (a, b) => a+b;

            Func<string, List<TokenPlacement>> getStrategy = (s) =>
            {
                if (s == "XWins") return XWins;
                if (s == "OWins") return OWins;
                if (s == "itsATie") return itsATie;
                return new List<TokenPlacement>();
            };

            if (args.Length == 1)
            {
                strategy = getStrategy(args[0]);
                if (!strategy.Any())
                {
                    autoMode = false;
                    Console.WriteLine("Don't have a strategy for " + args[0]);
                }
                else
                {
                    autoMode = true;
                    Console.WriteLine("In automatic mode, playing as " + args[0]);
                }
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
                while (!isPlayerValid)
                {
                    int playerRow;
                    int playerColumn;
                    if (autoMode)
                    {
                        playerRow = strategy[turncount].Row;
                        playerColumn = strategy[turncount].Column;
                    }
                    else
                    {
                        playerRow = GetRowDimension(currentToken);
                        playerColumn = GetColumnDimension(currentToken);
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
            Func<Board, string> getCongratulationsMessage = b =>
            {
                if (b.IsTied()) return "Game is tied!";
                if (b.HasWon(Token.X)) return "Congratulations Player X you have won!\n";
                if (b.HasWon(Token.O)) return "Congratulations Player O you have won!\n";
                throw new System.Exception("Board was not in a final state " + board.FormatBoard());
            };
            Console.WriteLine(getCongratulationsMessage(board));
        }

        private static int GetRowDimension(Token currentToken)
        {
            return GetDimension(currentToken, "row");
        }

        private static int GetColumnDimension(Token currentToken)
        {
            return GetDimension(currentToken, "column");
        }
        
        private static int GetDimension(Token currentToken, string dimension)
        {
            int input;
            do
            {
                Console.WriteLine("Player " + currentToken + " please input your placement for " + dimension);
                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    if (input < 0 || input > 2)
                    {
                        Console.WriteLine("This is outside of bounds please input a number between 0 and 2");
                    }
                }
            } while (input < 0 || input > 2);
            return input;
        }
    }
}
