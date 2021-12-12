using System;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/UIData", fileName = "UIData")]
    public class UIData : ScriptableObject
    {
        [Header("Text constant")] 
        [SerializeField]
        private string _scoreMessage = "Score:";

        [SerializeField] 
        private string _timerMessage = "Time alive:";

        [Header("UIRoot reference")]
        [Tooltip("Drad&drop here UIRootView")] [SerializeField]
        private GameObject _playerUi;

        [Header("Menu objects")] 
        [Tooltip("Drag&drop here MainMenu object")] [SerializeField]
        private GameObject _mainMenu;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        [Tooltip("Drag&drop here SettingsMenu object")] [SerializeField]
        private GameObject _settingsMenu;

        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private Dropdown _resolutionSettingsDropdown;


        private int _scoreHolder;
        private TimeSpan _timeHolder;

        public string ScoreMessage => _scoreMessage;
        public string TimerMessage => _timerMessage;
        public GameObject PlayerUI => _playerUi;
        public GameObject MainMenu => _mainMenu;
        public GameObject SettingsMenu => _settingsMenu;
        public Button StartButton => _startButton;
        public Button SettingsButton => _settingsButton;
        public Button ExitButton => _exitButton;
        public Button BackButton => _backButton;
        public Slider VolumeSlider => _volumeSlider;
        public Dropdown ResolutionSettingsDropdown => _resolutionSettingsDropdown;

        public int ScoreHolder
        {
            get { return _scoreHolder; }
            internal set { _scoreHolder = value; }
        }

        public TimeSpan TimeHolder
        {
            get { return _timeHolder;}
            internal set { _timeHolder = value; }
        }
    }
}

