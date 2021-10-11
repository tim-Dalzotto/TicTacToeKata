using System;
using System.Collections.Generic;
using Moq;
using TicTacToeKata;
using TicTacToeKata.Controller;
using TicTacToeUnitTest.Model;
using TicTacToeKata.View;
using Xunit;

namespace TicTacToeUnitTest
{
    public class GameControllerTests
    {
        private Mock<IGameRules> mockGameRules = new Mock<IGameRules>();
        
        [Fact]
        public void PlayGame_When_PlayerOneWinsTest()
        {
            var gameBoard = new Func<string[,]>(new GameBoard().NewGameBoard);
            mockGameRules.Setup(m => m.PlayerMove(It.IsAny<string[,]>(), It.IsAny<string>(), It.IsAny<Player>(),
                It.IsAny<bool>())).Returns(gameBoard);
            mockGameRules.Setup(m => m.CheckForWinner(It.IsAny<WinConditions>(), It.IsAny<Player>()))
                .Returns(true);
            mockGameRules.Setup(m => m.CheckIfValidMove(It.IsAny<string>(), It.IsAny<Player>(), It.IsAny<Player>()))
                .Returns(true);
            var controller = new GameController(mockGameRules.Object, new GameBoard(), new MockUserInput(), new ConsoleUI(), new WinConditions());
            var result = controller.PlayGame(new Player(), new Player());
            Assert.True(result);
        }
        
        [Fact]
        public void PlayGame_When_PlayerOnelosesTest()
        {
            var gameBoard = new Func<string[,]>(new GameBoard().NewGameBoard);
            var playerOne = new Player();
            var playerTwo = new Player();
            playerTwo.CurrentCoords.Add("1,1");
            var winConditon = new WinConditions();
            winConditon.WinList.Add("1,1");
            mockGameRules.Setup(m => m.PlayerMove(It.IsAny<string[,]>(), It.IsAny<string>(), It.IsAny<Player>(),
                It.IsAny<bool>())).Returns(gameBoard);
            mockGameRules.Setup(m => m.CheckForWinner(winConditon, playerTwo))
                .Returns(true);
            mockGameRules.Setup(m => m.CheckIfValidMove(It.IsAny<string>(), It.IsAny<Player>(), It.IsAny<Player>()))
                .Returns(true);
            var controller = new GameController(mockGameRules.Object, new GameBoard(), new MockUserInput(), new ConsoleUI(), new WinConditions());
            var result = controller.PlayGame(playerOne, playerTwo);
            Assert.True(result);
        }
    }
}