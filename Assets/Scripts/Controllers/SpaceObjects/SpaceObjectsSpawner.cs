using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AsteroidS
{
    public sealed class SpaceObjectsSpawner
    {
        private GameProgressData _gameProgressData;
        private SpaceObjectBuilder _builder;
        private Dictionary<SpaceObjectName, SpaceObject> _spaceObjects;
        private float _spawnDistanceMultiplier;
        private float _trajectoryVariance;
        private float _splitSpawnOffset;

        public SpaceObjectsSpawner(GameData gameData)
        {
            _builder = new SpaceObjectBuilder();

            _gameProgressData = gameData.GameProgressData;
            _spawnDistanceMultiplier = _gameProgressData.CurrentLevelProperties.DistanceMultiplier;
            _trajectoryVariance = _gameProgressData.CurrentLevelProperties.TrajectoryVariance;
            _splitSpawnOffset = _gameProgressData.CurrentLevelProperties.SplitOffset;
        }

        public Stack<SpaceObject> CreateUnactiveSpaceObjectsStack()
        {
            _spaceObjects = _gameProgressData.CurrentLevelProperties.SpaceObjectsPrefabsDictionary;

            var stack = new Stack<SpaceObject>();

            foreach(SpaceObjectName t in _spaceObjects.Keys)
            {
                var prefab = _spaceObjects[t];
                var amount = prefab.Properties.amountOnScene;

                for (int index = 0; index < amount ; index++)
                {
                    var obj = SpawnUnactive(t);
                    stack.Push(obj);
                }
            }
            
            return stack;
        }

        public SpaceObject Respawn(SpaceObject spaceObject)
        {
            spaceObject.transform.position = CalculateRandomPosition();
            spaceObject.transform.rotation = CalculetaRandomRotation();
            spaceObject.gameObject.SetActive(true);

            return spaceObject;
        }

        public SpaceObject[] SpawnSplit(SpaceObject spaceObject)
        {
            int amount = 2;
            var childs = new SpaceObject[amount];
            float mass = spaceObject.gameObject.GetComponent<Rigidbody2D>().mass;

            for (int index = 0; index < amount; index++)
            {
                Vector2 position = spaceObject.transform.position;
                position += Random.insideUnitCircle * _splitSpawnOffset;

                var soChild = _builder
                    .MakeInstance(spaceObject, mass / amount)
                    .SetPosition(position)
                    .SetRotation(CalculetaRandomRotation())
                    .Build();

                soChild.gameObject.SetActive(true);
                childs[index] = soChild;
            }

            return childs;
        }

        private SpaceObject SpawnUnactive(SpaceObjectName name)
        {
            var prefab = _spaceObjects[name];

            var spaceObject = _builder
                                .MakeInstance(prefab)
                                .SetPosition(CalculateRandomPosition())
                                .SetRotation(CalculetaRandomRotation())
                                .SetRandomObjectView(prefab.GetSprites)
                                .Build();

            spaceObject.gameObject.SetActive(false);

            return spaceObject;
        }

        private Vector3 CalculateRandomPosition()
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * _spawnDistanceMultiplier;
            Vector3 spawnPoint = Camera.main.transform.position + spawnDirection;
            spawnPoint.z = 0f;

            return spawnPoint;
        }

        private Quaternion CalculetaRandomRotation()
        {
            float variance = Random.Range(-_trajectoryVariance, _trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            return rotation;
        }
    }
}
