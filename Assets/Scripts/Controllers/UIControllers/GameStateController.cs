using System;
using UnityEngine;
using UnityEngine.Events;

namespace AsteroidS
{
    public class GameStateController:IInitialization
    {
        private readonly DefaultStateController _defaultStateController;
        private readonly StartGameStateController _startGameController;
        private readonly SettingsStateController _settingsStateController;
        private readonly DeathStateController _deathStateController;
        private readonly GameObject _mainMenu;
        private readonly GameObject _playerUI;
        private readonly GameObject _settingsMenu;
        private readonly GameObject _deathScreen;

        public GameStateController(UIInitializer uiInitializer, UIComponentInitializer uiComponentInitializer)
        {
            _mainMenu = uiInitializer.MainMenu;
            _playerUI = uiInitializer.PlayerUI;
            _settingsMenu = uiInitializer.SettingsMenu;
            _deathScreen = uiInitializer.DeathScreen;
            _defaultStateController = new DefaultStateController(uiComponentInitializer);
            _startGameController = new StartGameStateController();
            _settingsStateController = new SettingsStateController();
            _deathStateController = new DeathStateController();
        }

        public void Initialize()
        {
            _defaultStateController.Init();
            ChangeGameState(GameState.Default);
        }

        public void ChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Start:
                    _startGameController.StartGame(_mainMenu, _settingsMenu, _playerUI, _deathScreen);
                    break;
                case GameState.Settings:
                    _settingsStateController.SettingsMenu(_mainMenu, _settingsMenu, _playerUI, _deathScreen);
                    break;
                case GameState.Pause:
                    _defaultStateController.DefaultState(_mainMenu, _settingsMenu, _playerUI, _deathScreen,gameState);
                    break;
                case GameState.Death:
                    _deathStateController.DeathState(_mainMenu, _settingsMenu, _playerUI, _deathScreen);
                    break;
                case GameState.Exit:
                    Application.Quit();
                    break;
                case GameState.Default:
                    _defaultStateController.DefaultState(_mainMenu, _settingsMenu, _playerUI, _deathScreen,gameState);
                    break;
            }
        }
    }
}