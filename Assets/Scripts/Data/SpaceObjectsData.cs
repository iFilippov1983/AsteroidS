using System.Collections.Generic;
using UnityEngine;


namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/SpaceObjectsData", fileName = "SpaceObjectsData")]
    public class SpaceObjectsData : ScriptableObject
    {
        [SerializeField] private SpaceObject[] _spaceObjectsPrefabs;
        [SerializeField] private float _spawnRate = 2.0f;
        [SerializeField] private float _spawnDistanceMultiplier = 15.0f;

        public Dictionary<SpaceObjectType, SpaceObject> SpaceObjectsPrefabsDictionary => PrefabsDictionary();
        public float SpawnRate => _spawnRate;
        public float DistanceMultiplier => _spawnDistanceMultiplier;

        private Dictionary<SpaceObjectType, SpaceObject> PrefabsDictionary()
        {
            var dictionary = new Dictionary<SpaceObjectType, SpaceObject>();

            for (int prefabIndex = 0; prefabIndex < _spaceObjectsPrefabs.Length; prefabIndex++)
            {
                var type = _spaceObjectsPrefabs[prefabIndex].GetSpaceObjectProperties.type;
                dictionary[type] = _spaceObjectsPrefabs[prefabIndex];
            }

            return dictionary;
        }
    }
}
