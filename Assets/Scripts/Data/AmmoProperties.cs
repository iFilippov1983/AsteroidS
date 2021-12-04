using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/AmmoProperties", fileName = "AmmoProperties")]
    public class AmmoProperties : ScriptableObject
    {
        public AmmoType ammoType;
        public int damage;
        public float fireRate;
        public float shotDistance;
        public float speedRate;
    }
}
