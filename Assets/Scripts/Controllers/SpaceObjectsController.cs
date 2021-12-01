using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AsteroidS
{
    public class SpaceObjectsController : IInitialization, IExecute
    {
        private SpaceObjectsData _spaceObjectsData;
        private SpaceObjectsSpawner _spawner;
        private float _spawnRate;
        private float _timeCounter;

        public SpaceObjectsController(GameData gameData)
        {
            _spaceObjectsData = gameData.SpaceObjectsData;
            _spawner = new SpaceObjectsSpawner(gameData);
            _spawnRate = _spaceObjectsData.SpawnRate;
        }

        public void Initialize()
        {

        }

        public void Execute(float deltaTime)
        {

        }

        
    }
}
