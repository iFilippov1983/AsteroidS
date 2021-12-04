using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public class ScoreCountController:IInitialization, IExecute, ICleanup
    {
        private UIInitialize _uiInitialize;
        private ScoreCountView _scoreCountView;
        private TextMeshProUGUI _scoreDisplay;
        private int _score;
        private string _message;

        public ScoreCountController(GameData gameData, UIInitialize uiInitialize)
        {
            _uiInitialize = uiInitialize;
            _message = gameData.UIData.ScoreMessage;
            _score = gameData.UIData.ScoreHolder;
        }

        public void Cleanup()
        {
        }

        public void Initialize()
        {
            _scoreCountView = _uiInitialize.GetScoreCount();
            _scoreDisplay = _scoreCountView.GetComponent<TextMeshProUGUI>();
        }

        public void Execute(float deltaTime)
        {
            _scoreDisplay.text = $"{_message} {_score}";
        }

        private void AddScore(int addScore)
        {
            _score += addScore;
        }
    }
}