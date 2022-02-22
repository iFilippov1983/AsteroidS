using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public sealed class ScoreCountController
    {
        private UIComponentInitializer _uiObjectGetter;
        private PlayerUIView _playerUIView;
        private TextMeshProUGUI _scoreDisplay;
        private int _score;
        private string _message;

        public ScoreCountController(UIData uiData, PlayerUIView playerUIView)
        {
            _playerUIView = playerUIView;
            _message = uiData.ScoreMessage;
            _score = uiData.ScoreHolder;
        }

        public void Initialize()
        {
            _scoreDisplay = _playerUIView.ScoreCount;
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