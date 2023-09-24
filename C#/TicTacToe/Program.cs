class Program
{
    static void Main(string[] args)
    {
        TicTacToe ticTacToe = new TicTacToe(3, 3);

        do
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    ticTacToe.MoveCursorUp();
                    ticTacToe.DrawTable();
                    break;
                case ConsoleKey.DownArrow:
                    ticTacToe.MoveCursorDown();
                    ticTacToe.DrawTable();
                    break;
                case ConsoleKey.LeftArrow:
                    ticTacToe.MoveCursorLeft();
                    ticTacToe.DrawTable();
                    break;
                case ConsoleKey.RightArrow:
                    ticTacToe.MoveCursorRight();
                    ticTacToe.DrawTable();
                    break;
                case ConsoleKey.Spacebar:
                    ticTacToe.SetTile();
                    ticTacToe.DrawTable();
                    break;
            }
        } while (ticTacToe.gameState == TicTacToe.STATE.GAME_RUNNING);
    }
}