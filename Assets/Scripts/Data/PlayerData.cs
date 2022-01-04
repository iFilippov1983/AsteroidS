using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        private const string PlayerPrefabsPath = "PlayerPrefabs/";
        private const string AmmoPrefabsPath = "AmmoPrefabs/";

        [SerializeField] private string _playerPrefabPath;
        [SerializeField] private Sprite[] _playerViewSprites;
        [SerializeField] private Ammo[] _ammoPrefabs;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Ammo _currentAmmo;
        private GameObject _playerPrefab;

        public GameObject PlayerPrefab => SetPlayerSpriteBeforeReturn();
        public Dictionary<AmmoType,Ammo> AmmoPrefabsDictionary => MakeAmmoPrefabsDictionary();
        public float PlayerMovementSpeed => _moveSpeed;
        public float PlayerRotationSpeed => _rotationSpeed;
        public Ammo CurrentAmmo => _currentAmmo;

        public Action OnAmmoSwitched;

        private GameObject LoadPlayerPrefab
        {
            get
            {
                if (_playerPrefab == null)
                {
                    _playerPrefab = Resources.Load<GameObject>(PlayerPrefabsPath + _playerPrefabPath);
                }
                return _playerPrefab;
            }
        }

        public void SwitchAmmoTo(int number)
        {
            if (number > _ammoPrefabs.Length || number == 0) return;

            _currentAmmo = _ammoPrefabs[number - 1];

            OnAmmoSwitched?.Invoke();
        }

        public void SetDefaultAmmo()
        {
            _currentAmmo = _ammoPrefabs[0];
        }

        private Dictionary<AmmoType, Ammo> MakeAmmoPrefabsDictionary()
        {
            var dictionary = new Dictionary<AmmoType, Ammo>();

            for (int index = 0; index < _ammoPrefabs.Length; index++)
            {
                var type = _ammoPrefabs[index].Properties.ammoType;
                dictionary[type] = _ammoPrefabs[index];
            }

            return dictionary;
        }

        private GameObject SetPlayerSpriteBeforeReturn()
        {
            var randomSprite = _playerViewSprites[Random.Range(0, _playerViewSprites.Length)];
            var spriteRenderer = LoadPlayerPrefab.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = randomSprite;

            return _playerPrefab;
        }

       
    }
}

