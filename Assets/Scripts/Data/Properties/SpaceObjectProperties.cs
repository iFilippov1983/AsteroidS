using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/SO_Properties", fileName = "NameOfSpaceObject_Properties")]
    public class SpaceObjectProperties : ScriptableObject
    {
        public SpaceObjectType type;
        public int hitPoints;
        public int armorPoints;
        public int scoresForDestruction;
        public float mass;
        public int amountOnScene;
        public float speed;
        public float maxLifeTime;

        public bool isPickable;
        public bool isBreakable;
        public bool isChild;
        public bool canBeChild;
        public bool isShooting;

        public bool HasArmor
        {
            get
            {
                if (armorPoints != 0) return true;
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
