using System;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/GameProgressData", fileName = "GameProgressData")]
    public class GameProgressData : ScriptableObject
    {
        [Range(1, float.MaxValue)]
        [SerializeField] private double _levelDuration;
        [Range(1, 100)]
        [SerializeField] private int _currentLevel;
        [SerializeField] private GameLevelProperties[] _levelsPropertiesList;
        [SerializeField] private int _currentScores;

        public TimeSpan LevelDuration => TimeSpan.FromSeconds(_levelDuration);
        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
        public GameLevelProperties[] LevelPropetiesList => _levelsPropertiesList;
        public int CurrentScores { get => _currentScores; set => _currentScores = value; }

        public GameLevelProperties CurrentLevelProperties
        {
            get 
            {
                if (_currentLevel > _levelsPropertiesList.Length)
                {
                    return _levelsPropertiesList[_levelsPropertiesList.Length - 1];
                } 
                else return _levelsPropertiesList[_currentLevel - 1];
            }
        }

        
    }
}
