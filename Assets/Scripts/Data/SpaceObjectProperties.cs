using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/SO_Properties", fileName = "NameOfSpaceObject_Properties")]
    public class SpaceObjectProperties : ScriptableObject
    {
        public SpaceObjectType type;
        public int hitPoints;
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
    }
}
