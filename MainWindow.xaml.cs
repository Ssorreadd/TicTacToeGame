﻿using System;
using System.Windows;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Cross = "╳";
        private const string Zero = "◯";

        private bool _emulatorIsWork = false;

        private string SymbolNow { get; set; }

        private Border EndScreen { get; set; }

        private string[,] GameBoard = null;

        public MainWindow()
        {
            InitializeComponent();

            Visibility = Visibility.Hidden;

            StartWindow startWindow = new StartWindow();
            startWindow.ShowDialog();

            Visibility = Visibility.Visible;

            ProgramSettings.Load();

            UpdateLog();

            NewGame();
        }

        private void UpdateLog(string winner = null)
        {
            if (winner != null)
            {
                switch (winner)
                {
                    case Cross:
                        SessionManager.session.CrossWins++;
                        break;
                    case Zero:
                        SessionManager.session.ZeroWins++;
                        break;
                    case "draw":
                        SessionManager.session.DrawCount++;
                        break;
                }

                SessionManager.session.GamesPlayed++;
            }

            Log.Text = $"Ничья: {SessionManager.session.DrawCount}\n\n" + 
                $"Побед \"{Cross}\": {SessionManager.session.CrossWins}\n\n" +
                $"Побед \"{Zero}\": {SessionManager.session.ZeroWins}\n\n" +
                $"Партий сыграно: {SessionManager.session.GamesPlayed}";
        }

        private void NewGame()
        {
            UpdateLog();

            GameBoard = new string[3, 3];

            switch (ProgramSettings.RandomStartChoiceIsEnabled)
            {
                case true:
                    SymbolNow = new Random().Next(0, 3) == 1 ? Cross : Zero;
                    break;
                case false:
                    SymbolNow = Cross;
                    break;
            }

            if (ProgramSettings.AI.IsEnabled && !_emulatorIsWork)
            {
                AiEmulator();
            }

            foreach (var cell in MainGrid.Children)
            {
                if (cell is Label)
                    ((Label)cell).Content = "";
            }

            UpdateStepNowLabel();
        }

        private void UpdateStepNowLabel() => StepNow.Text = $"Сейчас ходит: {SymbolNow}";

        private bool IsEmptyCells(string mode)
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                int elementsCount = 0;

                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (mode == "horiz" ? GameBoard[i, j] != null : GameBoard[j, i] != null)
                    {
                        elementsCount++;
                    }

                    if (elementsCount == 3)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool HorizontalOrVerticalCheckOut(string symbol, string mode)
        {
            if (!IsEmptyCells(mode))
            {
                for (int i = 0; i < GameBoard.GetLength(0); i++)
                {
                    int threeInRow = 1;
                    string prevSymbol = mode == "horiz" ? GameBoard[i, 0] : GameBoard[0, i];

                    if (prevSymbol == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < GameBoard.GetLength(1); j++)
                    {
                        prevSymbol = mode == "horiz" ? GameBoard[i, j] : GameBoard[j, i];

                        try
                        {
                            if (symbol == prevSymbol)
                            {
                                if (mode == "horiz" ? prevSymbol == GameBoard[i, j + 1] : prevSymbol == GameBoard[j + 1, i])
                                {
                                    //prevSymbol = mode == "horiz" ? GameBoard[i, j] : GameBoard[j, i];
                                    threeInRow++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        catch
                        {
                        }

                        if (threeInRow == 3)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool DiagonalCheckOut(string symbol)
        {
            if (GameBoard[0, 0] != null && GameBoard[1, 1] != null && GameBoard[2, 2] != null)
            {
                int threeInRow = 1;
                string prevSymbol = GameBoard[0, 0];

                for (int i = 1; i < 3; i++)
                {
                    if (prevSymbol == GameBoard[i, i] && prevSymbol == symbol)
                    {
                        prevSymbol = GameBoard[i, i];
                        threeInRow++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (threeInRow == 3)
                {
                    return true;
                }
            }

            if (GameBoard[0, 2] != null && GameBoard[1, 1] != null && GameBoard[2, 0] != null)
            {
                if (GameBoard[0, 2] == symbol)
                {
                    if (GameBoard[0, 2] == GameBoard[1, 1] && GameBoard[1, 1] == symbol)
                    {
                        if (GameBoard[1, 1] == GameBoard[2, 0] && GameBoard[2, 0] == symbol)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void Bingo()
        {
            if (HorizontalOrVerticalCheckOut(Cross, "horiz") || HorizontalOrVerticalCheckOut(Cross, "vert") || DiagonalCheckOut(Cross))
            {
                UpdateLog(Cross);
                CreateEndScreen(Cross);
            }
            else if (HorizontalOrVerticalCheckOut(Zero, "horiz") || HorizontalOrVerticalCheckOut(Zero, "vert") || DiagonalCheckOut(Zero))
            {
                UpdateLog(Zero);
                CreateEndScreen(Zero);
            }
            else if (ItDraw())
            {
                UpdateLog("draw");
                CreateEndScreen("draw");
            }
        }

        private void CreateEndScreen(string winner)
        {
            string endMessage = "";

            switch (winner)
            {
                case Cross:
                    endMessage = $"Поздравим {Cross} с победой!";
                    break;
                case Zero:
                    endMessage = $"Поздравим {Zero} с победой!";
                    break;
                case "draw":
                    endMessage = $"Ого!\nДа у нас тут ничья";
                    break;
            }

            EndScreen = new Border()
            {
                Name = "EndScreenBorder",
                Opacity = 0.50,
                Margin = new Thickness(0, 50, 0, 50),
                Background = new SolidColorBrush(Color.FromRgb(0, 0, 0)),

                Child = new Label()
                {
                    FontSize = 40,
                    Content = endMessage,
                    Foreground = new SolidColorBrush(Color.FromRgb(225, 225, 225)),
                    FontFamily = new FontFamily("Segoe UI"),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                }
            };

            Grid.SetRow(EndScreen, 1);
            Grid.SetColumn(EndScreen, 0);
            Grid.SetRowSpan(EndScreen, 3);
            Grid.SetColumnSpan(EndScreen, 7);

            SoundManager.Play("end");

            MainGrid.Children.Add(EndScreen);
        }

        private void CloseEndScreen_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (EndScreen != null)
            {
                MainGrid.Children.Remove(EndScreen);
                EndScreen = null;

                NewGame();
            }
        }

        private bool IsHaveValue(object sender) => !string.IsNullOrEmpty(((Label)sender).Content.ToString());

        private void Cells_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsHaveValue(sender) && !SymbolNow.Equals(ProgramSettings.AI.UsingSymbol))
            {
                string senderName = ((Label)sender).Name;

                ((Label)sender).Content = SymbolNow;
                GameBoard[int.Parse(senderName[senderName.Length - 2].ToString()), int.Parse(senderName[senderName.Length - 1].ToString())] = SymbolNow;

                SoundManager.Play(SymbolNow);

                SymbolNow = SymbolNow == Cross ? Zero : Cross;

                UpdateStepNowLabel();

                Bingo();
            }
        }

        private bool ItDraw()
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i, j] == null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("button");

            //Hide();

            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
            
            //Show();

            NewGame();
        }

        private async void AiEmulator()
        {
            await Task.Run(() =>
            {
                _emulatorIsWork = true;

                while (ProgramSettings.AI.IsEnabled)
                {
                    Thread.Sleep(500);

                    if (EndScreen == null && ProgramSettings.AI.UsingSymbol.Equals(SymbolNow))
                    {
                        Thread.Sleep(500);

                        Dispatcher.Invoke(() =>
                        {
                            ProgramSettings.AI.DoStep(ref GameBoard, ref MainGrid);

                            SoundManager.Play(SymbolNow);

                            SymbolNow = SymbolNow == Cross ? Zero : Cross;

                            UpdateStepNowLabel();

                            Bingo();
                        });
                    }
                }

                _emulatorIsWork = false;
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ProgramSettings.Save();

            if (ProgramSettings.UseSessionManager)
            {
                SessionManager.Add();
            }
        }
    }
}