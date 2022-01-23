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

        private Stack<SpaceObject> _soPassive;
        private Stack<SpaceObject> _soOnScene;
        private GameLevelProperties _currentLevelProperties;
        private float _spawnRate;
        private int _spawnAmount;
        private float _timeCounter;
        private bool _levelTransition = false;

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
            _soOnScene = new Stack<SpaceObject>();
            InitLevel();
            foreach (SpaceObject s in _soPassive) _soOnScene.Push(s);
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
            UnsubscribeFromAllSOEvents(_soPassive);
        }

        private void InitLevel()
        {
            _levelTransition = false;
            _currentLevelProperties = _gameProgressData.CurrentLevelProperties;
            _spawnRate = _currentLevelProperties.SpawnRate;
            _spawnAmount = _currentLevelProperties.SpawnAmount;

            _soPassive = _spawner.CreateUnactiveSpaceObjectsStack();
            SubscribeOnAllSOEvents(_soPassive);
        }

        private void SpawnObjects()
        {
            if (_timeCounter >= _spawnRate && !_levelTransition)
            {
                _timeCounter = 0;

                for (int i = 0; i < _spawnAmount; i++)
                {
                    var spaceObject = _soPassive.Pop();
                    _spawner.Respawn(spaceObject);
                    _objectDriver.Drive(spaceObject);
                }
            }
        }

        private void ReinitializeIfTransition()
        {
            if (_levelTransition)
            {
                InitLevel();
                ResetSceneSoStack();
            }
        }

        private void ResetSceneSoStack()
        {
            foreach (SpaceObject so in _soOnScene)
            {
                if (so)
                {
                    so.lifeTimeCounter = float.MaxValue;
                    if (so.gameObject.GetComponent<Rigidbody2D>().velocity.Equals(Vector2.zero)) 
                        Object.Destroy(so.gameObject);
                }
            }
            foreach (SpaceObject s in _soPassive) _soOnScene.Push(s);
        }

        private void Hit(SpaceObject spaceObject)
        {
            if (spaceObject.HitPoints <= 0)
            {
                TerminateLifeOf(spaceObject);

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
            _objectDriver.Stop(spaceObject);
            _soPassive.Push(spaceObject);
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
            foreach (SpaceObject so in spaceObjects)
            {
                UnsubscribeFromSOEnents(so);
            }
        }

        private void TerminateLifeOf(SpaceObject spaceObject)
        {
            if (spaceObject.Properties.Type.Equals(SpaceObjectType.Asteroid))
            {
                SplitIfBig(spaceObject);
            }
            else LifeTermination(spaceObject);
        }

        private void SplitIfBig(SpaceObject spaceObject)
        {
            Rigidbody2D rb = spaceObject.gameObject.GetComponent<Rigidbody2D>();
            float mass = rb.mass;
            float minMass = spaceObject.Properties.MassMin;

            if ((mass * 0.5f) > minMass)
            {
                var childs = _spawner.SpawnSplit(spaceObject);
                foreach (SpaceObject c in childs)
                {
                    SubscribeOnSOEvents(c);
                    _soOnScene.Push(c);
                    _objectDriver.Redrive(c, rb.velocity);
                }

                LifeTermination(spaceObject);
            }
            else if (mass < minMass)
            {
                UnsubscribeFromSOEnents(spaceObject);
                Object.Destroy(spaceObject.gameObject);
                Debug.Log("Hit");
            }
            else LifeTermination(spaceObject);
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
        }
    }
}
