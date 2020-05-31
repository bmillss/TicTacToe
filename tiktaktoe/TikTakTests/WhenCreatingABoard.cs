using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using tiktaktoe;

namespace TikTakTests
{
    [TestClass]
    public class WhenCreatingABoard
    {
        [TestMethod]
        public void WhenCheckingThatABoardHasThreeInAColumn()
        {
            //arrange
            Board board = new Board();
            board.UpdateBoard(0, 0, Token.X);
            board.UpdateBoard(0, 1, Token.X);
            board.UpdateBoard(0, 2, Token.X);
            //act
            //assert
            Assert.IsTrue(board.HasWon());

        }
        [TestMethod]
        public void WhenCheckingThatABoardHasThreeInARow()
        {
            //arrange
            Board board = new Board();
            board.UpdateBoard(0, 0, Token.X);
            board.UpdateBoard(1, 0, Token.X);
            board.UpdateBoard(2, 0, Token.X);
            //act
            //assert
            Assert.IsTrue(board.HasWon());

        }
        [TestMethod]
        public void WhenCheckingThatABoardHasThreeAcross()
        {
            //arrange
            Board board = new Board();
            board.UpdateBoard(0, 0, Token.X);
            board.UpdateBoard(1, 1, Token.X);
            board.UpdateBoard(2, 2, Token.X);
            //act
            //assert
            Assert.IsTrue(board.HasWon());

        }
        [TestMethod]
        public void WhenCheckingThatABoardHasThreeAcross2()
        {
            //arrange
            Board board = new Board();
            board.UpdateBoard(0, 2, Token.X);
            board.UpdateBoard(1, 1, Token.X);
            board.UpdateBoard(2, 0, Token.X);
            //act
            //assert
            Assert.IsTrue(board.HasWon());

        }
        [DataTestMethod]
        [DataRow(Token.X, DisplayName = "WhenCheckingThatABoardHasThreeAcross")]
        public void HasWonShouldBeTrue(Token initial,Token final)
        {
            var board = new Board { };
            board.HasWon();
        }
        
    }
}
