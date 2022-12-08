using System;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            UseRandomGeneration.IsChecked = ProgramSettings.RandomStartChoiceIsEnabled;
            UseAI.IsChecked = ProgramSettings.AI.IsEnabled;

            UseSessionData.IsChecked = ProgramSettings.UseSessionManager;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ProgramSettings.RandomStartChoiceIsEnabled = (bool)UseRandomGeneration.IsChecked;
            ProgramSettings.AI.IsEnabled = (bool)UseAI.IsChecked;

            ProgramSettings.AI.UsingSymbol = ProgramSettings.AI.IsEnabled ? "╳" : "";

            ProgramSettings.UseSessionManager = (bool)UseSessionData.IsChecked;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SessionsWindow_Click(object sender, RoutedEventArgs e)
        {
            SessionsWindow sessionWindow = new SessionsWindow();
            sessionWindow.ShowDialog();
        }
    }
}
