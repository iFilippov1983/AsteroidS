using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AsteroidS
{
    public class SpaceObjectsSpawner
    {
        private Dictionary<SpaceObjectType, SpaceObject> _spaceObjects;
        private List<SpaceObject> _childsPrefabs;
        private SpaceObjectBuilder _builder;
        private float _spawnDistanceMultiplier;
        private float _trajectoryVariance;

        public SpaceObjectsSpawner(GameData gameData)
        {
            _spaceObjects = gameData.SpaceObjectsData.SpaceObjectsPrefabsDictionary;
            _childsPrefabs = GetChilds(_spaceObjects);
            _builder = new SpaceObjectBuilder();
            _spawnDistanceMultiplier = gameData.SpaceObjectsData.DistanceMultiplier;
            _trajectoryVariance = gameData.SpaceObjectsData.TrajectoryVariance;
        }

        public Stack<SpaceObject> CreateUnactiveSpaceObjectsStack()
        {
            var stack = new Stack<SpaceObject>();

            for (int typeIndex = 1; typeIndex <= _spaceObjects.Count; typeIndex++)
            {
                var spaceObjectType = (SpaceObjectType)typeIndex;
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

        private List<SpaceObject> GetChilds(Dictionary<SpaceObjectType, SpaceObject> dictionary)
        {
            var list = new List<SpaceObject>();
            foreach (SpaceObject so in dictionary.Values)
            {
                if (so.Properties.isChild) list.Add(so);
            }

            return list;
        }

        //public SpaceObject[] SpawnChilds(int amount, Transform position)
        //{
        //    var childs = new SpaceObject[amount];
        //    for(int index = 0; index < amount; index++)
        //    {
        //        Respawn(childs[index]);
        //    }

        //    return childs;
        //}
    }
}
