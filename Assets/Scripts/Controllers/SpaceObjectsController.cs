using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AsteroidS
{
    public class SpaceObjectsController : IInitialization, IExecute, ICleanup
    {
        private SpaceObjectsData _spaceObjectsData;
        private SpaceObjectsSpawner _spawner;
        private SpaceObjectDriver _objectDriver;
        private Stack<SpaceObject> _soStack;
        private float _spawnRate;
        private float _timeCounter;

        public SpaceObjectsController(GameData gameData)
        {
            _spaceObjectsData = gameData.SpaceObjectsData;
            _spawner = new SpaceObjectsSpawner(gameData);
            _objectDriver = new SpaceObjectDriver();
            _spawnRate = _spaceObjectsData.SpawnRate;
        }

        public Action OnObjectHit;

        public void Initialize()
        {
            _soStack = _spawner.CreateStackOfUnactiveSpaceObjects();
            foreach (SpaceObject so in _soStack)
            {
                so.OnObjectHit += OnHit;
                so.OnLifeTimeIsOver += OnLifeTermination;
            }
        }

        public void Execute(float deltaTime)
        {
            _timeCounter += deltaTime;
            if (_timeCounter >= _spawnRate && _soStack.Count !=0)
            {
                _timeCounter = 0;

                var spaceObject = _soStack.Pop();
                _spawner.Respawn(spaceObject);
                _objectDriver.Drive(spaceObject);
            }
        }

        public void Cleanup()
        {
            var liveObjects = Object.FindObjectsOfType(typeof(SpaceObject));
            foreach (SpaceObject so in liveObjects)
            {
                so.OnObjectHit -= OnHit;
                so.OnLifeTimeIsOver -= OnLifeTermination;
            }

            foreach (SpaceObject so in _soStack)
            {
                so.OnObjectHit -= OnHit;
                so.OnLifeTimeIsOver -= OnLifeTermination;
            }
        }

        private void OnHit(SpaceObject spaceObject)
        {
            _objectDriver.Stop(spaceObject);
            _soStack.Push(spaceObject);
            OnObjectHit?.Invoke();
        }

        private void OnLifeTermination(SpaceObject spaceObject)
        {
            _objectDriver.Stop(spaceObject);
            _soStack.Push(spaceObject);
        }
    }
}
