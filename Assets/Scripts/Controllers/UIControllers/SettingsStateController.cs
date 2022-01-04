using UnityEngine;

namespace AsteroidS
{
    internal sealed class SettingsStateController
    {
        private readonly GameObject _mainMenu;
        private readonly GameObject _settingsMenu;
        private readonly GameObject _playerUI;
        private readonly GameObject _deathScreen;
        internal SettingsStateController(UIInitializer uiInitializer)
        {
            _mainMenu = uiInitializer.MainMenu;
            _settingsMenu = uiInitializer.SettingsMenu;
            _playerUI = uiInitializer.PlayerUI;
            _deathScreen = uiInitializer.DeathScreen;
        }
        internal void SettingsMenu() 
        {
            Time.timeScale = 0;
            _mainMenu.SetActive(false);
            _settingsMenu.SetActive(true);
            _playerUI.SetActive(false);
            _deathScreen.SetActive(false);
        }
    }
}
