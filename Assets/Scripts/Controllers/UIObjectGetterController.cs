using UnityEngine;

namespace AsteroidS
{
    public class UIObjectGetterController:IInitialization
    {
        private readonly UIInitializer _uiInitializer;
        private GameObject _mainMenu;
        private GameObject _settingsMenu;
        private GameObject _playerUI;

        private ScoreCountView _scoreCount;
        private TimerCountView _timerCountView;

        public UIObjectGetterController(UIInitializer uiInitializer)
        { 
            _mainMenu = uiInitializer.MainMenu;
            _settingsMenu = uiInitializer.SettingsMenu;
            _playerUI = uiInitializer.PlayerUI;
        }


        public void Initialize()
        {
            
            _scoreCount = GetScoreCount();
            _timerCountView = GetTimerCounter();
        }

        private ScoreCountView GetScoreCount()
        {
            return _playerUI.GetComponentInChildren<ScoreCountView>();
        }

        private TimerCountView GetTimerCounter()
        {
            return _playerUI.GetComponentInChildren<TimerCountView>();
        }

        public ScoreCountView ScoreCount => _scoreCount;
        public TimerCountView TimerCounter => _timerCountView;
    }
}