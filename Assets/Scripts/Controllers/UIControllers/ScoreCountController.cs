using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public sealed class ScoreCountController:IInitialization, IExecute
    {
        private UIComponentInitializer _uiObjectGetter;
        private PlayerUIView _playerUIView;
        private TextMeshProUGUI _scoreDisplay;
        private int _score;
        private string _message;

        public ScoreCountController(GameData gameData, UIComponentInitializer uiObjectGetter)
        {
            _uiObjectGetter = uiObjectGetter;
            _message = gameData.UIData.ScoreMessage;
            _score = gameData.UIData.ScoreHolder;
        }

        public void Initialize()
        {
            _playerUIView = _uiObjectGetter.PlayerUIView;
            _scoreDisplay = _playerUIView.ScoreCount;
        }

        public void Execute(float deltaTime)
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