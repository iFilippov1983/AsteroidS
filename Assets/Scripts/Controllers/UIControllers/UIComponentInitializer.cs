using UnityEngine;

namespace AsteroidS
{
    public class UIComponentInitializer:IInitialization
    {
        private readonly GameObject _mainMenu;
        private readonly GameObject _settingsMenu;
        private readonly GameObject _playerUI;
        private readonly GameObject _deathScreen;

        private MainMenuView _mainMenuView;
        private SettingMenuView _settingMenuView;
        private PlayerUIView _playerUIView;
        private ScoreCountView _scoreCount;
        private TimerCountView _timerCountView;
        private DeathScreenView _deathScreenView;

        public MainMenuView MainMenuView => _mainMenuView;
        public SettingMenuView SettingMenuView => _settingMenuView;
        public PlayerUIView PlayerUIView => _playerUIView;
        public DeathScreenView DeathScreenView => _deathScreenView;

        public UIComponentInitializer(UIInitializer uiInitializer)
        { 
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
        }
    }
}