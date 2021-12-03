using TMPro;

namespace AsteroidS
{
    public class ScoreCountController:IInitialization, IExecute, ICleanup
    {
        private const string _message = "Score:";
        private readonly ScoreCountView _scoreCountView;
        private TextMeshProUGUI _scoreDisplay;
        private int _score;
       

        public ScoreCountController(ScoreCountView scoreCountView)
        {
            _scoreCountView = scoreCountView;
            _scoreDisplay = _scoreCountView.GetComponent<TextMeshProUGUI>();
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