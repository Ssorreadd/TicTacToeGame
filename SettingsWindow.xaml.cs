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

            UseSoundManager.IsChecked = ProgramSettings.UseSoundManager;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SoundManager.Play("button");

            ProgramSettings.RandomStartChoiceIsEnabled = (bool)UseRandomGeneration.IsChecked;
            ProgramSettings.AI.IsEnabled = (bool)UseAI.IsChecked;

            ProgramSettings.AI.UsingSymbol = ProgramSettings.AI.IsEnabled ? "╳" : "";

            ProgramSettings.UseSessionManager = (bool)UseSessionData.IsChecked;

            ProgramSettings.UseSoundManager = (bool)UseSoundManager.IsChecked;

        }

        private void SaveAndGoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SessionsWindow_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("button");

            //this.Hide();

            SessionsWindow sessionWindow = new SessionsWindow();
            sessionWindow.ShowDialog();

            if (sessionWindow.SessionWasLoaded)
            {
                Close();
            }

            //this.Show();
        }

        private void Sound_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("button");
        }
    }
}
