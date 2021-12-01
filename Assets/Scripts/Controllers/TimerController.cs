using System;
using TMPro;

namespace AsteroidS
{
    public class TimerController: IExecute, IInitialization, ICleanup
    {
        private const string _message = "Time alive: ";
        private TextMeshProUGUI _timerDisplay;
        private TimeSpan _time;
        private float _seconds;
        private string _aliveTime;
        private bool _isGameStarted;

        public TimerController(TimerCountView timerDisplay)
        {
            _timerDisplay = timerDisplay.GetComponent<TextMeshProUGUI>();
        }

        public void Execute(float deltaTime)
        {
            _seconds += deltaTime;
            _time = TimeSpan.FromSeconds(_seconds);
                
            _timerDisplay.text = $"{_message}{_time.Hours:00}:{_time.Minutes:00}:{_time.Seconds:00}";
        }

        public void Initialize()
        {
            
        }

        public void Cleanup()
        {
           
        }

        private void PlayerDead(bool dead)
        {
            if (dead)
                _aliveTime = $"{_time.Hours:00}:{_time.Minutes:00}:{_time.Seconds:00}";
        }

        public string TimeAlive => _aliveTime;
    }
}