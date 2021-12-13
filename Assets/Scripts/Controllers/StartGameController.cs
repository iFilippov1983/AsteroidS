using UnityEngine;

namespace AsteroidS
{
    public class StartGameController: IInitialization, ICleanup
    {
        private GameStateController _gameStateController;
        
        public StartGameController(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }


        public void Initialize()
        {
            _gameStateController.OnStartClicked += StartGame;
        }

        public void Cleanup()
        {
            _gameStateController.OnStartClicked -= StartGame;
        }

        private void StartGame(GameObject mainMenu, GameObject settingsMenu, GameObject playerUI)
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(false);
            playerUI.SetActive(true);
            Time.timeScale = 1;
        }
    }
}