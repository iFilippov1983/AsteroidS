using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public class ScoreCountController:IInitialization, IExecute, ICleanup
    {
        private readonly ScoreCountView _scoreCountView;
        private TextMeshProUGUI _scoreDisplay;
        private int _score;
        private string _message;

        public ScoreCountController(GameData gameData)
        {
            _scoreCountView = gameData.UIData.UiRoot.GetComponentInChildren<ScoreCountView>();
            _scoreDisplay = _scoreCountView.GetComponent<TextMeshProUGUI>();
            _message = gameData.UIData.ScoreMessage;
            _score = gameData.UIData.ScoreHolder;
        }

        public void Cleanup()
        {
        }

        public void Initialize()
        {
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