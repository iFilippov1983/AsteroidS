using TMPro;
using UnityEngine;

namespace AsteroidS
{
    internal sealed class DefaultStateController
    {
        private readonly GameObject _mainMenu;
        private readonly GameObject _settingsMenu;
        private readonly GameObject _playerUI;
        private readonly GameObject _deathScreen;
        
        private MainMenuView _mainMenuView;
        private TMP_Text _startButtonText;
        private TMP_Text _exitButtonText;

        internal DefaultStateController(UIInitializer uiInitializer, MainMenuView mainMenuView)
        {
            _mainMenuView = mainMenuView;
            _mainMenu = uiInitializer.MainMenu;
            _settingsMenu = uiInitializer.SettingsMenu;
            _playerUI = uiInitializer.PlayerUI;
            _deathScreen = uiInitializer.DeathScreen;
        }

        internal void Init()
        {
            GetUIComponents();
        }

        internal void DefaultState(GameState gameState)
        {
            GetUIComponents();
            Time.timeScale = 0;
            _mainMenu.SetActive(true);
            _settingsMenu.SetActive(false);
            _playerUI.SetActive(false);
            _deathScreen.SetActive(false);
            SetButtons(gameState);
        }

        private void GetUIComponents()
        {
            _startButtonText = _mainMenuView.StartButtonText;
            _exitButtonText = _mainMenuView.ExitButtonText;
        }

        private void SetButtons(GameState gameState)
        {
            if (gameState == GameState.Default)
            {
                _startButtonText.text = UIObjectName.Start;
                _exitButtonText.text = UIObjectName.Exit;
            }
            else if (gameState == GameState.Pause)
            {
                _startButtonText.text = UIObjectName.Continue;
                _exitButtonText.text = UIObjectName.ToMainMenu;
            }
        }
    }
}