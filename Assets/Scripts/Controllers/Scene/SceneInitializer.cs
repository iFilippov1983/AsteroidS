using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    public sealed class SceneInitializer : IInitialization
    {
        private GameData _gameData;
        private Canvas _cameraBackgroundCanvas;
        private Transform _parallaxBackground;

        public SceneInitializer(GameData gameData)
        {
            _gameData = gameData;
        }

        public Transform ParallaxBackground => _parallaxBackground.transform;

        public void Initialize()
        {
            InitScene(_gameData);
        }

        private void InitScene(GameData gameData)
        {
            var sceneData = gameData.SceneData;
            Object.Instantiate(sceneData.Camera);
            _parallaxBackground = Object.Instantiate(sceneData.ParallaxBackground);
            _cameraBackgroundCanvas = Object.Instantiate(sceneData.CameraBackgroundCanvas);
            _cameraBackgroundCanvas.worldCamera = Camera.main;
            
        }
    }
}
