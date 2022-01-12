using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace AsteroidS
{
    public sealed class SpaceObjectsController : IInitialization, IExecute, IFixedExecute, ICleanup
    {
        private GameProgressData _gameProgressData;
        private SpaceObjectsSpawner _spawner;
        private SpaceObjectDriver _objectDriver;
        private Stack<SpaceObject> _soStack;
        private Stack<SpaceObject> _childsStack;
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
        public Action<string> OnObjectDestroySound;

        public void Initialize()
        {
            _levelTransition = false;
            _currentLevelProperties = _gameProgressData.CurrentLevelProperties;
            _spawnRate = _currentLevelProperties.SpawnRate;
            _maxChildsAmount = _currentLevelProperties.MaxChildsAmount;

            _soStack = _spawner.CreateUnactiveSpaceObjectsStack();
            _levelSpaceObjectsAmount = _soStack.Count;

            _childsStack = new Stack<SpaceObject>();

            SubscribeOnAllSOEvents(_soStack);
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
            UnsubscribeFromAllSOEvents(_soStack);
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
            if (_levelTransition)
            {
                bool stackIsFull = (_soStack.Count == _levelSpaceObjectsAmount);

                if (stackIsFull)
                {
                    _outdatedStack = _soStack;
                    _currentLevelProperties = _gameProgressData.CurrentLevelProperties;
                    _spawnRate = _currentLevelProperties.SpawnRate;
                    _maxChildsAmount = _currentLevelProperties.MaxChildsAmount;

                    _soStack = _spawner.CreateUnactiveSpaceObjectsStack();
                    _levelSpaceObjectsAmount = _soStack.Count;

                    SubscribeOnAllSOEvents(_soStack);

                    UnsubscribeFromAllSOEvents(_outdatedStack);
                    DestroyStack(_outdatedStack);

                    if (_childsStack != null)
                    {
                        UnsubscribeFromAllSOEvents(_childsStack);
                        DestroyStack(_childsStack);
                    }

                    _levelTransition = false;
                }
            }
        }

        private void Hit(SpaceObject spaceObject)
        {
            if (spaceObject.HitPoints <= 0)
            {
                if (spaceObject.Properties.IsBreakable) SpawnChildAsteroids(spaceObject.transform);

                LifeTermination(spaceObject);

                OnObjectDestroyEvent?.Invoke(spaceObject);
                OnObjectDestroySound?.Invoke(spaceObject.tag);
            }
            else
            {
                OnObjectHitEvent?.Invoke(spaceObject.tag);
            }
        }

        private void LifeTermination(SpaceObject spaceObject)
        {
            if (spaceObject.Properties.isChild)
            {
                UnsubscribeFromSOEnents(spaceObject);
                Object.Destroy(spaceObject);
            }
            else
            {
                _objectDriver.Stop(spaceObject);
                _soStack.Push(spaceObject);
            }
            
        }

        private void PlayerDestroy()
        {
            OnPlayerDestroyEvent?.Invoke();
        }

        private void SubscribeOnAllSOEvents(IEnumerable<SpaceObject> spaceObjects)
        {
            foreach (SpaceObject so in spaceObjects)
            {
                SubscribeOnSOEvents(so);
            }
        }

        private void UnsubscribeFromAllSOEvents(IEnumerable<SpaceObject> spaceObjects)
        {
            //var liveObjects = Object.FindObjectsOfType(typeof(SpaceObject));

            //foreach (SpaceObject so in liveObjects)
            //{
            //    UnsubscribeFromSOEnents(so);

            //    Object.Destroy(so);
            //}

            foreach (SpaceObject so in spaceObjects)
            {
                UnsubscribeFromSOEnents(so);
            }
        }

        private void SpawnChildAsteroids(Transform transform)
        {
            var childsAmount = Random.Range(1, _maxChildsAmount + 1);
            var childs = _spawner.SpawnChilds(childsAmount, transform);

            foreach (SpaceObject so in childs)
            {
                SubscribeOnSOEvents(so);
                _objectDriver.Drive(so);
                _childsStack.Push(so);
            }

        }

        private void SubscribeOnSOEvents(SpaceObject spaceObject)
        {
            spaceObject.OnSpaceObjectHit += Hit;
            spaceObject.OnLifeTimeTermination += LifeTermination;
            spaceObject.OnPlayerHit += PlayerDestroy;
        }

        private void UnsubscribeFromSOEnents(SpaceObject spaceObject)
        {
            spaceObject.OnSpaceObjectHit -= Hit;
            spaceObject.OnLifeTimeTermination -= LifeTermination;
            spaceObject.OnPlayerHit -= PlayerDestroy;
        }

        private void DestroyStack(IEnumerable<SpaceObject> spaceObjects)
        {
            foreach (SpaceObject so in spaceObjects)
            {
                if(so) Object.Destroy(so.gameObject);
            }

            spaceObjects = null;
        }
    }
}
