using AsteroidS.UIView;
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

        private ScoreCountView _scoreCount;
        private TimerCountView _timerCountView;
        private StartButtonView _startButton;
        private SettingsMenuButtonView _settingsButton;
        private ExitButtonView _exitButton;
        private BackButtonView _backButton;
        private VolumeSliderView _volumeSlider;
        private ScreenResolutionView _dropdownScreenResolution;
        private DeathScreenView _deathScreenView;

        public ScoreCountView ScoreCount => _scoreCount;
        public TimerCountView TimerCounter => _timerCountView;
        public StartButtonView StartButton => _startButton;
        public SettingsMenuButtonView SettingsButton => _settingsButton;
        public ExitButtonView ExitButton => _exitButton;
        public BackButtonView BackButton => _backButton;
        public VolumeSliderView VolumeSlider => _volumeSlider;
        public ScreenResolutionView ScreenResolutionDropdown => _dropdownScreenResolution;
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
            _scoreCount = _playerUI.GetComponentInChildren<ScoreCountView>();
            _timerCountView = _playerUI.GetComponentInChildren<TimerCountView>();
            _startButton = _mainMenu.GetComponentInChildren<StartButtonView>();
            _settingsButton = _mainMenu.GetComponentInChildren<SettingsMenuButtonView>();
            _exitButton = _mainMenu.GetComponentInChildren<ExitButtonView>();
            _backButton = _settingsMenu.GetComponentInChildren<BackButtonView>();
            _volumeSlider = _settingsMenu.GetComponentInChildren<VolumeSliderView>();
            _dropdownScreenResolution = _settingsMenu.GetComponentInChildren<ScreenResolutionView>();
            _deathScreenView = _deathScreen.GetComponent<DeathScreenView>();
        }
    }
}