using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/AmmoProperties", fileName = "AmmoProperties")]
    public class AmmoProperties : ScriptableObject
    {
        public AmmoType ammoType;
        public int damage;
        [Range(1f, 30f)]
        public float reloadTime;
        public float shotDistance;
        public float speedRate;
        [Header("Time multiplier for different lifetime counters")]
        public int timeMultiplier;

        public float AmmoAmount => shotDistance / speedRate + 1;
        public float LifeTime => shotDistance / speedRate * timeMultiplier;
       
    }
}
