using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private async void Start()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);

                double tmpOpacity = 0.00;

                while (tmpOpacity <= 1.00)
                {
                    Dispatcher.Invoke(() =>
                    {
                        Opacity = Opacity + 0.01;
                        tmpOpacity = Opacity;
                    });

                    Thread.Sleep(6);
                }

                Thread.Sleep(2000);

                Dispatcher.Invoke(() =>
                {
                    Close();
                });
            });
        }


        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Start();
        }
    }
}
