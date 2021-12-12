using UnityEngine;

namespace AsteroidS
{
    public class StartGameController: IInitialization, ICleanup
    {
        private GameStateController _gameStateController;
        private GameObject _mainMenu;
        private GameObject _levelRootObject;
        
        public StartGameController(UIInitializer uiInitializer, GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _mainMenu = uiInitializer.MainMenu;
        }


        public void Initialize()
        {
            _gameStateController.OnStartGame += StartGame;
        }

        public void Cleanup()
        {
            _gameStateController.OnStartGame -= StartGame;
        }

        private void StartGame()
        {
            _mainMenu.SetActive(false);
            _levelRootObject.SetActive(true);
            Time.timeScale = 1;
        }
    }
}