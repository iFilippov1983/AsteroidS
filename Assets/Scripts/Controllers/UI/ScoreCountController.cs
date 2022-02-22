using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public sealed class ScoreCountController
    {
        private TextMeshProUGUI _scoreDisplay;
        private int _score;
        private string _message;

        public ScoreCountController(UIData uiData, TextMeshProUGUI scoreCount)
        {
            _scoreDisplay = scoreCount;
            _message = uiData.ScoreMessage;
            _score = uiData.ScoreHolder;
        }

        public void Execute()
        {
            DisplayScores();
        }

        public void AddScore(SpaceObject so)
        {
            _score += so.Properties.ScoresForDestrustion;
        }

        private void DisplayScores()
        {
            _scoreDisplay.text = $"{_message} {_score}";
        }
    }
}