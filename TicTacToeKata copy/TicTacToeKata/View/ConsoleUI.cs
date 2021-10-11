using System;

namespace TicTacToeKata.View
{
    public class ConsoleUI : IOutput
    {
        public void DisplayGameBoard(string[,] gameBoard)
        {
            
            Console.WriteLine($"{gameBoard[0, 0]} {gameBoard[0, 1]} {gameBoard[0, 2]}");
            Console.WriteLine($"{gameBoard[1, 0]} {gameBoard[1, 1]} {gameBoard[1, 2]}");
            Console.WriteLine($"{gameBoard[2, 0]} {gameBoard[2, 1]} {gameBoard[2, 2]}");
        
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