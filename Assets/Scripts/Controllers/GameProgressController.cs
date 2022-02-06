using System;

namespace AsteroidS
{
    class GameProgressController : IInitialization, IExecute, IFixedExecute, ILateExecute, ICleanup
    {
        private GameData _gameData;
        private SpaceObjectsController _spaceObjectsController;
        private ScoreCountController _scoreCountController;
        private readonly GameStateController _gameStateController;

        private const int _startLevel = 1;
        private int _currentLevel;
        private TimeSpan _levelDuration;
        private float _levelDurationTimer = 0;


        public GameProgressController(
            GameData gameData, 
            SpaceObjectsController spaceObjectsController,
            ScoreCountController scoreCountController, GameStateController gameStateController)
        {
            _gameData = gameData;
            _spaceObjectsController = spaceObjectsController;
            _scoreCountController = scoreCountController;
            _gameStateController = gameStateController;
        }
        
        public void Initialize()
        {
            _levelDuration = _gameData.GameProgressData.LevelDuration;
            _currentLevel = _gameData.GameProgressData.CurrentLevel;

            _spaceObjectsController.OnObjectDestroyEvent += _scoreCountController.AddScore;
        }

        public void Execute(float deltaTime)
        {
            _levelDurationTimer += deltaTime;
        }

        public void FixedExecute()
        {
            
        }

        public void LateExecute()
        {
            SetTransitionIfLevelTimeTerminated();
        }

        public void Cleanup()
        {
            ResetProperties();

            _spaceObjectsController.OnObjectDestroyEvent -= _scoreCountController.AddScore;
        }

        private void ResetProperties()
        {
            _gameData.GameProgressData.CurrentLevel = _startLevel;
            _spaceObjectsController.LevelTransition = false;
        }

        private void SetTransitionIfLevelTimeTerminated()
        {
            if (TimeSpan.FromSeconds(_levelDurationTimer) > _levelDuration)
            {
                _currentLevel += 1;

                _gameData.GameProgressData.CurrentLevel = _currentLevel;
                _levelDuration = _gameData.GameProgressData.LevelDuration;
                _spaceObjectsController.LevelTransition = true;
                _levelDurationTimer = 0;
            }
        }
    }
}
