namespace TicTacToeKata.View
{
    public interface IOutput
    {
        void DisplayGameBoard(GameBoard gameBoard);

        void DisplayWinner(Player currentPlayer);

        void DisplayInvalidInput();
        
    }
}