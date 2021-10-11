using System;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace TicTacToeKata
{
    public class GameRule : IGameRules
    {
        public string[,] PlayerMove(string[,] gameBoard, string coord, Player currentPlayer, bool playerOneTurn)
        {
            var playerSymbol = "X";
            if (playerOneTurn == false)
                playerSymbol = "O";
                
            var xYCoord = coord.Split(',').ToArray();
            gameBoard[int.Parse(xYCoord[0]) - 1, int.Parse(xYCoord[1]) - 1] = playerSymbol;
            //currentPlayer.CurrentCoords.Add(coord);
            return gameBoard;
        }

        public void UpdatePlayerMoveList(Player currentPlayer, string coord)
        {
            currentPlayer.CurrentCoords.Add(coord);
        }

        public bool CheckForWinner(WinConditions winConditions, Player player)
        {
            //var playerCoordsString = string.Join(" ", player.CurrentCoords);
            foreach (var condition in winConditions.WinList)
            {
                var splitCondition = condition.Split(' ');
                var count = 0;
                foreach (var coord in player.CurrentCoords)
                {
                    if (splitCondition.Any(c => c == coord))
                        count++;
                }
                if (count == 3)
                {
                    return true;
                }
                
            }
            return false;
        }

        public bool CheckIfValidMove(string userInput, Player playerOne, Player playerTwo)
        {
            string pattern = @"[123],[123]";
            Regex rg = new Regex(pattern);
            if (rg.IsMatch(userInput) && playerOne.CurrentCoords.All(coord => coord != userInput) && 
                playerTwo.CurrentCoords.All(c => c != userInput))
                return true;
            if (userInput == "q")
                Environment.Exit(0);
            return false;
        }
        
    }
}