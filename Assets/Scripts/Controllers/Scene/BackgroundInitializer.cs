using UnityEngine;

namespace AsteroidS
{
    public sealed class BackgroundInitializer : IInitialization
    {
        private GameData _gameData;
        private Canvas _cameraBackgroundCanvas;
        private Transform _parallaxBackground;

        public BackgroundInitializer(GameData gameData)
        {
            _gameData = gameData;
            Object.Instantiate(gameData.SceneData.Camera);
        }

        public Transform ParallaxBackground => _parallaxBackground.transform;

        public void Initialize()
        {
            InitScene(_gameData);
        }

        private void InitScene(GameData gameData)
        {
            var sceneData = gameData.SceneData;
            _parallaxBackground = Object.Instantiate(sceneData.ParallaxBackground);
            _cameraBackgroundCanvas = Object.Instantiate(sceneData.CameraBackgroundCanvas);
            _cameraBackgroundCanvas.worldCamera = Camera.main;
        }
    }
}
