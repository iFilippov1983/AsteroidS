using UnityEngine;

namespace AsteroidS
{
    class SceneController : IInitialization, IExecute
    {
        private SceneData _sceneData;
        private SceneInitializer _sceneInitializer;
        private CameraFollowController _cameraFollowController;
        private Transform _transformToFollow;

        private float _zoom;
        private float _cameraSizeDefault;
        private float _cameraSizeMin;
        private float _cameraSizeMax;

        public SceneController(GameData gameData, Transform transformToFollow)
        {
            _sceneData = gameData.SceneData;
            _transformToFollow = transformToFollow;
            _sceneInitializer = new SceneInitializer(gameData);
            _cameraFollowController = new CameraFollowController();
        }

        public void Initialize()
        {
            _sceneInitializer.Initialize();
            _cameraSizeDefault = Camera.main.orthographicSize;
            _zoom = _cameraSizeDefault;
            _cameraSizeMin = _sceneData.CameraMinSize;
            _cameraSizeMax = _sceneData.CameraMaxSize;

            _cameraFollowController.Setup(() => _transformToFollow.position, () => _zoom, Camera.main);
        }

        public void Execute(float deltaTime)
        {
            _cameraFollowController.Execute(deltaTime);

            if (Input.GetKeyDown(KeyCode.KeypadMinus)) ZoomIn(1f);
            if (Input.GetKeyDown(KeyCode.KeypadPlus)) ZoomOut(1f);
        }

        private void ZoomIn(float value)
        {
            _zoom -= value;
            if (_zoom < _cameraSizeMin) _zoom = _cameraSizeMin;
        }

        private void ZoomOut(float value)
        {
            _zoom += value;
            if (_zoom > _cameraSizeMax) _zoom = _cameraSizeMax;
        }
    }
}
