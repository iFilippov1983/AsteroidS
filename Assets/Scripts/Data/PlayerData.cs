using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private List<Ammo> _ammoPrefabs;
        [SerializeField] private float _MoveSpeed;
        [SerializeField] private float _rotationSpeed;
        public Ammo currentAmmo;
        [SerializeField] private Vector3 _shotOffset;

        public GameObject PlayerPrefab => _playerPrefab;
        public Dictionary<AmmoType,Ammo> AmmoPrefabsDictionary => MakePrefabsDictionary();
        public float PlayerMovementSpeed => _MoveSpeed;
        public float PlayerRotationSpeed => _rotationSpeed;
        public Vector3 ShotOffset => _shotOffset;



        private Dictionary<AmmoType, Ammo> MakePrefabsDictionary()
        {
            var dictionary = new Dictionary<AmmoType, Ammo>();

            for (int index = 0; index < _ammoPrefabs.Count; index++)
            {
                var type = _ammoPrefabs[index].Properties.ammoType;
                dictionary[type] = _ammoPrefabs[index];
            }

            return dictionary;
        }
    }
}

