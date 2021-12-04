using System;
using UnityEngine;

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
        private GameObject _UIRoot;


        private int _scoreHolder;
        private TimeSpan _timeHolder;

        public string ScoreMessage => _scoreMessage;
        public string TimerMessage => _timerMessage;
        public GameObject UIRoot => _UIRoot;

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

