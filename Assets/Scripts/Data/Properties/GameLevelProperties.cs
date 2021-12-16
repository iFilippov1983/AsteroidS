using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/LevelPropeties", fileName = "Level_number_Properties")]
    public class GameLevelProperties : ScriptableObject
    {
        [SerializeField] private SpaceObject[] _spaceObjectsPrefabs;
        [Range(0, 1000)]
        [SerializeField] private float _levelDuration = 30f;
        [SerializeField] private float _spawnRate = 2.0f;
        [SerializeField] private float _spawnDistanceMultiplier = 15.0f;
        [SerializeField] private float _trajectoryVariance = 15.0f;
        [SerializeField] private SpaceObject[] _chidlsPrefabs;
        [SerializeField] private int _maxChildsAmount = 3;

        public Dictionary<SpaceObjectType, SpaceObject> SpaceObjectsPrefabsDictionary => MakePrefabsDictionary();
        public float LevelDuration => _levelDuration;
        public float SpawnRate => _spawnRate;
        public float DistanceMultiplier => _spawnDistanceMultiplier;
        public float TrajectoryVariance => _trajectoryVariance;
        public SpaceObject[] ChildsPrefabs => _chidlsPrefabs;
        public int MaxChildsAmount => _maxChildsAmount;

        private Dictionary<SpaceObjectType, SpaceObject> MakePrefabsDictionary()
        {
            var dictionary = new Dictionary<SpaceObjectType, SpaceObject>();

            for (int prefabIndex = 0; prefabIndex < _spaceObjectsPrefabs.Length; prefabIndex++)
            {
                var type = _spaceObjectsPrefabs[prefabIndex].Properties.type;
                dictionary[type] = _spaceObjectsPrefabs[prefabIndex];
            }

            return dictionary;
        }
    }
}

