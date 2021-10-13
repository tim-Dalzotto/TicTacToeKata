using System;
using System.Collections.Generic;
using TicTacToeKata.Controller;
using TicTacToeKata.View;

namespace TicTacToeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameController = new GameController(new GameRule(), new GameBoard(), new UserInput(), new ConsoleUI(), new WinConditions());
            var playerOne = new Player();
            var playerTwo = new Player();
            playerOne.Name = "PlayerOne";
            playerTwo.Name = "PlayerTwo";
            playerOne.CurrentCoords = new List<string>();
            playerTwo.CurrentCoords = new List<string>();
            var gameBoard = new GameBoard();
            gameBoard.NewGameBoard();
            
            var winner = gameController.PlayGame(playerOne, playerTwo, gameBoard);
            //console winner.
        }
    }
}