using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/SceneData", fileName = "SceneData")]
    public class SceneData : ScriptableObject 
    {
        [Header("Assets to place on scene")]
        [SerializeField] private List<SpaceObject> _asteroidsPrefabs;
        [SerializeField] private GameObject[] _boundaries;
        [SerializeField] private Camera _gameCamera;

        public List<SpaceObject> AsteroidsPrefabs => _asteroidsPrefabs;
        public GameObject[] Boundaries => _boundaries;
        public Camera Camera => _gameCamera;

        public List<Object> GetAllPrefabs()
        {
            List<Object> prefabs = new List<Object>();

            for (int i = 0; i < _boundaries.Length; i++) 
                prefabs.Add(_boundaries[i]);
            prefabs.Add(_gameCamera);

            return prefabs;
        }
    }
}
