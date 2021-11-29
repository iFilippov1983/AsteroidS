using UnityEngine;

namespace AsteroidS
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        private ControllersProxy _controllers;

        private void Awake()
        {
            _controllers = new ControllersProxy();
            new GameInitializer(_controllers, _gameData);
        }

        void Start()
        {
            _controllers.Initialize();
        }

        void Update()
        {
            var deltaTime = Time.unscaledDeltaTime;
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
        }
    }
}


