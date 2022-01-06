using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        private const string PlayerPrefabsFolderPath = "PlayerPrefabs/";
        private const string AmmoPrefabsFolderPath = "AmmoPrefabs/";
        private const string PlayerSpritesFolderPath = "Sprites/Player/";

        [SerializeField] private string _playerPrefabPath;
        [SerializeField] private string[] _ammoPrefabsPath;
        [SerializeField] private string[] _playerSpritesPath;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        private Ammo _currentAmmo;
        private GameObject _playerPrefab;
        private Ammo[] _ammoPrefabs;
        private Sprite[] _playerViewSprites;

        public GameObject PlayerPrefab => PlayerPrefabWithRandomSprite();
        public Dictionary<AmmoType,Ammo> AmmoPrefabsDictionary => MakeAmmoPrefabsDictionary();
        public float PlayerMovementSpeed => _moveSpeed;
        public float PlayerRotationSpeed => _rotationSpeed;

        public Ammo CurrentAmmo
        {
            get
            {
                if (_currentAmmo == null) return AmmoPrefabs[0];
                else return _currentAmmo;
            }
        }
        
        public Action OnAmmoSwitched;

        public void SwitchAmmoTo(int number)
        {
            var prefabs = AmmoPrefabs;

            if (number > prefabs.Length || number == 0) return;

            _currentAmmo = prefabs[number - 1];

            OnAmmoSwitched?.Invoke();
        }

        private Ammo[] AmmoPrefabs
        {
            get 
            {
                if (_ammoPrefabs == null)
                {
                    _ammoPrefabs = new Ammo[_ammoPrefabsPath.Length];

                    for (int index = 0; index < _ammoPrefabsPath.Length; index++)
                    {
                        _ammoPrefabs[index] = Resources.Load<Ammo>(AmmoPrefabsFolderPath + _ammoPrefabsPath[index]);
                    }
                }

                return _ammoPrefabs;
            }
        }

        private GameObject LoadedPlayerPrefab
        {
            get
            {
                if (_playerPrefab == null) _playerPrefab = 
                        Resources.Load<GameObject>(PlayerPrefabsFolderPath + _playerPrefabPath);

                return _playerPrefab;
            }
        }

        private Sprite[] PlayerSprites
        {
            get
            {
                if (_playerViewSprites == null)
                {
                    _playerViewSprites = new Sprite[_playerSpritesPath.Length];

                    for (int index = 0; index < _playerSpritesPath.Length; index++)
                    {
                        _playerViewSprites[index] = Resources.Load<Sprite>(PlayerSpritesFolderPath + _playerSpritesPath[index]);
                    }
                }

                return _playerViewSprites;
            }
        }

        private Dictionary<AmmoType, Ammo> MakeAmmoPrefabsDictionary()
        {
            var dictionary = new Dictionary<AmmoType, Ammo>();
            var prefabs = AmmoPrefabs;

            for (int index = 0; index < prefabs.Length; index++)
            {
                var type = prefabs[index].Properties.AmmoType;
                dictionary[type] = prefabs[index];
            }

            return dictionary;
        }

        private GameObject PlayerPrefabWithRandomSprite()
        {
            var randomSprite = PlayerSprites[Random.Range(0, PlayerSprites.Length)];
            var spriteRenderer = LoadedPlayerPrefab.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = randomSprite;

            return _playerPrefab;
        }
    }
}

