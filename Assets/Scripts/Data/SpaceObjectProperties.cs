using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/SpaceObjectProperties", fileName = "Properties")]
    public class SpaceObjectProperties : ScriptableObject
    {
        public SpaceObjectType type;
        public int hitPoints;
        public float mass;
        public int amountOnScene;
        public float speed;
        public bool isBreakable;
        public bool isShooting;
    }
}
