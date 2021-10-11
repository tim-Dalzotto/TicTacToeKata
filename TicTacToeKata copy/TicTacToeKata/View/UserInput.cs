using System;

namespace TicTacToeKata.View
{
    public class UserInput : IUserInput

    {
        public string MoveSelectionUserInput()
        {
            Console.Write("Please enter a coord x,y or enter 'q' to give up:");
            return Console.ReadLine();
        }
    }
}