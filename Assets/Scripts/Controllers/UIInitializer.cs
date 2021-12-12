using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public class UIInitializer:IInitialization
    {
        private GameObject _mainMenuPrefab;
        private GameObject _settingsMenuPrefab;
        private GameObject _playerUIPrefab;
        private GameObject _uiRoot;
        private GameObject _mainMenu;
        private GameObject _settingsMenu;
        private GameObject _playerUI;


        public UIInitializer(GameData gameData)
        {
            _playerUIPrefab = gameData.UIData.PlayerUI;
            _mainMenuPrefab = gameData.UIData.MainMenu;
            _settingsMenuPrefab = gameData.UIData.SettingsMenu;
        }

        public void Initialize()
        {
            if (_uiRoot is null)
            {
                _uiRoot = new GameObject(UIObjectNames.UIRoot);
                _mainMenu = GetMainMenu();
                _playerUI = GetPlayerUI();
                _settingsMenu = GetSettingsMenu();
            }
        }

        private GameObject GetSettingsMenu()
        {
            var settingsMenu = Object.Instantiate(_settingsMenuPrefab, _uiRoot.transform);
            settingsMenu.SetActive(false);
            return settingsMenu;
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

        public GameObject PlayerUI => _playerUI;
        public GameObject MainMenu => _mainMenu;

        public GameObject SettingsMenu => _settingsMenu;

        public ScoreCountView GetScoreCount()
        {
            var scoreCountView = _playerUI.GetComponentInChildren<ScoreCountView>();
            return scoreCountView;
        }

        public TimerCountView GetTimerCount()
        {
            var timerCountView = _playerUI.GetComponentInChildren<TimerCountView>();
            return timerCountView;
        }
    }
}