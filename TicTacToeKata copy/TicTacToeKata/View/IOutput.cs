namespace TicTacToeKata.View
{
    public interface IOutput
    {
        void DisplayGameBoard(string[,] gameBoard);

        void DisplayWinner(Player currentPlayer);

        void DisplayInvalidInput();
        
    }
}