using System;
using System.Windows;
using System.Windows.Controls;

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

            UpdateSource();
        }

        public bool SessionWasLoaded { get; private set; }

        private void UpdateSource()
        {
<<<<<<< HEAD
            var source = SessionManager.ToList();

            if (source.Count != 0)
            {
                SessionsListView.ItemsSource = source;
            }
            else
            {

            }
=======
            SessionsListView.ItemsSource = SessionManager.ToList();
>>>>>>> 1f22c8cf7b34d47147c2aefe5352579b05c74f33
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ClickSound();

            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Предупреждение об удалении", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ClickSound();

                try
                {
                    SessionManager.Delete((SessionType)(sender as Button).DataContext);

                    MessageBox.Show($"Удаление прошло успешно.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClickSound();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    ClickSound();
                }
            }

            ClickSound();

            UpdateSource();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            ClickSound();

            if (MessageBox.Show("Вы уверены, что хотите загрузить запись?\n" +
                "Прогресс текущей сессии будет потерян.\n\n\n" +
                "Прогресс сохраняется автоматически, по закрытию приложения, если включена соответствующая опция.", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ClickSound();

                try
                {
                    SessionManager.LoadOldSession((SessionType)(sender as Button).DataContext);

                    SessionWasLoaded = true;

                    MessageBox.Show($"Загрузка прошла успешно.\n\nВы будите перенаправлены на главный экран после закрытия данного окна.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    ClickSound();
                }
            }

            ClickSound();
            UpdateSource();
        }

        private void ClickSound()
        {
            SoundManager.Play("button");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClickSound();
        }
    }
}
