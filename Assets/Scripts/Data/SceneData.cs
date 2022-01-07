using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/SceneData", fileName = "SceneData")]
    public class SceneData : ScriptableObject
    {
        private const string SceneDataFolderPath = "Scene";
        private const string SceneName = "AsteroidS";

        [Header("Assets to place on scene")]
        [SerializeField] private string _boundariesPrefabsPath;
        [SerializeField] private string _cameraPrefabPath;
        [SerializeField, Range(4, 199)] private float _cameraMinSize;
        [SerializeField, Range(5, 200)] private float _cameraMaxSize;
        [SerializeField] private string _backgroundPrefabPath;
        [SerializeField] private string _backgroundPicturesPath;
        
        [SerializeField] private GameObject[] _boundaries;
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private Canvas _backgroundPrefab;
        [SerializeField] private Sprite[] _backgroundPictures;

        public string ThisSceneName => SceneName;
        public GameObject[] Boundaries => _boundaries;
        public Camera Camera => _gameCamera;
        public Canvas Background => _backgroundPrefab;

        public float CameraMinSize
        {
            get
            {
                if (_cameraMaxSize > _cameraMinSize) return _cameraMinSize;
                else return _cameraMaxSize;
            }
        }

        public float CameraMaxSize
        {
            get
            {
                if (_cameraMaxSize > _cameraMinSize) return _cameraMaxSize;
                else return _cameraMinSize;
            }
        }

        public List<Object> GetAllPrefabs()
        {
            List<Object> prefabs = new List<Object>();

            //for (int i = 0; i < _boundaries.Length; i++)
            //    prefabs.Add(_boundaries[i]);
              
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
