using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public class ScoreCountController:IInitialization, IExecute
    {
        private UIInitializer _uiInitialize;
        private ScoreCountView _scoreCountView;
        private TextMeshProUGUI _scoreDisplay;
        private int _score;
        private string _message;

        public ScoreCountController(GameData gameData, UIInitializer uiInitialize)
        {
            _uiInitialize = uiInitialize;
            _message = gameData.UIData.ScoreMessage;
            _score = gameData.UIData.ScoreHolder;
        }

        public void Initialize()
        {
            _scoreCountView = _uiInitialize.GetScoreCount();
            _scoreDisplay = _scoreCountView.GetComponent<TextMeshProUGUI>();
        }

        public void Execute(float deltaTime)
        {
            DisplayScores();
        }

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;

            //temp
            Debug.Log($"Got scores: {_score}");
        }

        private void DisplayScores()
        {
            _scoreDisplay.text = $"{_message} {_score}";
        }

        
    }
}