using UnityEngine;

namespace AsteroidS
{
    public sealed class SceneController : IInitialization, IExecute, IFixedExecute, ILateExecute
    {
        private SceneData _sceneData;
        private BackgroundInitializer _backgroundInitializer;
        private CameraFollowController _cameraFollowController;
        private ParallaxBackgroundController _parallaxController;
        private Transform _transformToFollow;

        private float _zoom;
        private float _cameraSizeDefault;
        private float _cameraSizeMin;
        private float _cameraSizeMax;

        public SceneController(GameData gameData, Transform transformToFollow)
        {
            _sceneData = gameData.SceneData;
            _transformToFollow = transformToFollow;
            _backgroundInitializer = new BackgroundInitializer(gameData);
            _cameraFollowController = new CameraFollowController();
        }

        public void Initialize()
        {
            _backgroundInitializer.Initialize();
            _cameraSizeDefault = Camera.main.orthographicSize;
            _zoom = _cameraSizeDefault;
            _cameraSizeMin = _sceneData.CameraMinSize;
            _cameraSizeMax = _sceneData.CameraMaxSize;

            _cameraFollowController.Setup(() => _transformToFollow.position, () => _zoom, Camera.main);
            _parallaxController = new ParallaxBackgroundController(
                _backgroundInitializer.ParallaxBackground, _sceneData.ParallaxEffectMultiplier);
            _parallaxController.Initialize();
        }

        //temp
        public void Execute(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.KeypadMinus)) ZoomOut(1f);
            if (Input.GetKeyDown(KeyCode.KeypadPlus)) ZoomIn(1f);
        }
        //

        public void FixedExecute()
        {
            _cameraFollowController.FixedExecute();
        }

        public void LateExecute()
        {
            _parallaxController.LateExecute();
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
