using TMPro;
using UnityEngine;

namespace AsteroidS
{
    internal sealed class DefaultStateController
    {
        private readonly UIComponentInitializer _uiComponentInitializer;
        private readonly GameStateController _gameStateController;
        private readonly GameObject _mainMenu;
        private readonly GameObject _settingsMenu;
        private readonly GameObject _playerUI;
        private readonly GameObject _deathScreen;
        
        private MainMenuView _mainMenuView;
        private TMP_Text _startButtonText;
        private TMP_Text _exitButtonText;

        internal DefaultStateController(UIInitializer uiInitializer,UIComponentInitializer uiComponentInitializer, GameStateController gameStateController)
        {
            _uiComponentInitializer = uiComponentInitializer;
            _gameStateController = gameStateController;
            _mainMenu = uiInitializer.MainMenu;
            _settingsMenu = uiInitializer.SettingsMenu;
            _playerUI = uiInitializer.PlayerUI;
            _deathScreen = uiInitializer.DeathScreen;
        }

        internal void Init()
        {
            _mainMenuView = _uiComponentInitializer.MainMenuView;
            GetUIComponents();
        }

        internal void DefaultState(GameState gameState, GameState previousState)
        {
            if (previousState == GameState.Death)
            {
                _gameStateController.ChangeGameState(GameState.Start);
            }
            else
            {
                Time.timeScale = 0;
                _mainMenu.SetActive(true);
                _settingsMenu.SetActive(false);
                _playerUI.SetActive(false);
                _deathScreen.SetActive(false);
                SetButtons(gameState);
            }
        }

        private void GetUIComponents()
        {
            _startButtonText = _mainMenuView.StartButtonText;
            _exitButtonText = _mainMenuView.ExitButtonText;
        }

        private void SetButtons(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Default:
                    _startButtonText.text = UIObjectName.Start;
                    _exitButtonText.text = UIObjectName.Exit;
                    break;
                case GameState.Pause:
                    _startButtonText.text = UIObjectName.Continue;
                    _exitButtonText.text = UIObjectName.ToMainMenu;
                    break;
            }
        }
    }
}