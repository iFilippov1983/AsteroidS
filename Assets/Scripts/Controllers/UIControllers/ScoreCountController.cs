using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public class ScoreCountController:IInitialization, IExecute
    {
        private UIComponentInitializer _uiObjectGetter;
        private ScoreCountView _scoreCountView;
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
            _scoreCountView = _uiObjectGetter.ScoreCount;
            _scoreDisplay = _scoreCountView.GetComponent<TextMeshProUGUI>();
        }

        public void Execute(float deltaTime)
        {
            DisplayScores();
        }

        public void AddScore(SpaceObject so)
        {
            _score += so.Properties.scoresForDestruction;
        }

        private void DisplayScores()
        {
            _scoreDisplay.text = $"{_message} {_score}";
        }
    }
}