using System;
using System.Collections.Generic;
using TicTacToeKata.View;

namespace TicTacToeKata.Controller
{
    public class GameController
    {
        private readonly GameBoard _gameBoard;
        private readonly IGameRules _gameRules;
        private readonly IUserInput _input;
        private readonly IOutput _output;
        private readonly WinConditions _winConditions;

        public GameController(IGameRules gameRules, GameBoard gameBoard, IUserInput input, IOutput output, WinConditions winConditions)
        {
            _gameRules = gameRules;
            _gameBoard = gameBoard;
            _input = input;
            _output = output;
            _winConditions = winConditions;
        }
        public Player PlayGame(Player playerOne, Player playerTwo, GameBoard gameBoard)
        {
            
            var currentPlayer = playerOne;
            var playerOnesTurn = true;
            var continueGame = true;
            
            while (continueGame == true)
            {
                _output.DisplayGameBoard(gameBoard);
                var moveSelectionUserInput = "";
                while (true)
                { 
                    moveSelectionUserInput = _input.MoveSelectionUserInput();
                    
                    if (_gameRules.CheckIfValidMove(moveSelectionUserInput, playerOne, playerTwo) == true)
                        break;
                    _output.DisplayInvalidInput();
                }
                
                gameBoard = _gameRules.PlayerMove(gameBoard, moveSelectionUserInput, currentPlayer, playerOnesTurn);
                _gameRules.UpdatePlayerMoveList(currentPlayer, moveSelectionUserInput);

                if (_gameRules.CheckForWinner(_winConditions, currentPlayer) == true)
                {
                    _output.DisplayWinner(currentPlayer);
                    _output.DisplayGameBoard(gameBoard);
                    continueGame = false;
                    continue;
                }
                if (playerOnesTurn == true)
                {
                    currentPlayer = playerTwo;
                    playerOnesTurn = false;
                }
                else
                {
                    currentPlayer = playerOne;
                    playerOnesTurn = true;
                }
            }
            return currentPlayer;
        }
    }
}