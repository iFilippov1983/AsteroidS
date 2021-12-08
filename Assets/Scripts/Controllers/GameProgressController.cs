using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AsteroidS
{
    class GameProgressController : IInitialization, IExecute, ICleanup
    {
        private GameData _gameData;
        private SpaceObjectsController _spaceObjectsController;
        
        public GameProgressController(
            GameData gameData, 
            SpaceObjectsController spaceObjectsController,
            ScoreCountController scoreCountController,
            TimerController timerController)
        {
            _gameData = gameData;
            _spaceObjectsController = spaceObjectsController;
        }
        
        public void Initialize()
        {
            _spaceObjectsController.OnPlayerDestroyEvent += RestartScene;
        }

        public void Execute(float deltaTime)
        {
            
        }

        public void Cleanup()
        {
            _spaceObjectsController.OnPlayerDestroyEvent += RestartScene;
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(_gameData.SceneData.SceneName);
        }
    }
}
