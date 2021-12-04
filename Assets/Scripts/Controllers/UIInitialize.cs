﻿using UnityEngine;

namespace AsteroidS
{
    public class UIInitialize:IInitialization
    {
        private GameObject _uiRootPrefab;
        private GameObject _uiRoot;
        
        public UIInitialize(GameData gameData)
        {
            _uiRootPrefab = gameData.UIData.UIRoot;
        }

        public void Initialize()
        {
            if (_uiRoot == null)
                _uiRoot = GameObject.Instantiate(_uiRootPrefab);
        }

        public ScoreCountView GetScoreCount()
        {
            var scoreCountView = _uiRoot.GetComponentInChildren<ScoreCountView>();
            return scoreCountView;
        }

        public TimerCountView GetTimerCount()
        {
            var timerCountView = _uiRoot.GetComponentInChildren<TimerCountView>();
            return timerCountView;
        }
    }
}