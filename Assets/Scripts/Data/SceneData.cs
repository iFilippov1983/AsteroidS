using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/SceneData", fileName = "SceneData")]
    public class SceneData : ScriptableObject 
    {
        [SerializeField] private const string _sceneName = "AsteroidS";
        [Header("Assets to place on scene")]
        [SerializeField] private GameObject[] _boundaries;
        [SerializeField] private Camera _gameCamera;

        public string SceneName => _sceneName;
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
