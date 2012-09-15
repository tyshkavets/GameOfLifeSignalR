using System.Collections.Generic;

namespace Tyshka.GameOfLife.Models
{
    public class GameDifference
    {
        public List<Point> Born {get;set;}
        public List<Point> Dead {get;set;}
        public int CurrentGeneration { get; set; }
    }
}