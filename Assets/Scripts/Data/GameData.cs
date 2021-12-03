using System.IO;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/GameData", fileName = "GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _sceneDataPath;
        [SerializeField] private string _spaceObjectsDataPath;

        private PlayerData _playerData;
        private SceneData _sceneData;
        private SpaceObjectsData _spaceObjectsData;

        public PlayerData PlayerData
        {
            get 
            {
                if (_playerData == null) _playerData = LoadPath<PlayerData>("GameData/" + _playerDataPath);
                return _playerData;
            }
        }

        public SceneData SceneData
        {
            get 
            {
                if (_sceneData == null) _sceneData = LoadPath<SceneData>("GameData/" + _sceneDataPath);
                return _sceneData;
            }
        }

        public SpaceObjectsData SpaceObjectsData
        {
            get 
            {
                if (_spaceObjectsData == null) _spaceObjectsData = LoadPath<SpaceObjectsData>("GameData/" + _spaceObjectsDataPath);
                return _spaceObjectsData;
            }
        }

        private T LoadPath<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));
    }
}

