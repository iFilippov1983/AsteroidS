using UnityEngine;

namespace AsteroidS
{
    [CreateAssetMenu(menuName = "GameData/Properties/AmmoProperties", fileName = "AmmoProperties")]
    public class AmmoProperties : ScriptableObject
    {
        private const string AmmoSpritesFolderPath = "Sprites/Ammo/";

        [SerializeField] private string _ammoSpritePath;
        [SerializeField] private AmmoType _ammoType;
        [SerializeField] private int _damage;
        [SerializeField, Range(1f, 30f)]
                         private float _reloadTime;
        [SerializeField] private float _shotDistance;
        [SerializeField] private float _gunAngleOfView;
        [SerializeField] private float _speedRate;
        [SerializeField, Range(1, int.MaxValue), Header("(Temp) Time multiplier for different ammo lifetime counters")]
                         private int _timeMultiplyer;

        private Sprite _ammoSprite;

        public Sprite AmmoSprite
        {
            get
            {
                if (_ammoSprite == null) _ammoSprite = Resources.Load<Sprite>(AmmoSpritesFolderPath + _ammoSpritePath);
                return _ammoSprite;
            }
        }

        public AmmoType AmmoType => _ammoType;
        public int Damage => _damage;
        public float ReloadTime => _reloadTime;
        public float ShotDistance => _shotDistance;
        public float FieldOfView => _gunAngleOfView;
        public float SpeedRate => _speedRate;
        public float AmmoAmount => _shotDistance / _speedRate + 1;
        public float LifeTime => _shotDistance / _speedRate * _timeMultiplyer;
        public int TimeMultiplyer => _timeMultiplyer;
       
    }
}
