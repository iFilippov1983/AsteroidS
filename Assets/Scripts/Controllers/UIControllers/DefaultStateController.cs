using TMPro;
using UnityEngine;

namespace AsteroidS
{
    internal class DefaultStateController
    {
        private readonly UIComponentInitializer _uiComponentInitializer;
        private readonly GameObject _mainMenu;
        private readonly GameObject _settingsMenu;
        private readonly GameObject _playerUI;
        private readonly GameObject _deathScreen;
        
        private MainMenuView _mainMenuView;
        private TMP_Text _startButtonText;
        private TMP_Text _exitButtonText;

        internal DefaultStateController(UIInitializer uiInitializer,UIComponentInitializer uiComponentInitializer)
        {
            _uiComponentInitializer = uiComponentInitializer;
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

        internal void DefaultState(GameState gameState)
        {
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
            switch (gameState)
            {
                case GameState.Default:
                    _startButtonText.text = UIObjectNames.Start;
                    _exitButtonText.text = UIObjectNames.Exit;
                    break;
                case GameState.Pause:
                    _startButtonText.text = UIObjectNames.Continue;
                    _exitButtonText.text = UIObjectNames.ToMainMenu;
                    break;
            }
        }
    }
}