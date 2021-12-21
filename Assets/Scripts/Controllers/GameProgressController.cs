using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AsteroidS
{
    class GameProgressController : IInitialization, IExecute, IFixedExecute, ILateExecute, ICleanup
    {
        private GameData _gameData;
        private SpaceObjectsController _spaceObjectsController;
        private ScoreCountController _scoreCountController;

        private const int _startLevel = 1;
        private int _currentLevel;
        private TimeSpan _levelDuration;
        private float _levelDurationTimer;


        public GameProgressController(
            GameData gameData, 
            SpaceObjectsController spaceObjectsController,
            ScoreCountController scoreCountController)
        {
            _gameData = gameData;
            _spaceObjectsController = spaceObjectsController;
            _scoreCountController = scoreCountController;
        }
        
        public void Initialize()
        {
            _levelDuration = _gameData.GameProgressData.LevelDuration;
            _currentLevel = _gameData.GameProgressData.CurrentLevel;

            _spaceObjectsController.OnObjectDestroyEvent += _scoreCountController.AddScore;
            _spaceObjectsController.OnPlayerDestroyEvent += RestartScene;
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
            ChangeLevelIfTerminated();
        }

        public void Cleanup()
        {
            ResetProperties();

            _spaceObjectsController.OnObjectDestroyEvent -= _scoreCountController.AddScore;
            _spaceObjectsController.OnPlayerDestroyEvent -= RestartScene;
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(_gameData.SceneData.SceneName);
        }

        private void ResetProperties()
        {
            _gameData.GameProgressData.CurrentLevel = _startLevel;
            _spaceObjectsController.LevelTransition = false;
        }

        private void ChangeLevelIfTerminated()
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
