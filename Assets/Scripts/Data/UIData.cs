using System;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/UIData", fileName = "UIData")]
    public sealed class UIData : ScriptableObject
    {
        [Header("Text constant")] 
        [SerializeField]
        private string _scoreMessage = "Score:";

        [SerializeField] 
        private string _timerMessage = "Time alive:";

        [Header("Player UI for Windows")]
        [Tooltip("Drad&drop here UIRootView")] [SerializeField]
        private GameObject _playerUI;

        [Header("Player UI for Android")]
        [Tooltip("Drad&drop here UIRootView for Android")] [SerializeField]
        private GameObject _playerUIAndroid;

        [Header("Menu objects")] 
        [Tooltip("Drag&drop here MainMenu object")] [SerializeField]
        private GameObject _mainMenu;

        [Tooltip("Drag&drop here SettingsMenu object")] [SerializeField]
        private GameObject _settingsMenu;
        
        [Tooltip("Drag&drop here Death screen object")] [SerializeField]
        private GameObject _deathScreen;



        private int _scoreHolder;
        private TimeSpan _timeHolder;

        public string ScoreMessage => _scoreMessage;
        public string TimerMessage => _timerMessage;
        
        public GameObject PlayerUI
        {
            get
            {
#if UNITY_ANDROID
                return _playerUIAndroid;
#elif UNITY_STANDALONE
                return _playerUI;
#endif
            }
        }

        public GameObject MainMenu => _mainMenu;
        public GameObject SettingsMenu => _settingsMenu;
        public GameObject DeathScreen => _deathScreen;

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

