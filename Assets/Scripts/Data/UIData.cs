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
        private GameObject _playerUI;

        [Header("Menu objects")] 
        [Tooltip("Drag&drop here MainMenu object")] [SerializeField]
        private GameObject _mainMenu;

        [Tooltip("Drag&drop here SettingsMenu object")] [SerializeField]
        private GameObject _settingsMenu;


        private int _scoreHolder;
        private TimeSpan _timeHolder;

        public string ScoreMessage => _scoreMessage;
        public string TimerMessage => _timerMessage;
        public GameObject PlayerUI => _playerUI;
        public GameObject MainMenu => _mainMenu;
        public GameObject SettingsMenu => _settingsMenu;

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

