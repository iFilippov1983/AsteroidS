using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject[] _ammoPrefabs;
        [SerializeField] private float _MoveSpeed;
        [SerializeField] private float _rotationSpeed;

        public GameObject PlayerPrefab { get => _playerPrefab; }
        public GameObject[] BulletDefaultPrefab { get => _ammoPrefabs; }
        public float PlayerMovementSpeed { get => _MoveSpeed; }
        public float PlayerRotationSpeed { get => _rotationSpeed; }
    }
}

