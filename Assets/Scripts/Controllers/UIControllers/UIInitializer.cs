using UnityEngine;

namespace AsteroidS
{
    public class UIInitializer
    {
        private readonly GameObject _mainMenuPrefab;
        private readonly GameObject _settingsMenuPrefab;
        private readonly GameObject _playerUIPrefab;
        private readonly GameObject _deathScreenPrefab;
        
        private GameObject _uiRoot;
        private GameObject _mainMenu;
        private GameObject _settingsMenu;
        private GameObject _playerUI;
        private GameObject _deathScreen;
        
        public GameObject PlayerUI => _playerUI;
        public GameObject MainMenu => _mainMenu;
        public GameObject SettingsMenu => _settingsMenu;
        public GameObject DeathScreen => _deathScreen;

        public UIInitializer(GameData gameData)
        {
            _mainMenuPrefab = gameData.UIData.MainMenu;
            _settingsMenuPrefab = gameData.UIData.SettingsMenu;
            _playerUIPrefab = gameData.UIData.PlayerUI;
            _deathScreenPrefab = gameData.UIData.DeathScreen;
            CreateUI();
        }

        private void CreateUI()
        {
            if (_uiRoot is null)
            {
                _uiRoot = new GameObject(UIObjectNames.UIRoot);
                _mainMenu = GetMainMenu();
                _playerUI = GetPlayerUI();
                _settingsMenu = GetSettingsMenu();
                _deathScreen = GetDeathScreen();
            }
        }

        private GameObject GetMainMenu()
        {
            var mainMenu = Object.Instantiate(_mainMenuPrefab, _uiRoot.transform);
            return mainMenu;
        }

        private GameObject GetPlayerUI()
        {
            var playerUI = Object.Instantiate(_playerUIPrefab, _uiRoot.transform);
            return playerUI;
        }

        private GameObject GetSettingsMenu()
        {
            var settingsMenu = Object.Instantiate(_settingsMenuPrefab, _uiRoot.transform);
            return settingsMenu;
        }

        private GameObject GetDeathScreen()
        {
            var deathScreen = Object.Instantiate(_deathScreenPrefab, _uiRoot.transform);
            return deathScreen;
        }
    }
}