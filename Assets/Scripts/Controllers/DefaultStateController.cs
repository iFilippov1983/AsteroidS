using UnityEngine;

namespace AsteroidS
{
    public class DefaultStateController:IInitialization, ICleanup
    {
        private GameStateController _gameStateController;
        
        public DefaultStateController(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public void Initialize()
        {
            _gameStateController.OnDefaultState += DefaultState;
        }

        public void Cleanup()
        {
            _gameStateController.OnDefaultState -= DefaultState;
        }

        private void DefaultState(GameObject mainMenu, GameObject settingsMenu, GameObject playerUI)
        {
            Debug.LogError("Default State");
            Time.timeScale = 0;
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
            playerUI.SetActive(false);
        }
    }
}