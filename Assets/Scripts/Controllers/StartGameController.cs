using UnityEngine;

namespace AsteroidS
{
    public class StartGameController: IInitialization, ICleanup
    {
        private GameStateController _gameStateController;
        private GameObject _mainMenu;
        private GameObject _levelRootObject;
        
        public StartGameController(UIInitialize uiInitialize, GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _mainMenu = uiInitialize.MainMenu;
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