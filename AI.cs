using System;
using System.Windows.Controls;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class AI
    {
        internal bool IsEnabled { get; set; }
        internal byte Difficult { get; set; }
        internal string UsingSymbol { get; set; }

        internal AI SetDefaultSettings()
        {
            return new AI()
            {
                IsEnabled = false,
                Difficult = 0
            };
        }

        internal void DoStep(ref string[,] gameBoard, ref Grid grid)
        {
            if (!IsEnabled)
            {
                return;
            }

            List<string> nullCells = new List<string>();

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i,j] == null)
                    {
                        nullCells.Add($"Cell{i}{j}");
                    }
                }
            }

            string step = nullCells[new Random().Next(0, nullCells.Count)];

            gameBoard[int.Parse(step[step.Length - 2].ToString()), int.Parse(step[step.Length - 1].ToString())] = UsingSymbol;


            foreach (var cell in grid.Children)
            {
                if (cell is Label)
                {
                    if (((Label)cell).Name.Equals(step))
                    {
                        ((Label)cell).Content = UsingSymbol;
                    }
                }
            }
        }
    }
}
