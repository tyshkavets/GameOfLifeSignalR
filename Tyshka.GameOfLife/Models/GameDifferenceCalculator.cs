using System.Collections.Generic;

namespace Tyshka.GameOfLife.Models
{
    public static class GameDifferenceCalculator
    {
        public static GameDifference GetGameDifference(GameGeneration old, GameGeneration current, int index)
        {
            var result = new GameDifference {Dead = new List<Point>(), Born = new List<Point>()};
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (old.Cells[i, j] == true && current.Cells[i, j] == false)
                    {
                        result.Dead.Add(new Point { X = i, Y = j });
                    }

                    if (old.Cells[i, j] == false && current.Cells[i, j] == true)
                    {
                        result.Born.Add(new Point { X = i, Y = j });
                    }
                }
            }

            result.CurrentGeneration = index;

            return result;
        }

        public static GameGeneration GetNextGeneration(GameGeneration previous)
        {
            var newGeneration = new GameGeneration();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var neighboursCount = CalculateNeighboursCount(previous, i, j);

                    if (previous.Cells[i, j] == true && neighboursCount >= 2 && neighboursCount <= 3)
                    {
                        newGeneration.Cells[i, j] = true;
                    }

                    if (previous.Cells[i, j] == false && neighboursCount == 3)
                    {
                        newGeneration.Cells[i, j] = true;
                    }
                }
            }

            return newGeneration;
        }

        public static int CalculateNeighboursCount(GameGeneration previous, int x, int y)
        {
            var count = 0;
            if (x > 0 && y > 0 && previous.Cells[x - 1, y - 1])
            {
                count++;                
            }

            if (x > 0 && previous.Cells[x - 1, y])
            {
                count++;
            }

            if (x > 0 && y < 99 && previous.Cells[x - 1, y + 1])
            {
                count++;
            }

            if (y > 0 && previous.Cells[x, y - 1])
            {
                count++;
            }

            if (y < 99 && previous.Cells[x, y + 1])
            {
                count++;
            }

            if (x < 99 && y > 0 && previous.Cells[x + 1, y - 1])
            {
                count++;
            }

            if (x < 99 && previous.Cells[x + 1, y])
            {
                count++;
            }

            if (x < 99 && y < 99 && previous.Cells[x + 1, y + 1])
            {
                count++;
            }

            return count;
        }
    }
}