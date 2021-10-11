using System;
using System.Collections.Generic;
using TicTacToeKata;
using Xunit;

namespace TicTacToeUnitTest
{
    public class ModelTest
    {
        [Fact]
        public void IfGameBoardIsCalled_ThenGameBoardIsNotNull()
        {
            var gameBoard = new GameBoard();

            var actual = gameBoard.NewGameBoard();

            Assert.NotEmpty(actual);
        }

        [Fact]
        public void IfPlayerOneEntersValidMove_UpdateGameBoardWithX()
        {
            var gameBoard = new GameBoard();
            var player = new Player();
            player.CurrentCoords = new List<string>();
            var currentBoard = gameBoard.NewGameBoard();
            var playerOnesTurn = true;
            var gameRule = new GameRule();
            var coord = "1,1";
            
            gameRule.PlayerMove(currentBoard, coord, player, playerOnesTurn);
            var actual = currentBoard;

            var result = new string[,] {{"X", ".", "."},{".", ".", "."},{".", ".", "."}};
            Assert.Equal(result, actual);

        }
        [Fact]
        public void IfPlayerTwoEntersValidMove_UpdateGameBoardWithO()
        {
            var gameBoard = new GameBoard();
            var playerTwo = new Player();
            playerTwo.CurrentCoords = new List<string>();
            var currentBoard = gameBoard.NewGameBoard();
            var gameRule = new GameRule();
            var playerOnesTurn = false;
            var coord = "1,1";
            
            gameRule.PlayerMove(currentBoard, coord, playerTwo, playerOnesTurn);
            var actual = currentBoard;

            var result = new string[,] {{"O", ".", "."},{".", ".", "."},{".", ".", "."}};
            Assert.Equal(result, actual);

        }

        [Theory]
        [InlineData("1,2","1,3","2,3",true)]
        [InlineData("1,7","1,3","2,3",false)]
        [InlineData("1,2","1,2","2,3",false)]
        [InlineData("1,2","1,3","1,2",false)]
        public void IfPlayerEntersAMove_CheckIfMoveIsValidBeforeProceeding(string UserInputCoord, string playerOneCoord, string playerTwoCoord, bool result)
        {
            var gameRule = new GameRule();
            var coord = UserInputCoord;
            var playerOne = new Player();
            playerOne.CurrentCoords = new List<string>(){playerOneCoord};
            var playerTwo = new Player();
            playerTwo.CurrentCoords = new List<string>(){playerTwoCoord};
            
            var actual =  gameRule.CheckIfValidMove(coord, playerOne, playerTwo);

            Assert.Equal(result, actual);
        }

        [Fact]
        public void IfPlayerEntersValidMove_MoveIsAddedToPlayersMoveList()
        {
            var gameBoard = new GameBoard();
            var currentBoard = gameBoard.NewGameBoard();
            var player = new Player();
            player.CurrentCoords = new List<string>();
            var gameRule = new GameRule();
            var coord = "1,2";
            
            gameRule.PlayerMove(currentBoard, coord, player, true);
            //player.CurrentCoords.Add(coord);
            var actual = player.CurrentCoords[0];

            const string result = "1,2";
            
            Assert.Equal(result, actual);
        }

        [Theory]
        [InlineData("2,1","3,2","2,3","3,3", false)]
        [InlineData("3,3","2,1","2,2","2,3", true)]
        [InlineData("3,3","1,1","2,1","3,1", true)]
        [InlineData("3,1","1,1","2,2","3,3", true)]
        [InlineData("3,1","2,2","1,1","3,3", true)]
        [InlineData("3,2","1,2","1,3","1,1", true)]
        public void IfPlayersCurrentCoordListContainsWinningCombination_ThenThatPlayerIsTheWinner(string coord1, string coord2, string coord3,string coord4, bool result)
        {
            var gameBoard = new GameBoard();
            var currentBoard = gameBoard.NewGameBoard();
            var player = new Player();
            player.CurrentCoords = new List<string>(){coord1,coord2,coord3,coord4};
            var gameRule = new GameRule();
            var winConditions = new WinConditions();

            var actual = gameRule.CheckForWinner(winConditions,player);
            
            Assert.Equal(result, actual);
        }
    }
}