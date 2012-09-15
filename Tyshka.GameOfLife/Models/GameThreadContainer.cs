using System.Threading;

namespace Tyshka.GameOfLife.Models
{
    public static class GameThreadContainer
    {
        private static Thread _gameThread;

        private static bool _paused;

        public static int Seconds { get; set; }

        public static void StartThread(ThreadStart threadDelegate)
        {
            _gameThread = new Thread(threadDelegate);
            _gameThread.Start();
            Seconds = 10;
        }

        public static void Pause()
        {
            if (!_paused)
            {
                _paused = true;
                _gameThread.Suspend();
            }
        }

        public static void Resume()
        {
            if (_paused)
            {
                _paused = false;
                _gameThread.Resume();   
            }
        }

        public static bool GetPaused()
        {
            return _paused;
        }
    }
}