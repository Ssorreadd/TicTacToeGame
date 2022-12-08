using System;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для SessionsWindow.xaml
    /// </summary>
    public partial class SessionsWindow : Window
    {
        public SessionsWindow()
        {
            InitializeComponent();

            DGridSessions.ItemsSource = SessionManager.ToList();
        }
    }
}
