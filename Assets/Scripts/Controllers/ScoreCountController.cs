using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public class ScoreCountController:IInitialization, IExecute, ICleanup
    {
        private UIObjectGetterController _uiObjectGetter;
        private ScoreCountView _scoreCountView;
        private TextMeshProUGUI _scoreDisplay;
        private int _score;
        private string _message;

        public ScoreCountController(GameData gameData, UIObjectGetterController uiObjectGetter)
        {
            _uiObjectGetter = uiObjectGetter;
            _message = gameData.UIData.ScoreMessage;
            _score = gameData.UIData.ScoreHolder;
        }

        public void Initialize()
        {
            _scoreCountView = _uiObjectGetter.ScoreCount;
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