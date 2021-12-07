using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/AmmoProperties", fileName = "AmmoProperties")]
    public class AmmoProperties : ScriptableObject
    {
        public AmmoType ammoType;
        public int damage;
        [Range(1, 30)]
        public float reloadTime;
        public float shotDistance;
        public float speedRate;

        public float LifeTime => shotDistance / speedRate;
       
    }
}
