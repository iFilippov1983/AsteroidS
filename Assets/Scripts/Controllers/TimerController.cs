using System;
using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public class TimerController: IExecute, IInitialization, ICleanup
    {
        private TextMeshProUGUI _timerDisplay;
        private bool _isGameStarted;

        public TimerController(TimerCountView timerDisplay)
        {
            _timerDisplay = timerDisplay.GetComponent<TextMeshProUGUI>();
        }

        public void Execute(float deltaTime)
        {
            var timeSpan = deltaTime;
            _timerDisplay.text = $"Time: {timeSpan}";
        }

        public void Initialize()
        {
            
        }

        public void Cleanup()
        {
           
        }

        private void GameStart(bool value)
        {
            _isGameStarted = value;
        }
    }
}