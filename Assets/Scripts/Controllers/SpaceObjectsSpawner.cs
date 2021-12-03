using System.Collections.Generic;
using AsteroidS;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class SpaceObjectsSpawner
    {
        private Dictionary<SpaceObjectType, SpaceObject> _spaceObjects;
        private SpaceObjectBuilder _builder;
        private float _spawnDistanceMultiplier;
        private float _trajectoryVariance;

        public SpaceObjectsSpawner(GameData gameData)
        {
            _spaceObjects = gameData.SpaceObjectsData.SpaceObjectsPrefabsDictionary;
            _builder = new SpaceObjectBuilder();
            _spawnDistanceMultiplier = gameData.SpaceObjectsData.DistanceMultiplier;
            _trajectoryVariance = gameData.SpaceObjectsData.TrajectoryVariance;
        }

        public Stack<SpaceObject> CreateStackOfUnactiveSpaceObjects()
        {
            var stack = new Stack<SpaceObject>();

            for (int typeIndex = 1; typeIndex <= _spaceObjects.Count; typeIndex++)
            {
                var spaceObjectType = (SpaceObjectType)typeIndex;
                var prefab = _spaceObjects[spaceObjectType];
                var amount = prefab.GetSpaceObjectProperties.amountOnScene;

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

        private SpaceObject SpawnUnactive(SpaceObjectType type)
        {
            var prefab = _spaceObjects[type];

            var spaceObject = _builder
                                .MakeInstance(prefab)
                                .SetPosition(CalculateRandomPosition())
                                .SetRotation(CalculetaRandomRotation())
                                .SetObjectView(prefab.GetSprites)
                                .SetActivityState(false)
                                .Get();

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
