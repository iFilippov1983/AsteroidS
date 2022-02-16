using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/SceneData", fileName = "SceneData")]
    public sealed class SceneData : ScriptableObject
    {
        private const string SceneDataFolderPath = "Scene/";
        private const string SceneName = "AsteroidS";

        [Header("Assets to place on scene")]
        [SerializeField] private string _cameraPrefabPath;
        [SerializeField, Range(4, 199)] private float _cameraMinSize;
        [SerializeField, Range(5, 200)] private float _cameraMaxSize;
        [SerializeField] private string _cameraBackgroundPrefabPath;
        [SerializeField] private string[] _cameraBackgroundPicturesPaths;
        [SerializeField] private string _parallaxBackgroundPrefabPath;
        [SerializeField] private string[] _backgroundParallaxPicturesPaths;
        
        private Camera _gameCamera;
        private Canvas _cameraBackgroundPrefab;
        private Sprite[] _cameraBackgroundPictures;
        private Transform _parallaxBackgroundPrefab;
        private Sprite[] _parallaxBackgroundPictures;
        [SerializeField] private Vector2 _parallaxEffectMultiplier;

        public string ThisSceneName => SceneName;
        public Camera Camera => CameraPrefab;
        public Canvas CameraBackgroundCanvas => GetCameraBackgroundCanvas();
        public Transform ParallaxBackground => GetParallaxBackground();
        public Vector2 ParallaxEffectMultiplier => _parallaxEffectMultiplier;

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

        private Camera CameraPrefab
        {
            get
            {
                if (_gameCamera == null) _gameCamera =
                        Resources.Load<Camera>(SceneDataFolderPath + _cameraPrefabPath);
                return _gameCamera;
            }

        }

        private Sprite[] CameraBackgroundPictures
        {
            get
            {
                if (_cameraBackgroundPictures == null)
                {
                    _cameraBackgroundPictures = new Sprite[_cameraBackgroundPicturesPaths.Length];
                    for (int index = 0; index < _cameraBackgroundPicturesPaths.Length; index++)
                    {
                        _cameraBackgroundPictures[index] = 
                            Resources.Load<Sprite>
                            (SceneDataFolderPath + _cameraBackgroundPicturesPaths[index]);
                    }
                }
                return _cameraBackgroundPictures;        
            }
        }

        private Sprite[] ParallaxPictures
        {
            get
            {
                if (_parallaxBackgroundPictures == null)
                {
                    var paths = _backgroundParallaxPicturesPaths;
                    _parallaxBackgroundPictures = new Sprite[paths.Length];
                    for (int index = 0; index < paths.Length; index++)
                    {
                        _parallaxBackgroundPictures[index] =
                            Resources.Load<Sprite>
                            (SceneDataFolderPath + paths[index]);
                    }
                }
                return _parallaxBackgroundPictures;
            }
        }

        public List<Object> GetAllPrefabs()
        {
            List<Object> prefabs = new List<Object>();
              
            prefabs.Add(CameraPrefab);
            prefabs.Add(GetCameraBackgroundCanvas());
            prefabs.Add(GetParallaxBackground());

            return prefabs;
        }

        private Sprite GetRandomSprite(Sprite[] sprites)
        {
            Debug.Log(sprites.Length);
            var randomSprite = sprites[Random.Range(0, sprites.Length)];
            return randomSprite;
        }

        private Canvas GetCameraBackgroundCanvas()
        {
            if (_cameraBackgroundPrefab == null)
            {
                _cameraBackgroundPrefab = Resources.Load<Canvas>(SceneDataFolderPath + _cameraBackgroundPrefabPath);
                _cameraBackgroundPrefab.GetComponentInChildren<Image>().sprite = GetRandomSprite(CameraBackgroundPictures);
            }
            return _cameraBackgroundPrefab;
        }

        private Transform GetParallaxBackground()
        {
            if (_parallaxBackgroundPrefab == null)
            {
                _parallaxBackgroundPrefab = Resources.Load<GameObject>(SceneDataFolderPath + _parallaxBackgroundPrefabPath).transform;
                _parallaxBackgroundPrefab.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(ParallaxPictures);
            }
            return _parallaxBackgroundPrefab;
        }
    }
}
