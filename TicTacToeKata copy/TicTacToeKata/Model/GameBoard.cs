namespace TicTacToeKata
{
    public class GameBoard
    {
        public string[,] board { get; set; }
        public void NewGameBoard()
        {
            board = new string[3,3] {{".",".","."},{".",".","."},{".",".","."}};
        }

        public string[,] getGameBoard()
        {
            return board;
        }
    }
}