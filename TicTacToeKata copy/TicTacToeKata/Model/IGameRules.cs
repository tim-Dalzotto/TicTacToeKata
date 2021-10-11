namespace TicTacToeKata
{
    public interface IGameRules
    {
        string[,] PlayerMove(string[,] gameBoard, string coord, Player currentPlayer, bool playerOneTurn);
        bool CheckForWinner(WinConditions winConditions, Player currentPlayer);
        bool CheckIfValidMove(string userInput, Player playerOne, Player playerTwo);
        void UpdatePlayerMoveList(Player currentPlayer, string coord);
    }
}