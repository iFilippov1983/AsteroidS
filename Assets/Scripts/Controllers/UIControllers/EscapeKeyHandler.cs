using System;

namespace AsteroidS
{
    public class EscapeKeyHandler
    {
        private GameStateController _gameStateController;

        public EscapeKeyHandler(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public void EscapeKeyPressed(float cancel)
        {
            if (cancel == 0)
            {
                return;
            }
            
            _gameStateController.ChangeGameState(GameState.Default);
        }
    }
}