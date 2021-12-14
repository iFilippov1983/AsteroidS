using System;
using UnityEngine;
using UnityEngine.Events;

namespace AsteroidS
{
    public class GameStateController:IInitialization, ICleanup
    {
        public event Action<GameObject, GameObject, GameObject> OnStartClicked = delegate {  };
        public event Action<GameObject, GameObject, GameObject> OnSettingslicked = delegate {  };
        public event Action<GameObject, GameObject, GameObject> OnExitClicked = delegate {  };
        public event Action<GameObject, GameObject, GameObject> OnPauseClicked = delegate {  };
        public event Action<GameObject, GameObject, GameObject> OnDefaultState = delegate {  };
        
        private MainMenuController _mainMenuController;
        private StartGameController _startGameController;
        private DefaultStateController _defaultStateController;
        private GameObject _mainMenu;
        private GameObject _playerUI;
        private GameObject _settingsMenu;

        public GameStateController(UIInitializer uiInitializer, UIComponentInitializer uiComponentInitializer)
        {
            _mainMenu = uiInitializer.MainMenu;
            _playerUI = uiInitializer.PlayerUI;
            _settingsMenu = uiInitializer.SettingsMenu;
            _mainMenuController = new MainMenuController(uiComponentInitializer, this);
            _startGameController = new StartGameController(this);
            _defaultStateController = new DefaultStateController(this);
        }

        public void Initialize()
        {
            _mainMenuController.Initialize();
            _defaultStateController.Initialize();
            _startGameController.Initialize();
            ChangeGameState(GameState.Default);
        }

        public void Cleanup()
        {
            _mainMenuController.Cleanup();
            _defaultStateController.Cleanup();
            _startGameController.Cleanup();
        }

        public void ChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Start:
                    OnStartClicked?.Invoke(_mainMenu, _settingsMenu, _playerUI);
                    break;
                case GameState.Settings:
                    break;
                case GameState.Pause:
                    break;
                case GameState.Exit:
                    Application.Quit();
                    break;
                case GameState.Default:
                    OnDefaultState?.Invoke(_mainMenu,_settingsMenu,_playerUI);
                    break;
            }
        }
    }
}