using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/SO_Properties", fileName = "NameOfSpaceObject_Properties")]
    public sealed class SpaceObjectProperties : ScriptableObject
    {
        private const string SOSpritesFolderPath = "Sprites/SpaceObjects/";

        [SerializeField] private SpaceObjectType _type;
        [SerializeField] private SpaceObjectName _name;
        [SerializeField] private int _scoresForDestruction;
        [SerializeField] private float _massMin;
        [SerializeField] private float _massMax;

        [SerializeField] private bool _isPickable;
        [SerializeField] private bool _isBreakable;
        [SerializeField] private bool _isShooting;

        [SerializeField] private string[] _soSpritesPath;
        private Sprite[] _soSprites = null;

        public int hitPoints;
        public int armorPoints;
        public int amountOnScene;
        public float speed;
        public float maxLifeTime;

        public SpaceObjectType Type => _type;
        public SpaceObjectName Name => _name;
        public int ScoresForDestrustion => _scoresForDestruction;
        public float Mass => Random.Range(_massMin, _massMax);
        public float MassMin => _massMin;

        public bool IsPickable => _isPickable;
        public bool IsBreakable => _isBreakable;
        public bool IsShooting => _isShooting;

        public Sprite[] SpaceObjectSprites => LoadSOSprites();

        public bool HasArmor
        {
            get
            {
                if (armorPoints > 0) return true;
                else return false;
            }
        }

        private Sprite[] LoadSOSprites()
        {
            if (_soSprites == null || _soSprites.Length == 0)
            {
                _soSprites = new Sprite[_soSpritesPath.Length];
                for (int index = 0; index < _soSpritesPath.Length; index++)
                {
                    _soSprites[index] = Resources.Load<Sprite>(SOSpritesFolderPath + _soSpritesPath[index]);
                }
            }

            return _soSprites;
        }
    }
}
