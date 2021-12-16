using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Sprite[] _playerViewSprites;
        [SerializeField] private List<Ammo> _ammoPrefabs;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        public Ammo currentAmmo;

        public GameObject PlayerPrefab => SetPlayerSpriteBeforeReturn();
        public Dictionary<AmmoType,Ammo> AmmoPrefabsDictionary => MakePrefabsDictionary();
        public float PlayerMovementSpeed => _moveSpeed;
        public float PlayerRotationSpeed => _rotationSpeed;

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

        private GameObject SetPlayerSpriteBeforeReturn()
        {
            var randomSprite = _playerViewSprites[Random.Range(0, _playerViewSprites.Length)];
            var spriteRenderer = _playerPrefab.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = randomSprite;

            return _playerPrefab;
        }
    }
}

