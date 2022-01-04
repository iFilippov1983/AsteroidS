using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/SO_Properties", fileName = "NameOfSpaceObject_Properties")]
    public class SpaceObjectProperties : ScriptableObject
    {
        [SerializeField] private SpaceObjectType _type;
        [SerializeField] private int _scoresForDestruction;
        [SerializeField] private float _mass;

        [SerializeField] private bool _isPickable;
        [SerializeField] private bool _isBreakable;
        [SerializeField] private bool _isShooting;

        public int hitPoints;
        public int armorPoints;
        public int amountOnScene;
        public float speed;
        public float maxLifeTime;

        public bool isChild;

        public SpaceObjectType Type => _type;
        public int ScoresForDestrustion => _scoresForDestruction;
        public float Mass => _mass;

        public bool IsPickable => _isPickable;
        public bool IsBreakable => _isBreakable;
        public bool IsShooting => _isShooting;

        public bool HasArmor
        {
            get
            {
                if (armorPoints > 0) return true;
                else return false;
            }
        }

        public float ChildSpeedMiltiplyer
        {
            get
            {
                if (isChild) return Random.Range(1.2f, 2);
                else return 1f;
            }
        }
    }
}
