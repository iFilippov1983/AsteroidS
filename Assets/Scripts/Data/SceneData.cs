using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/SceneData", fileName = "SceneData")]
    public class SceneData : ScriptableObject
    {
        [SerializeField] private const string _sceneName = "AsteroidS";
        [Header("Assets to place on scene")]
        [SerializeField] private GameObject[] _boundaries;
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private Canvas _backgroundPrefab;
        [SerializeField] private Sprite[] _backgroundPictures;

        public string SceneName => _sceneName;
        public GameObject[] Boundaries => _boundaries;
        public Camera Camera => _gameCamera;
        public Canvas Background => _backgroundPrefab; 

        public List<Object> GetAllPrefabs()
        {
            List<Object> prefabs = new List<Object>();

            for (int i = 0; i < _boundaries.Length; i++)
                prefabs.Add(_boundaries[i]);
              
            prefabs.Add(_gameCamera);
            prefabs.Add(SetBackground());

            return prefabs;
        }

        private Canvas SetBackground()
        {
            var randomSprite = _backgroundPictures[Random.Range(0, _backgroundPictures.Length)];
            _backgroundPrefab.GetComponentInChildren<Image>().sprite = randomSprite;

            return _backgroundPrefab;
        }
    }
}
