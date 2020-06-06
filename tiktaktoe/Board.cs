using ImTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace tiktaktoe
{
    public class Board
    {
        public Token[,] _boardArray = new Token[3, 3];

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

        public void UpdateBoard(int row, int column, Token token) // int row, int column, tokend
        {
            _boardArray[row, column] = token;
        }
        
        public void Validateboard(int i, int j)
        {
            if (i >= 3 || j >= 3) throw new ArgumentException();
        }

        //all below needs to go in its own class most likely
        public bool HasWon() // is game over (is board filled?)
        {
            return HasWon(Token.X) || HasWon(Token.O); 
        }

        public bool HasWon(Token token)
        {
            return HasWonDiagonal(token) || HasWonColumn(token) || HasWonRow(token);
        }

        public bool HasWonDiagonal(Token token)
        {
            if (_boardArray[0, 0] == token && _boardArray[1, 1] == token && _boardArray[2, 2] == token) 
            {
                return true;
            }
            if (_boardArray[0, 2] == token && _boardArray[1, 1] == token && _boardArray[2, 0] == token)
            {
                return true;
            }
            return false;
        }
        public bool HasWonRow(Token token)
        {
            for (int row = 0; row < _boardArray.GetLength(0); row++)
            {
                if (_boardArray[row, 0] == token && _boardArray[row, 1] == token && _boardArray[row, 2] == token)
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasWonColumn(Token token)
        {
            for (int column = 0; column < _boardArray.GetLength(1); column++)
            {
                if (_boardArray[0, column] == token && _boardArray[1, column] == token && _boardArray[2, column] == token)

                    return true;
            }

            return false;
        }

        //TODO:  unit testing and create just a "HasWon check instead of each individual one" "assert is true has 1 diagonal" use mars rover examples for tests have a few unit tests (test methods)
        //once test suite is in place (Test on diagonal/row/column) Refactor these methods to work for a board of any size easiest ones will be row/column depending on how you implement them
        // dont feel bad if you end up needing to use a double nested for loop for each (dont have to use them)
        
    }
}


