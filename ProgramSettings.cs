namespace TicTacToe
{
    internal static class ProgramSettings
    {
        internal static AI AI { get; set; }
        internal static bool RandomStartChoiceIsEnabled { get; set; }

        internal static void SetDefaultSettings()
        {
            AI = new AI()
            {
                IsEnabled = false,
                Difficult = 0,
                UsingSymbol = ""
            };

            RandomStartChoiceIsEnabled = false;
        }
    }
}
