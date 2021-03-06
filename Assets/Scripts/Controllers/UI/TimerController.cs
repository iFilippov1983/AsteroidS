using System;
using TMPro;

namespace AsteroidS
{
    public sealed class TimerController
    {
        private UIComponentInitializer _uiComponentInitializer;
        private PlayerUIView _playerUIView;
        private TextMeshProUGUI _timerDisplay;
        private TimeSpan _time;
        private float _seconds;
        private string _message;
        private string _deathTime;

        public string DeathTime => _deathTime;

        public TimerController(GameData gameData, UIComponentInitializer uiComponentInitializer)
        {
            _uiComponentInitializer = uiComponentInitializer;
            _time = gameData.UIData.TimeHolder;
            _message = gameData.UIData.TimerMessage;
        }

        public void Initialize()
        {
            _playerUIView = _uiComponentInitializer.PlayerUIView;
            _timerDisplay = _playerUIView.TimerCount;
        }

        public void Execute(float deltaTime)
        {
            DisplayTimer(deltaTime);
        }

        private void PlayerDead(bool dead)
        {
            if (dead)
                _deathTime = $"{_time.Hours:00}:{_time.Minutes:00}:{_time.Seconds:00}";
        }

        private void DisplayTimer(float deltaTime)
        {
            _seconds += deltaTime;
            _time = TimeSpan.FromSeconds(_seconds);

            _timerDisplay.text = $"{_message}\n\r{_time.Hours:00}:{_time.Minutes:00}:{_time.Seconds:00}";
        }
    }
}