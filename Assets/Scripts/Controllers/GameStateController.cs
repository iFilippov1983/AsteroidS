using System;

namespace AsteroidS
{
    public class GameStateController
    {

        public event Action OnStartGame = () => { };
        public event Action OnSettingsCalled = () => { };
        public event Action OnPauseCalled = () => { };
        public event Action OnExit = () => { }; 

        public GameStateController(GameState gameState)
        {
        }

        private void ChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Start:
                    OnStartGame?.Invoke();
                    break;
                case GameState.Settings:
                    OnSettingsCalled?.Invoke();
                    break;
                case GameState.Pause:
                    OnPauseCalled?.Invoke();
                    break;
                case GameState.Exit:
                    OnExit?.Invoke();
                    break;
            }
        }
    }
}