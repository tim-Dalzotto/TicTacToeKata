using System;

namespace TicTacToeKata.View
{
    public class ConsoleUI : IOutput
    {
        public void DisplayGameBoard(GameBoard gameBoard)
        {
            Console.WriteLine($"{gameBoard.board[0, 0]} {gameBoard.board[0, 1]} {gameBoard.board[0, 2]}");
            Console.WriteLine($"{gameBoard.board[1, 0]} {gameBoard.board[1, 1]} {gameBoard.board[1, 2]}");
            Console.WriteLine($"{gameBoard.board[2, 0]} {gameBoard.board[2, 1]} {gameBoard.board[2, 2]}");
        }

        public void DisplayWinner(Player currentPlayer)
        {
            Console.WriteLine($"{currentPlayer.ToString()} is the Winner");
        }

        public void DisplayInvalidInput()
        {
            Console.WriteLine("Invalid input");
        }
    }
}