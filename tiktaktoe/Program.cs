using System;
using System.Collections.Generic;
using System.Text;

namespace tiktaktoe
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Board board = new Board();
            /* board.UpdateBoard(0, 0, Token.X);
             board.UpdateBoard(1, 1, Token.X);
             board.UpdateBoard(2, 2, Token.X);
             Console.WriteLine(board.HasWonDiagonal(Token.X));
             */
            Console.WriteLine(board.FormatBoard());

            Console.WriteLine("Player1: X, Player2: Y");
            int turncount = 0;
            do
            {
                if (turncount % 2 != 0)
                {
                    Console.WriteLine("Player 1 please input your placement for row");
                    int PlayerRow = int.Parse(Console.ReadLine());
                    Console.WriteLine("Player 1 please input your placement for Column");
                    int PlayerColumn = int.Parse(Console.ReadLine());
                    board.UpdateBoard(PlayerRow, PlayerColumn, Token.X);
                    Console.WriteLine(board.FormatBoard());


                }
                else
                {
                    Console.WriteLine("Player 2 please input your placement for row");
                    int Player2Row = int.Parse(Console.ReadLine());
                    Console.WriteLine("Player 2 please input your placement for Column");
                    int Player2Column = int.Parse(Console.ReadLine());
                    board.UpdateBoard(Player2Row, Player2Column, Token.O);
                    Console.WriteLine(board.FormatBoard());
                }
                turncount++;
            } while (board.HasWon() != true);
            
            // Here's what I'd do
            // - Create two players, one for X, one for O
            // - Create a roundKeeper variable that keeps track of who's turn it is
            // - While the game is not won
            //   - Current player picks a spot
            //   - Board updates to reflect the choice
            //   - Next player becomes Current Player
        }
    }   
}
//treat as scratch pad, pick a space and print whats in that space
//could create new type class called game and has 2 player as fields and board as field and console app just asks game who current player is (this if refactored dont do)