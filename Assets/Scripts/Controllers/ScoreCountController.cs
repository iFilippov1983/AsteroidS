using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public class ScoreCountController:IInitialization, IExecute, ICleanup
    {
        private UIInitializer _uiInitializer;
        private ScoreCountView _scoreCountView;
        private TextMeshProUGUI _scoreDisplay;
        private int _score;
        private string _message;

        public ScoreCountController(GameData gameData, UIInitializer uiInitializer)
        {
            _uiInitializer = uiInitializer;
            _message = gameData.UIData.ScoreMessage;
            _score = gameData.UIData.ScoreHolder;
        }

        public void Initialize()
        {
            _scoreCountView = _uiInitializer.GetScoreCount();
            _scoreDisplay = _scoreCountView.GetComponent<TextMeshProUGUI>();
        }

        public void Execute(float deltaTime)
        {
            DisplayScores();
        }

        public void Cleanup()
        {

        }

        public void AddScore(int scoreToAdd)
        {
            //temp
            Debug.Log($"Got scores: {_score}");
            
            _score += scoreToAdd;
        }

        private void DisplayScores()
        {
            _scoreDisplay.text = $"{_message} {_score}";
        }

        
    }
}