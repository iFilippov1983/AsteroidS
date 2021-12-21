using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    public class UIComponentInitializer:IInitialization
    {
        private readonly GameObject _mainMenu;
        private readonly GameObject _settingsMenu;
        private readonly GameObject _playerUI;
        private readonly GameObject _deathScreen;
        private readonly SceneData _sceneData;

        private MainMenuView _mainMenuView;
        private SettingMenuView _settingMenuView;
        private PlayerUIView _playerUIView;
        private DeathScreenView _deathScreenView;

        public MainMenuView MainMenuView => _mainMenuView;
        public SettingMenuView SettingMenuView => _settingMenuView;
        public PlayerUIView PlayerUIView => _playerUIView;
        public DeathScreenView DeathScreenView => _deathScreenView;

        public UIComponentInitializer(GameData gameData, UIInitializer uiInitializer)
        {
            _sceneData = gameData.SceneData;
            _mainMenu = uiInitializer.MainMenu;
            _settingsMenu = uiInitializer.SettingsMenu;
            _playerUI = uiInitializer.PlayerUI;
            _deathScreen = uiInitializer.DeathScreen;
        }

        public void Initialize()
        {
            _mainMenuView = _mainMenu.GetComponent<MainMenuView>();
            _settingMenuView = _settingsMenu.GetComponent<SettingMenuView>();
            _playerUIView = _playerUI.GetComponent<PlayerUIView>();
            _deathScreenView = _deathScreen.GetComponent<DeathScreenView>();
            SetMenuBackground();
        }

        private void SetMenuBackground()
        {
            var sprite = _sceneData.Background.GetComponentInChildren<SpriteRenderer>().sprite;
            
            var mainMenuBackground = _mainMenuView.BackgroundImage;
            var settingsMenuBackground = _settingMenuView.BackgroundImage;
            var deathScreenBackground = _deathScreenView.BackgroundImage;
            
            mainMenuBackground.sprite = sprite;
            settingsMenuBackground.sprite = sprite;
            deathScreenBackground.sprite = sprite;
        }
    }
}