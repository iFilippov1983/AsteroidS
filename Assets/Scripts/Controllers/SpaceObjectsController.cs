using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace AsteroidS
{
    public class SpaceObjectsController : IInitialization, IExecute, IFixedExecute, ICleanup
    {
        private GameProgressData _gameProgressData;
        private SpaceObjectsSpawner _spawner;
        private SpaceObjectDriver _objectDriver;
        private Stack<SpaceObject> _soStack;
        private GameLevelProperties _currentLevelProperties;
        private int _levelSpaceObjectsAmount;
        private float _spawnRate;
        private float _timeCounter;
        private bool _levelTransition = false;
        private int _maxChildsAmount;

        public bool LevelTransition { get => _levelTransition; set => _levelTransition = value; }

        public SpaceObjectsController(GameData gameData)
        {
            _spawner = new SpaceObjectsSpawner(gameData);
            _objectDriver = new SpaceObjectDriver();
            _gameProgressData = gameData.GameProgressData;
        }

        public Action<int> OnObjectDestroyEvent;
        public Action OnPlayerDestroyEvent;

        public void Initialize()
        {
            _currentLevelProperties = _gameProgressData.CurrentLevelProperties;
            _spawnRate = _currentLevelProperties.SpawnRate;
            _maxChildsAmount = _currentLevelProperties.MaxChildsAmount;

            _soStack = _spawner.CreateUnactiveSpaceObjectsStack();
            _levelSpaceObjectsAmount = _soStack.Count;

            SubscribeOnSOEvents();
        }

        public void Execute(float deltaTime)
        {
            _timeCounter += deltaTime;
        }

        public void FixedExecute()
        {
            SpawnObjects();
            RefillStackIfTransition();
        }

        public void Cleanup()
        {
            UnsubscribeFromSOEvents();
        }

        private void SpawnObjects()
        {
            if (_timeCounter >= _spawnRate && _soStack.Count != 0 && !_levelTransition)
            {
                _timeCounter = 0;

                var spaceObject = _soStack.Pop();
                _spawner.Respawn(spaceObject);
                _objectDriver.Drive(spaceObject);
            }
        }

        private void RefillStackIfTransition()
        {
            if (_levelTransition)
            {
                bool stackIsFull = (_soStack.Count == _levelSpaceObjectsAmount);

                if (stackIsFull)
                {
                    UnsubscribeFromSOEvents();

                    _soStack = _spawner.CreateUnactiveSpaceObjectsStack();
                    _levelSpaceObjectsAmount = _soStack.Count;
                    SubscribeOnSOEvents();
                    _levelTransition = false;
                }

            }
        }

        private void Hit(SpaceObject spaceObject)
        {
            if (spaceObject.HitPoints <= 0)
            {
                var scores = spaceObject.Properties.scoresForDestruction;

                if (spaceObject.Properties.isBreakable) SpawnChildAsteroids(spaceObject.transform);

                DestructSO(spaceObject);

                OnObjectDestroyEvent?.Invoke(scores);
            } 
        }

        private void LifeTermination(SpaceObject spaceObject)
        {
            _objectDriver.Stop(spaceObject);
            _soStack.Push(spaceObject);
        }

        private void PlayerDestroy()
        {
            OnPlayerDestroyEvent?.Invoke();
        }

        private void SubscribeOnSOEvents()
        {
            foreach (SpaceObject so in _soStack)
            {
                so.OnSpaceObjectHit += Hit;
                so.OnLifeTimeTermination += LifeTermination;
                so.OnPlayerHit += PlayerDestroy;
            }
        }

        private void UnsubscribeFromSOEvents()
        {
            var liveObjects = Object.FindObjectsOfType(typeof(SpaceObject));
            foreach (SpaceObject so in liveObjects)
            {
                so.OnSpaceObjectHit -= Hit;
                so.OnLifeTimeTermination -= LifeTermination;
                so.OnPlayerHit -= PlayerDestroy;
            }

            foreach (SpaceObject so in _soStack)
            {
                so.OnSpaceObjectHit -= Hit;
                so.OnLifeTimeTermination -= LifeTermination;
                so.OnPlayerHit -= PlayerDestroy;
            }
        }

        private void DestructSO(SpaceObject spaceObject)
        {
            

            _objectDriver.Stop(spaceObject);
            _soStack.Push(spaceObject);
        }

        private void SpawnChildAsteroids(Transform transform)
        {
            var childsAmount = Random.Range(1, _maxChildsAmount + 1);
            var childs = _spawner.SpawnChilds(childsAmount, transform);

            foreach (SpaceObject so in childs)
            {
                so.OnSpaceObjectHit += Hit;
                so.OnLifeTimeTermination += LifeTermination;
                so.OnPlayerHit += PlayerDestroy;

                _objectDriver.Drive(so);
            }
        }
    }
}
