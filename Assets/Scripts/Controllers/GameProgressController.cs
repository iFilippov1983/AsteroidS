using System;

namespace AsteroidS
{
    public sealed class GameProgressController : IInitialization, IExecute, IFixedExecute, ILateExecute, ICleanup
    {
        private readonly GameData _gameData;
        private readonly SpaceObjectsController _spaceObjectsController;
        private readonly ScoreCountController _scoreCountController;
        private readonly GameStateController _gameStateController;

        private const int StartLevel = 1;
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
            _gameData.GameProgressData.CurrentLevel = StartLevel;
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
