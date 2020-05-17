using ImTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace program.cs
{
    public class Board
    {
        private Token[,] _boardArray = new Token[3, 3];

        // Constructor
        public Board()
        {
            InitializeBoard();
        }
        
        private void InitializeBoard()
        {
            for (int row = 0; row < _boardArray.GetLength(0); row++)
            {
                for (int column = 0; column < _boardArray.GetLength(1); column++)
                {
                    _boardArray[row, column] = Token.Blank;
                }
            }
        }

        public string FormatBoard()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < _boardArray.GetLength(0); row++)
            {
                for (int column = 0; column < _boardArray.GetLength(1); column++)
                {
                    sb.Append(_boardArray[row, column] + "\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        
        public void UpdateBoard(int row, int column, Token token) // int row, int column, Token token
        {
            _boardArray[row, column] = token;
            // What's the row?
            // Get the row from the user
            // What's the column?
            // Get the column from the user
           //switch(tokenPlacement.)
            {
                //case "TL":

            }

        }
        
        public void Validateboard(int i, int j)
        {
            if (i >= 3 || j >= 3) throw new ArgumentException();
        }
    }
}
    //TODO: write logic to check if someone has won, tip: 3 diff ways they can win all in row/column/diagonally write a method for each perhaps 
    //do it hardcoded first then challenge to do it with loops only 
    //wincondition check if symbol shows up all in a row/column/diag after this model how turn goes would be next step

