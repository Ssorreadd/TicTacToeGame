namespace TicTacToe
{
    internal class AI
    {
        internal bool IsEnabled { get; set; }
        internal byte Difficult { get; set; }

        internal AI SetDefaultSettings()
        {
            return new AI()
            {
                IsEnabled = false,
                Difficult = 0
            };
        }
    }
}
