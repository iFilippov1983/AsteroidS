using UnityEngine;

namespace AsteroidS
{
    internal sealed class StartGameStateController
    {
        private readonly GameObject _mainMenu;
        private readonly GameObject _settingsMenu;
        private readonly GameObject _playerUI;
        private readonly GameObject _deathScreen;
        
        internal StartGameStateController(UIInitializer uiInitializer)
        {
            _mainMenu = uiInitializer.MainMenu;
            _settingsMenu = uiInitializer.SettingsMenu;
            _playerUI = uiInitializer.PlayerUI;
            _deathScreen = uiInitializer.DeathScreen;
        }
        internal void StartGame()
        {
            _mainMenu.SetActive(false);
            _settingsMenu.SetActive(false);
            _playerUI.SetActive(true);
            _deathScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}