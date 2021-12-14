using System;
using UnityEngine;
using UnityEngine.Events;

namespace AsteroidS
{
    public class GameStateController:IInitialization, ICleanup
    {        
        private StartGameStateController _startGameController;
        private DefaultStateController _defaultStateController;
        private SettingsStateController _settingsStateController;
        private GameObject _mainMenu;
        private GameObject _playerUI;
        private GameObject _settingsMenu;

        public GameStateController(UIInitializer uiInitializer)
        {
            _mainMenu = uiInitializer.MainMenu;
            _playerUI = uiInitializer.PlayerUI;
            _settingsMenu = uiInitializer.SettingsMenu;
            _startGameController = new StartGameStateController();
            _defaultStateController = new DefaultStateController();
            _settingsStateController = new SettingsStateController();
        }

        public void Initialize()
        {
            ChangeGameState(GameState.Default);
        }

        public void Cleanup()
        {
        }

        public void ChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Start:
                    _startGameController.StartGame(_mainMenu, _settingsMenu, _playerUI);
                    break;
                case GameState.Settings:
                    _settingsStateController.SettingsMenu(_mainMenu, _settingsMenu, _playerUI);
                    break;
                case GameState.Pause:
                    _defaultStateController.DefaultState(_mainMenu, _settingsMenu, _playerUI);
                    break;
                case GameState.Exit:
                    Application.Quit();
                    break;
                case GameState.Default:
                    _defaultStateController.DefaultState(_mainMenu, _settingsMenu, _playerUI);
                    break;
            }
        }
    }
}