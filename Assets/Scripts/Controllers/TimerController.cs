using System;
using TMPro;

namespace AsteroidS
{
    public class TimerController: IExecute, IInitialization, ICleanup
    {
        private UIComponentInitializer _uiObjectGetter;
        private TimerCountView _timerCountView;
        private TextMeshProUGUI _timerDisplay;
        private TimeSpan _time;
        private float _seconds;
        private string _message;
        private string _deathTime;

        public string DeathTime => _deathTime;

        public TimerController(GameData gameData, UIComponentInitializer uiObjectGetter)
        {
            _uiObjectGetter = uiObjectGetter;
            _time = gameData.UIData.TimeHolder;
            _message = gameData.UIData.TimerMessage;
        }

        public void Initialize()
        {
            _timerCountView = _uiObjectGetter.TimerCounter;
            _timerDisplay = _timerCountView.GetComponent<TextMeshProUGUI>();
        }

        public void Execute(float deltaTime)
        {
            DisplayTimer(deltaTime);
        }

        public void Cleanup()
        {
           
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

            _timerDisplay.text = $"{_message}{_time.Hours:00}:{_time.Minutes:00}:{_time.Seconds:00}";
        }
    }
}