using Assets.Scripts.Data;
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
        [SerializeField] private string _uiDataPath;
        [SerializeField] private string _gameProgressDataPath;
        [SerializeField] private string _soundDataPath;

        private PlayerData _playerData;
        private SceneData _sceneData;
        private UIData _uiData;
        private GameProgressData _gameProgressData;
        private SoundData _soundData;

        public PlayerData PlayerData
        {
            get 
            {
                if (_playerData == null) _playerData = 
                        LoadPath<PlayerData>(_gameDataFolder + _playerDataPath);
                return _playerData;
            }
        }

        public SceneData SceneData
        {
            get 
            {
                if (_sceneData == null) _sceneData = 
                        LoadPath<SceneData>(_gameDataFolder + _sceneDataPath);
                return _sceneData;
            }
        }

        public UIData UIData
        {
            get
            {
                if (_uiData == null) _uiData = 
                        LoadPath<UIData>(_gameDataFolder + _uiDataPath);
                return _uiData;
            }
        }

        public GameProgressData GameProgressData
        {
            get 
            {
                if (_gameProgressData == null) _gameProgressData = 
                        LoadPath<GameProgressData>(_gameDataFolder + _gameProgressDataPath);
                return _gameProgressData;
            }
        }

        public SoundData SoundData
        {
            get
            {
                if (_soundData == null) _soundData = 
                        LoadPath<SoundData>(_gameDataFolder + _soundDataPath);
                return _soundData;
            }
        }

        private T LoadPath<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));
    }
}

