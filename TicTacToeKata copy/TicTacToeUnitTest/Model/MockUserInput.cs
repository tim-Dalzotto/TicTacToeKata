using TicTacToeKata.View;

namespace TicTacToeUnitTest.Model
{
    public class MockUserInput : IUserInput
    {
        public string MoveSelectionUserInput()
        {
            return "1,1";
        }
    }
}