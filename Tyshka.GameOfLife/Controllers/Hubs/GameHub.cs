using System;
using SignalR.Hubs;
using Tyshka.GameOfLife.Models;

namespace Tyshka.GameOfLife.Controllers.Hubs
{
    [HubName("gameHub")]
    public class GameHub : Hub
    {
        public void Pause()
        {
            GameThreadContainer.Pause();
            Clients.setPaused();
        }

        public void Resume()
        {
            GameThreadContainer.Resume();
            Clients.setResumed();
        }

        public void RequestChanges(int generation)
        {
            var gameDiff = GameState.GetDiff(generation);
            Caller.processDiff(gameDiff);
        }

        public void InvertCell(Point point)
        {
            var color = GameState.InvertCell(point.X, point.Y) ? 1 : 0;
            Clients.sendChangeCell(point.X, point.Y, color);
        }

        public void SetTimeout(int seconds)
        {
            GameThreadContainer.Seconds = seconds;
            Clients.sendTimeoutChange(seconds);
        }
    }
}