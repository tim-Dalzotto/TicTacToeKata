using System.Collections.Generic;

namespace TicTacToeKata
{
    public class WinConditions : IWinConditions

    {
    public List<string> WinList = new List<string>()
    {
        //vertical
        "1,1 1,2 1,3", "2,1 2,2 2,3", "3,1 3,2 3,3",
        //horizontal
        "1,1 2,1 3,1", "1,2 2,2 3,2", "1,3 2,3 3,3",
        //diagonal
        "1,1 2,2 3,3", "3,1 2,2 1,3"
    };
    }
}