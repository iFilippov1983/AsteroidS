using System.IO;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/GameData", fileName = "GameData")]
    public class GameData : ScriptableObject
    {
        private const string _gameDataFolder = "GameData/";
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _sceneDataPath;
        [SerializeField] private string _spaceObjectsDataPath;
        [SerializeField] private string _uiDataPath;
        
        private PlayerData _playerData;
        private SceneData _sceneData;
        private SpaceObjectsData _spaceObjectsData;
        private UIData _uiData;

        public PlayerData PlayerData
        {
            get 
            {
                if (_playerData == null) _playerData = LoadPath<PlayerData>(_gameDataFolder + _playerDataPath);
                return _playerData;
            }
        }

        public SceneData SceneData
        {
            get 
            {
                if (_sceneData == null) _sceneData = LoadPath<SceneData>(_gameDataFolder + _sceneDataPath);
                return _sceneData;
            }
        }

        public SpaceObjectsData SpaceObjectsData
        {
            get 
            {
                if (_spaceObjectsData == null) _spaceObjectsData = LoadPath<SpaceObjectsData>(_gameDataFolder + _spaceObjectsDataPath);
                return _spaceObjectsData;
            }
        }

        public UIData UIData
        {
            get
            {
                if (_uiData == null) _uiData = LoadPath<UIData>(_gameDataFolder + _uiDataPath);
                return _uiData;
            }
        }

        private T LoadPath<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));
    }
}

