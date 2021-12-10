using System;
using System.Collections;
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
        private bool _subscribed = false;
        //private int _maxChildsAmount;

        public bool LevelTransition { get => _levelTransition; set => _levelTransition = value; }

        public SpaceObjectsController(GameData gameData)
        {
            _spawner = new SpaceObjectsSpawner(gameData);
            _objectDriver = new SpaceObjectDriver();

            _gameProgressData = gameData.GameProgressData;
            _currentLevelProperties = _gameProgressData.CurrentLevelProperties;
            _spawnRate = _currentLevelProperties.SpawnRate;
            //_maxChildsAmount = _spaceObjectsData.MaxChildsAmount;
        }

        public Action OnObjectDestroyEvent;
        public Action OnPlayerDestroyEvent;

        public void Initialize()
        {
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
        }

        public void Cleanup()
        {
            UnsubscribeFromSOEvents();
        }

        private void SpawnObjects()
        {
            if (_levelTransition)
            {
                //temp
                Debug.Log("Level transition");

                //if (_subscribed) UnsubscribeFromSOEvents();

                bool stackIsFull = _soStack.Count == _levelSpaceObjectsAmount;

                if (stackIsFull)
                {
                    UnsubscribeFromSOEvents();

                    //temp
                    Debug.Log("Refilling stack");

                    _soStack = _spawner.CreateUnactiveSpaceObjectsStack();
                    _levelSpaceObjectsAmount = _soStack.Count;
                    SubscribeOnSOEvents();
                    _levelTransition = false;
                }
                
            } 
            else if (_timeCounter >= _spawnRate && _soStack.Count != 0)
            {
                _timeCounter = 0;

                var spaceObject = _soStack.Pop();
                _spawner.Respawn(spaceObject);
                _objectDriver.Drive(spaceObject);
            }
        }

        private void DestructSO(SpaceObject spaceObject)
        {
            _objectDriver.Stop(spaceObject);
            _soStack.Push(spaceObject);

            //if (spaceObject.Properties.isBreakable) SpawnChildAsteroids(spaceObject.transform);

            OnObjectDestroyEvent?.Invoke();
        }

        //private void SpawnChildAsteroids(Transform position)
        //{
        //    var childsAmount = Random.Range(1, _maxChildsAmount + 1);
        //    var childs = _spawner.SpawnChilds(childsAmount, position);

        //    foreach (SpaceObject so in childs)
        //    {
        //        _objectDriver.Drive(so);
        //    }
        //}

        private bool CheckScene()
        {
            if (_soStack.Count == _levelSpaceObjectsAmount) return true;
            else return false;
        }

        private void OnHit(SpaceObject spaceObject)
        {
            if (spaceObject.HitPoints <= 0) DestructSO(spaceObject);
        }

        private void OnLifeTermination(SpaceObject spaceObject)
        {
            _objectDriver.Stop(spaceObject);
            _soStack.Push(spaceObject);
        }

        private void OnPlayerDestroy()
        {
            OnPlayerDestroyEvent?.Invoke();
        }

        private void SubscribeOnSOEvents()
        {
            foreach (SpaceObject so in _soStack)
            {
                so.SpaceObjectHit += OnHit;
                so.LifeTimeTermination += OnLifeTermination;
                so.PlayerHit += OnPlayerDestroy;
            }

            _subscribed = true;
        }

        private void UnsubscribeFromSOEvents()
        {
            var liveObjects = Object.FindObjectsOfType(typeof(SpaceObject));
            foreach (SpaceObject so in liveObjects)
            {
                so.SpaceObjectHit -= OnHit;
                so.LifeTimeTermination -= OnLifeTermination;
                so.PlayerHit -= OnPlayerDestroy;
            }

            foreach (SpaceObject so in _soStack)
            {
                so.SpaceObjectHit -= OnHit;
                so.LifeTimeTermination -= OnLifeTermination;
                so.PlayerHit -= OnPlayerDestroy;
            }

            _subscribed = false;
        }
    }
}
