namespace TicTacToe
{
    internal static class LogTable
    {
        internal static int CrossWins { get; set; }
        internal static int ZeroWins { get; set; }
        internal static int DrawCount { get; set; }
        internal static int GamesPlayed { get; set; }

        internal static void Clear()
        {
            CrossWins = 0;
            ZeroWins = 0;
            DrawCount = 0;
            GamesPlayed = 0;
        }
    }
}
