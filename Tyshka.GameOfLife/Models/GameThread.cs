using SignalR;
using Tyshka.GameOfLife.Controllers.Hubs;

namespace Tyshka.GameOfLife.Models
{
    public class GameThread
    {
        public void GenerationCycle()
        {
            while (true)
            {
                var generation = GameDifferenceCalculator.GetNextGeneration(GameState.CurrentGeneration);
                GameState.AddGeneration(generation);

                var context = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
                
                context.Clients.updateGeneration();
                System.Threading.Thread.Sleep(1000*GameThreadContainer.Seconds);
            }
        }
    }
}