using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    public class MainMenuController
    {
        private UIData _uiData;
        private GameObject _mainMenu;
        private GameObject _settingsMenu;

        private Button _startButton;
        private Button _settingsButton;
        private Button _exitButton;
        
        public MainMenuController(GameData gameData, GameStateController gameStateController)
        {
            _uiData = gameData.UIData;
            _mainMenu = _uiData.MainMenu;
            _settingsMenu = _uiData.SettingsMenu;
        }
    }
}