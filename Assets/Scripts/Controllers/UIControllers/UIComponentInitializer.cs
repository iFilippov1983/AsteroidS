<<<<<<< HEAD
﻿using UnityEngine;
=======
﻿using AsteroidS.UIView;
using UnityEngine;
using UnityEngine.UI;
>>>>>>> parent of 778962c4 (Merge branch 'UI_by_Nikita_M' into IvanF_work_branch2)

namespace AsteroidS
{
    public class UIComponentInitializer:IInitialization
    {
<<<<<<< HEAD
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
=======
        private GameObject _mainMenu;
        private GameObject _settingsMenu;
        private GameObject _playerUI;

        private ScoreCountView _scoreCount;
        private TimerCountView _timerCountView;
        private StartButtonView _startButton;
        private SettingsMenuButtonView _settingsButton;
        private ExitButtonView _exitButton;
        private BackButtonView _backButton;
        private VolumeSliderView _volumeSlider;
        private ScreenResolutionView _dropdownScreenResolution;
>>>>>>> parent of 778962c4 (Merge branch 'UI_by_Nikita_M' into IvanF_work_branch2)

        public ScoreCountView ScoreCount => _scoreCount;
        public TimerCountView TimerCounter => _timerCountView;
        public StartButtonView StartButton => _startButton;
        public SettingsMenuButtonView SettingsButton => _settingsButton;
        public ExitButtonView ExitButton => _exitButton;
        public BackButtonView BackButton => _backButton;
        public VolumeSliderView VolumeSlider => _volumeSlider;
        public ScreenResolutionView ScreenResolutionDropdown => _dropdownScreenResolution;

        public UIComponentInitializer(UIInitializer uiInitializer)
        { 
            _mainMenu = uiInitializer.MainMenu;
            _settingsMenu = uiInitializer.SettingsMenu;
            _playerUI = uiInitializer.PlayerUI;
        }

        public void Initialize()
        {
<<<<<<< HEAD
            _mainMenuView = _mainMenu.GetComponent<MainMenuView>();
            _settingMenuView = _settingsMenu.GetComponent<SettingMenuView>();
            _playerUIView = _playerUI.GetComponent<PlayerUIView>();
            _deathScreenView = _deathScreen.GetComponent<DeathScreenView>();
=======
            _scoreCount = _playerUI.GetComponentInChildren<ScoreCountView>();
            _timerCountView = _playerUI.GetComponentInChildren<TimerCountView>();
            _startButton = _mainMenu.GetComponentInChildren<StartButtonView>();
            _settingsButton = _mainMenu.GetComponentInChildren<SettingsMenuButtonView>();
            _exitButton = _mainMenu.GetComponentInChildren<ExitButtonView>();
            _backButton = _settingsMenu.GetComponentInChildren<BackButtonView>();
            _volumeSlider = _settingsMenu.GetComponentInChildren<VolumeSliderView>();
            _dropdownScreenResolution = _settingsMenu.GetComponentInChildren<ScreenResolutionView>();
>>>>>>> parent of 778962c4 (Merge branch 'UI_by_Nikita_M' into IvanF_work_branch2)
        }
    }
}