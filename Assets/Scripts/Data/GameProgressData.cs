using System;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/GameProgressData", fileName = "GameProgressData")]
    public class GameProgressData : ScriptableObject
    {
        private const string LevelPropetriesFolderPath = "LevelProperties/";

        [Range(1, 100)]
        [SerializeField] private int _currentLevel;
        [SerializeField] private string[] _levelPropertiesPathArray;

        [SerializeField] private int _currentScores;

        private GameLevelProperties[] _levelsPropertiesArray = null;

        public TimeSpan LevelDuration => TimeSpan.FromSeconds(CurrentLevelProperties.LevelDuration);

        public int CurrentScores { get => _currentScores; set => _currentScores = value; }

        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }

        public GameLevelProperties CurrentLevelProperties
        {
            get 
            {
                var properties = LevelPropetiesArray;
                if (_currentLevel > properties.Length)
                {
                    return properties[properties.Length - 1];
                } 
                else return properties[_currentLevel - 1];
            }
        }

        private GameLevelProperties[] LevelPropetiesArray
        {
            get
            {
                if (_levelsPropertiesArray == null)
                {
                    _levelsPropertiesArray = new GameLevelProperties[_levelPropertiesPathArray.Length];
                    for (int index = 0; index < _levelPropertiesPathArray.Length; index++)
                    {
                        _levelsPropertiesArray[index] = Resources.Load<GameLevelProperties>(LevelPropetriesFolderPath + _levelPropertiesPathArray[index]);
                    }
                }

                return _levelsPropertiesArray;
            }
        }
    }
}
