using UnityEngine;

namespace AsteroidS
{
    public sealed class GameDriver : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        private ControllersProxy _controllers;
        private GameInitializer _gameInitializer;
        private void Awake()
        {
            _controllers = new ControllersProxy();
            _gameInitializer = new GameInitializer(_controllers, _gameData);
            _gameInitializer.Configure();
            _controllers.Configure();
        }

        void Start()
        {
            _controllers.Initialize();
        }

        void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute();
        }

        private void LateUpdate()
        {
            _controllers.LateExecute();
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
            _gameInitializer.Cleanup();
        }
    }
}


