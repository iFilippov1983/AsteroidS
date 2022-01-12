using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AsteroidS
{
    public sealed class SpaceObjectsSpawner
    {
        private GameProgressData _gameProgressData;
        private SpaceObjectBuilder _builder;
        private Dictionary<SpaceObjectType, SpaceObject> _spaceObjects;
        private float _spawnDistanceMultiplier;
        private float _trajectoryVariance;
        private SpaceObject[] _childsPrefabs;

        public SpaceObjectsSpawner(GameData gameData)
        {
            _builder = new SpaceObjectBuilder();

            _gameProgressData = gameData.GameProgressData;
            _spawnDistanceMultiplier = gameData.GameProgressData.CurrentLevelProperties.DistanceMultiplier;
            _trajectoryVariance = gameData.GameProgressData.CurrentLevelProperties.TrajectoryVariance;
        }

        public Stack<SpaceObject> CreateUnactiveSpaceObjectsStack()
        {
            _spaceObjects = _gameProgressData.CurrentLevelProperties.SpaceObjectsPrefabsDictionary;
            _childsPrefabs = _gameProgressData.CurrentLevelProperties.ChildsPrefabs;

            var stack = new Stack<SpaceObject>();

            foreach(SpaceObjectType t in _spaceObjects.Keys)
            {
                var spaceObjectType = t;
                var prefab = _spaceObjects[spaceObjectType];
                var amount = prefab.Properties.amountOnScene;

                for (int index = 0; index < amount ; index++)
                {
                    var obj = SpawnUnactive(spaceObjectType);
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

        public SpaceObject[] SpawnChilds(int amount, Transform transform)
        {
            var childs = new SpaceObject[amount];
            var prefab = _childsPrefabs[Random.Range(0, _childsPrefabs.Length)];

            for (int index = 0; index < amount; index++)
            {
                var soChild = _builder
                    .MakeInstance(prefab)
                    .SetPosition(transform.position)
                    .SetRotation(CalculetaRandomRotation())
                    .SetRandomObjectView(prefab.GetSprites)
                    .SetActivityState(false)
                    .Build();

                soChild.Properties.isChild = true;

                childs[index] = soChild;
            }

            return childs;
        }

        private SpaceObject SpawnUnactive(SpaceObjectType type)
        {
            var prefab = _spaceObjects[type];

            var spaceObject = _builder
                                .MakeInstance(prefab)
                                .SetPosition(CalculateRandomPosition())
                                .SetRotation(CalculetaRandomRotation())
                                .SetRandomObjectView(prefab.GetSprites)
                                .SetActivityState(false)
                                .Build();

            return spaceObject;
        }

        private Vector3 CalculateRandomPosition()
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * _spawnDistanceMultiplier;
            Vector3 spawnPoint = Vector3.zero + spawnDirection;

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
