using ImTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace tiktaktoe
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
        
        public void UpdateBoard(int row, int column, Token token) // int row, int column, Token tokend
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

        //all below needs to go in its own class most likely
        public bool HasWonDiagonal()
        {
            for (int row = 0; row <_boardArray.GetLength(0); row++)
            {
                for (int column = 0; column < _boardArray.GetLength(1); column++)
                {
                    if (Board[row,column] == token Token.X && Board[row,column] == token Token.X && Board[row,column] == token Token.X || 
                        Board[row,column] == token Token.Y && Board[row,column] == token Token.Y && Board[row,column] == token Token.Y)
                    {
                        HasWonRoW = true;
                    }
            for (int row = _boardArray.GetLength(0); row > 0; row--)
                {
                for (int column = _boardArray.GetLength(1); column > 0; column--)
                {
                    if (Board[row,column] == token Token.X && Board[row,column] == token Token.X && Board[row,column] == token Token.X || 
                        Board[row,column] == token Token.Y && Board[row,column] == token Token.Y && Board[row,column] == token Token.Y)
                    {
                        HasWonRoW = true;
                    }

                }

                }

            }

        }
        public bool HasWonRoW()
        {
            for (int row = 0; row <_boardArray.GetLength(0); row++)
                {
            
                    if (Board[row,0] == Token.X && Board[row,1] == Token Token.X && Board[row,2] == Token.X || 
                        Board[row,0] == Token Token.Y && Board[row,1] == Token Token.Y && Board[row,2] == Token.Y)
                    {
                        HasWonRoW = true;
                    }
                }
        }
        public bool HasWonColumn()
        {
            for (int column = 0; column < _boardArray.GetLength(1); column++)
            {
            if (Board[0,column] == Token.X && Board[1,column] == Token Token.X && Board[2,column] == Token.X || 
                        Board[0,column] == Token Token.Y && Board[1,column] == Token Token.Y && Board[2,column]; == Token.Y)
                    {
                        HasWonRoW = true;
                    }
            }
        }

    }
    //TODO: write logic to check if someone has won, tip: 3 diff ways they can win all in row/column/diagonally write a method for each perhaps 
    //do it hardcoded first then challenge to do it with loops only 
    //wincondition check if symbol shows up all in a row/column/diag after this model how turn goes would be next step
}

