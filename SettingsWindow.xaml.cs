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
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ProgramSettings.RandomStartChoiceIsEnabled = (bool)UseRandomGeneration.IsChecked;
        }
    }
}
