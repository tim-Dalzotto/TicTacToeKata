namespace TicTacToeKata
{
    public class GameBoard
    {
        public string[,] NewGameBoard()
        {
            string[,] gameBoard =  new string[3,3] {{".",".","."},{".",".","."},{".",".","."}};
            return gameBoard;
        }
    }
}