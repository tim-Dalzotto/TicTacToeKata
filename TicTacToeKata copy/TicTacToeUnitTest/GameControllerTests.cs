using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
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
            var gameBoard = new GameBoard();
            gameBoard.NewGameBoard();
            var expectedWinner = new Player();
            expectedWinner.Name = "Player One";
            gameBoard.NewGameBoard();
            mockGameRules.Setup(m => m.PlayerMove(It.IsAny<GameBoard>(), It.IsAny<string>(), It.IsAny<Player>(),
                It.IsAny<bool>())).Returns(gameBoard);
            mockGameRules.Setup(m => m.UpdatePlayerMoveList(It.IsAny<Player>(), It.IsAny<string>()));

            mockGameRules.Setup(m => m.CheckForWinner(It.IsAny<WinConditions>(), It.IsAny<Player>()))
                .Returns(true);
            mockGameRules.Setup(m => m.CheckIfValidMove(It.IsAny<string>(), It.IsAny<Player>(), It.IsAny<Player>()))
                .Returns(true);
            var controller = new GameController(mockGameRules.Object, gameBoard, new MockUserInput(), new ConsoleUI(), new WinConditions());
            var result = controller.PlayGame(expectedWinner, new Player(), gameBoard);
            
            result.Should().BeEquivalentTo(expectedWinner);
        }
        
        [Fact]
        public void PlayGame_When_PlayerTwoWinsTest()
        {
            var gameBoard = new GameBoard();
            gameBoard.NewGameBoard();
            var expectedWinner = new Player();
            expectedWinner.Name = "Player Two";
            gameBoard.NewGameBoard();
            mockGameRules.Setup(m => m.PlayerMove(It.IsAny<GameBoard>(), It.IsAny<string>(), It.IsAny<Player>(),
                It.IsAny<bool>())).Returns(gameBoard);
            mockGameRules.Setup(m => m.UpdatePlayerMoveList(It.IsAny<Player>(), It.IsAny<string>()));

            mockGameRules.Setup(m => m.CheckForWinner(It.IsAny<WinConditions>(), expectedWinner))
                .Returns(true);
            mockGameRules.Setup(m => m.CheckIfValidMove(It.IsAny<string>(), It.IsAny<Player>(), It.IsAny<Player>()))
                .Returns(true);
            var controller = new GameController(mockGameRules.Object, gameBoard, new MockUserInput(), new ConsoleUI(), new WinConditions());
            var result = controller.PlayGame(new Player(), expectedWinner, gameBoard);
            
            result.Should().BeEquivalentTo(expectedWinner);
        }
    }
}