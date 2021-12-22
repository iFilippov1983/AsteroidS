using UnityEngine;

namespace AsteroidS
{
    internal class DeathStateController
    {
        private readonly GameObject _mainMenu;
        private readonly GameObject _settingsMenu;
        private readonly GameObject _playerUi;
        private readonly GameObject _deathScreen;

        internal DeathStateController(UIInitializer uiInitializer)
        {
            _mainMenu = uiInitializer.MainMenu;
            _settingsMenu = uiInitializer.SettingsMenu;
            _playerUi = uiInitializer.PlayerUI;
            _deathScreen = uiInitializer.DeathScreen;
        }

        internal void DeathState()
        {
            Time.timeScale = 0;
            _mainMenu.SetActive(false);
            _settingsMenu.SetActive(false);
            _playerUi.SetActive(false);
            _deathScreen.SetActive(true);
        }
    }
}