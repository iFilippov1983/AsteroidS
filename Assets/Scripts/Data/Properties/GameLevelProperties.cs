using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/LevelPropeties", fileName = "Level_number_Properties")]
    public class GameLevelProperties : ScriptableObject
    {
        private const string SpaceObjectsPrefabsFolderPath = "SpaceObjectsPrefabs/";

        [SerializeField] private string[] _spaceObjectsPrefabsPath;
        [Range(0, 1000)]
        [SerializeField] private float _levelDuration = 30f;
        [SerializeField] private float _spawnRate = 2.0f;
        [SerializeField] private int _spawnAmount = 1;
        [SerializeField] private float _spawnDistanceMultiplier = 15.0f;
        [SerializeField] private float _trajectoryVariance = 15.0f;
        [SerializeField] private float _splitSpawnOffset = 0.3f;
        //[SerializeField] private string[] _childsPrefabsPath;
        //[SerializeField] private int _maxChildsAmount = 3;
        private SpaceObject[] _spaceObjectsPrefabs = null;
        //private SpaceObject[] _chidlsPrefabs = null;

        public Dictionary<SpaceObjectName, SpaceObject> SpaceObjectsPrefabsDictionary => MakePrefabsDictionary();
        public float LevelDuration => _levelDuration;
        public float SpawnRate => _spawnRate;
        public int SpawnAmount => _spawnAmount;
        public float DistanceMultiplier => _spawnDistanceMultiplier;
        public float TrajectoryVariance => _trajectoryVariance;
        public float SplitOffset => _splitSpawnOffset;
        //public SpaceObject[] ChildsPrefabs => GetChildsPrefabs();
        //public int MaxChildsAmount => _maxChildsAmount;


        //private SpaceObject[] GetChildsPrefabs()
        //{
        //    if (_chidlsPrefabs == null || _chidlsPrefabs.Length == 0)
        //    {
        //        _chidlsPrefabs = new SpaceObject[_childsPrefabsPath.Length];

        //        for (int index = 0; index < _childsPrefabsPath.Length; index++)
        //        {
        //            _chidlsPrefabs[index] = Resources.Load<SpaceObject>(SpaceObjectsPrefabsFolderPath + _childsPrefabsPath[index]);
        //        }
        //    }

        //    return _chidlsPrefabs;
        //}

        private SpaceObject[] GetSpaceObjectsPrefabs()
        {
            if (_spaceObjectsPrefabs == null || _spaceObjectsPrefabs.Length == 0)
            {
                _spaceObjectsPrefabs = new SpaceObject[_spaceObjectsPrefabsPath.Length];

                for (int index = 0; index < _spaceObjectsPrefabsPath.Length; index++)
                {
                    _spaceObjectsPrefabs[index] = Resources.Load<SpaceObject>(SpaceObjectsPrefabsFolderPath + _spaceObjectsPrefabsPath[index]);
                }
            }

            return _spaceObjectsPrefabs;
        }

        private Dictionary<SpaceObjectName, SpaceObject> MakePrefabsDictionary()
        {
            var dictionary = new Dictionary<SpaceObjectName, SpaceObject>();
            var prefabsArray = GetSpaceObjectsPrefabs();

            for (int prefabIndex = 0; prefabIndex < prefabsArray.Length; prefabIndex++)
            {
                var name = prefabsArray[prefabIndex].Properties.Name;
                dictionary[name] = prefabsArray[prefabIndex];
            }

            return dictionary;
        }
    }
}

