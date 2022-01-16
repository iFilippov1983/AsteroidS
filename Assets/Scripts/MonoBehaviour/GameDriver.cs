using System;
using UnityEngine;

namespace AsteroidS
{
    public class GameDriver : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        private ControllersProxy _controllers;
        private GameInitializer _gameInitializer;
        private void Awake()
        {
            _controllers = new ControllersProxy();
            _gameInitializer = new GameInitializer(_controllers, _gameData);
            _gameInitializer.LateInit();
            _controllers.Configure();

            //temp
            //DateTime dt = DateTimeCatcher.GetNetworkTime();
            //TimeSpan ts = dt.TimeOfDay;
            //Debug.Log(ts);
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
        }
    }
}


