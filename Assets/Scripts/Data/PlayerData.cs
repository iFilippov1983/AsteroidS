using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Ammo[] _ammoPrefabs;
        [SerializeField] private float _MoveSpeed;
        [SerializeField] private float _rotationSpeed;
        public Ammo currentAmmo;
        [SerializeField] private Vector3 _shotOffset;

        public GameObject PlayerPrefab => _playerPrefab;
        public Ammo[] AmmoPrefabs => _ammoPrefabs;
        public float PlayerMovementSpeed => _MoveSpeed;
        public float PlayerRotationSpeed => _rotationSpeed;
        public Vector3 ShotOffset => _shotOffset;
    }
}

