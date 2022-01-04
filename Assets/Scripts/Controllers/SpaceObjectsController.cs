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
        private Stack<SpaceObject> _outdatedStack;
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

        public Action<SpaceObject> OnObjectDestroyEvent;
        public Action OnPlayerDestroyEvent;
        public Action<string> OnObjectHitEvent;
        public Action<string> OnObjectDestroy;

        public void Initialize()
        {
            _levelTransition = false;
            _currentLevelProperties = _gameProgressData.CurrentLevelProperties;
            _spawnRate = _currentLevelProperties.SpawnRate;
            _maxChildsAmount = _currentLevelProperties.MaxChildsAmount;

            _soStack = _spawner.CreateUnactiveSpaceObjectsStack();
            _levelSpaceObjectsAmount = _soStack.Count;

            //temp
            Debug.Log("SO amount:" + _levelSpaceObjectsAmount);

            SubscribeOnSOEvents();
        }

        public void Execute(float deltaTime)
        {
            _timeCounter += deltaTime;
        }

        public void FixedExecute()
        {
            SpawnObjects();
            ReinitializeIfTransition();
        }

        public void Cleanup()
        {
            UnsubscribeFromSOEvents();
        }

        private void SpawnObjects()
        {
            if (_timeCounter >= _spawnRate && 
                _soStack.Count != 0 && 
                !_levelTransition)
            {
                _timeCounter = 0;

                var spaceObject = _soStack.Pop();
                _spawner.Respawn(spaceObject);
                _objectDriver.Drive(spaceObject);
            }
        }

        private void ReinitializeIfTransition()
        {
            //temp
            Debug.Log("transition:" + _levelTransition);

            if (_levelTransition)
            {
                bool stackIsFull = (_soStack.Count == _levelSpaceObjectsAmount);

                //temp
                Debug.Log("full:" + stackIsFull);

                if (stackIsFull)
                {
                    _outdatedStack = _soStack;
                    _currentLevelProperties = _gameProgressData.CurrentLevelProperties;
                    _spawnRate = _currentLevelProperties.SpawnRate;
                    _maxChildsAmount = _currentLevelProperties.MaxChildsAmount;

                    UnsubscribeFromSOEvents();

                    _soStack = _spawner.CreateUnactiveSpaceObjectsStack();
                    _levelSpaceObjectsAmount = _soStack.Count;

                    //temp
                    Debug.Log("SO amount:" + _levelSpaceObjectsAmount);

                    SubscribeOnSOEvents();

                    DestroyOutdatedStack();

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

                LifeTermination(spaceObject);

                OnObjectDestroyEvent?.Invoke(spaceObject);
                OnObjectDestroy?.Invoke(spaceObject.tag);
            }
            else
            {
                OnObjectHitEvent?.Invoke(spaceObject.tag);
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

                Object.Destroy(so);
            }

            foreach (SpaceObject so in _soStack)
            {
                so.OnSpaceObjectHit -= Hit;
                so.OnLifeTimeTermination -= LifeTermination;
                so.OnPlayerHit -= PlayerDestroy;
            }
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

        private void DestroyOutdatedStack()
        {
            foreach (SpaceObject so in _outdatedStack)
            {
                Object.Destroy(so.gameObject);
            }

            _outdatedStack.Clear();
        }
    }
}
