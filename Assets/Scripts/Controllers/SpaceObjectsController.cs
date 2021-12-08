using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace AsteroidS
{
    public class SpaceObjectsController : IInitialization, IExecute, IFixedExecute, ILateExecute, ICleanup
    {
        private SpaceObjectsData _spaceObjectsData;
        private SpaceObjectsSpawner _spawner;
        private SpaceObjectDriver _objectDriver;
        private Stack<SpaceObject> _soStack;
        private float _spawnRate;
        private float _timeCounter;
        private int _maxChildsAmount;

        public SpaceObjectsController(GameData gameData)
        {
            _spaceObjectsData = gameData.SpaceObjectsData;
            _spawner = new SpaceObjectsSpawner(gameData);
            _objectDriver = new SpaceObjectDriver();
            _spawnRate = _spaceObjectsData.SpawnRate;
            _maxChildsAmount = _spaceObjectsData.MaxChildsAmount;
        }

        public Action OnObjectDestroyEvent;
        public Action OnPlayerDestroyEvent;

        public void Initialize()
        {
            _soStack = _spawner.CreateUnactiveSpaceObjectsStack();
            foreach (SpaceObject so in _soStack)
            {
                so.SpaceObjectHit += OnHit;
                so.LifeTimeTermination += OnLifeTermination;
                so.PlayerHit += OnPlayerDestroy;
            }
        }

        public void Execute(float deltaTime)
        {
           
        }

        public void FixedExecute()
        {
            _timeCounter += Time.deltaTime;
            if (_timeCounter >= _spawnRate && _soStack.Count != 0)
            {
                _timeCounter = 0;

                var spaceObject = _soStack.Pop();
                _spawner.Respawn(spaceObject);
                _objectDriver.Drive(spaceObject);
            }
        }

        public void LateExecute()
        {
            
        }

        public void Cleanup()
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
        }

        private void OnHit(SpaceObject spaceObject)
        {
            var hp = spaceObject.Properties.hitPoints;
            if (hp <= 0) DesactivateSO(spaceObject);
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

        private void DesactivateSO(SpaceObject spaceObject)
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
    }
}
