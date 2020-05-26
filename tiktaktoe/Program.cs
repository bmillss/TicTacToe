using System;
using System.Collections.Generic;
using System.Text;

namespace tiktaktoe
{
    public static class Program
    {
        public static void Main(String[] args)
        {
            Board board = new Board();
            /*Console.WriteLine(board.FormatBoard());

            TakeTurn newTurn = new TakeTurn();
            newTurn.DoTurn();
            */
            /*int tokenRow = -1;
            int tokenColumn = -1;
            do
            {
                Console.WriteLine("What row?");
                tokenRow = Int32.Parse(Console.ReadLine());

                Console.WriteLine("What Column?");
                tokenColumn = Int32.Parse(Console.ReadLine());
            } while (tokenRow < 0 || tokenRow > 2 || tokenColumn < 0 || tokenColumn > 2);
            */
            board.UpdateBoard(0, 0, Token.X);
            board.UpdateBoard(1, 1, Token.X);
            board.UpdateBoard(2, 2, Token.X);
            Console.WriteLine(board.HasWonDiagonal());

            Console.WriteLine(board.FormatBoard());

            /* var player1 = CreateLosers(Token.X);
             var player2 = CreateLosers(Token.O);

             String decision = "";
             var TakeTurn = new TakeTurn();
             //TODO: validate user input, make sure user cant occupy already taken space 
             while (decision != "Quit")
             {

                 Console.WriteLine("Hello! Player 1 (x) please input your first choice, input shorthand for each value/n" +
                     "TL = Top left, TR = Top right, TC = top center/n" +
                     "MR = middle right, ML = middle left, MC = middle center/n" +
                     "BR = Bottom right, BL = bottom left, BC = bottom center/n" +
                     "Finally to reset the game type in: Reset");
                 string userInput = Console.ReadLine();
                 //TODO:validate user input
                 GetBoardCoordinates();


                 Console.WriteLine("You inputed: " + userInput);
             }
         }
         private static Player CreateLosers(Token Token)
         {

             Console.WriteLine("Hello please input username please im desperate.");
             string userName = Console.ReadLine();
             return new Player() { Name = userName, Token = Token }; //inline variable: avoid temp variables when you dont need them!

         }
         private static Dictionary<String, Coordinate> GetBoardCoordinates()
         {
             Dictionary<string, Coordinate> BoardCoordinates = new Dictionary<string, Coordinate>();
             BoardCoordinates.Add("TL", new Coordinate() { x = 0, y = 0 }); //make all others later

             return BoardCoordinates; */
        }
        

    }   

}
//treat as scratch pad, pick a space and print whats in that space