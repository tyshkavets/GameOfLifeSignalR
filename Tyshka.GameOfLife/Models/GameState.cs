using System.Collections.Generic;

namespace Tyshka.GameOfLife.Models
{
    public static  class GameState
    {
        public static List<GameGeneration> Generations = new List<GameGeneration>();

        public static void AddGeneration(GameGeneration generation)
        {
            Generations.Add(generation);
        }

        public static GameDifference GetDiff(int generationIndex)
        {
            return GameDifferenceCalculator.GetGameDifference(Generations[generationIndex], CurrentGeneration, GameState.Generations.Count - 1);
        }

        public static GameGeneration CurrentGeneration
        {
            get
            {
                if (Generations.Count == 0)
                {
                    return new GameGeneration();
                }
                return Generations[Generations.Count - 1];
            }
        }

        public static bool InvertCell(int x, int y)
        {
            var generation = CurrentGeneration;
            generation.Cells[x, y] = !generation.Cells[x, y];
            return generation.Cells[x, y];
        }
    }
}