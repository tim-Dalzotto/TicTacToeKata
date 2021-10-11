using TicTacToeKata;

namespace TicTacToeUnitTest.Model
{
    public class MockGameRules : IGameRules
    {
        public string[,] PlayerMove(string[,] gameBoard, string coord, Player currentPlayer, bool playerOnesTurn)
        {
            gameBoard[1,1] = "X";
            currentPlayer.CurrentCoords.Add("1,1");
            return gameBoard;
        }

        public bool CheckForWinner(WinConditions winConditions, Player currentPlayer)
        {
            return true;
        }

        public bool CheckIfValidMove(string userInput, Player playerOne, Player playerTwo)
        {
            return true;
        }
    }
}