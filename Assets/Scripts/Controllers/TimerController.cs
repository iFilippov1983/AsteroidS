using System;
using TMPro;

namespace AsteroidS
{
    public class TimerController: IExecute, IInitialization, ICleanup
    {
        private UIInitialize _uiInitialize;
        private TimerCountView _timerCountView;
        private TextMeshProUGUI _timerDisplay;
        private TimeSpan _time;
        private float _seconds;
        private string _message;
        private string _deathTime;

        public TimerController(GameData gameData, UIInitialize uiInitialize)
        {
            _uiInitialize = uiInitialize;
            _time = gameData.UIData.TimeHolder;
            _message = gameData.UIData.TimerMessage;
        }

        public void Execute(float deltaTime)
        {
            _seconds += deltaTime;
            _time = TimeSpan.FromSeconds(_seconds);
                
            _timerDisplay.text = $"{_message}{_time.Hours:00}:{_time.Minutes:00}:{_time.Seconds:00}";
        }

        public void Initialize()
        {
            _timerCountView = _uiInitialize.GetTimerCount();
            _timerDisplay = _timerCountView.GetComponent<TextMeshProUGUI>();
        }

        public void Cleanup()
        {
           
        }

        private void PlayerDead(bool dead)
        {
            if (dead)
                _deathTime = $"{_time.Hours:00}:{_time.Minutes:00}:{_time.Seconds:00}";
        }

        public string DeathTime => _deathTime;
    }
}