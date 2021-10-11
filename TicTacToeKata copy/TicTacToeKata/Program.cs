using System;
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
            gameController.PlayGame(playerOne, playerTwo);
        }
    }
}