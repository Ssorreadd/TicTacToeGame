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

        private string PrevStep { get; set; }

        internal AI SetDefaultSettings()
        {
            return new AI()
            {
                IsEnabled = false,
                Difficult = 0
            };
        }

        private string RandomStep(ref string[,] gameBoard)
        {
            List<string> nullCells = new List<string>();

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == null)
                    {
                        nullCells.Add($"Cell{i}{j}");
                    }
                }
            }

            return nullCells[new Random().Next(0, nullCells.Count)];
        }

        internal void DoStep(ref string[,] gameBoard, ref Grid grid)
        {
            if (!IsEnabled)
            {
                return;
            }

            string step = null;

            if (PrevStep == null)
            {
                //step = RandomStep(ref gameBoard);
            }
            else
            {
                //int i = PrevStep[PrevStep.Length - 2];
                //int j = PrevStep[PrevStep.Length - 1];

                //if (gameBoard[])
                //{

                //}
            }



            step = RandomStep(ref gameBoard);

            gameBoard[int.Parse(step[step.Length - 2].ToString()), int.Parse(step[step.Length - 1].ToString())] = UsingSymbol;

            PrevStep = step;

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
