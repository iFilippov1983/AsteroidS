using System;
using UnityEngine;


namespace AsteroidS
{

    public class SpaceObject : MonoBehaviour
    {
        private const string PropertiesPath = "SpaceObjectsProperties/";

        [SerializeField] private string _spaceObjectPropertiesPath;

        private SpaceObjectProperties _spaceObjectProperties;
        private float _lifeTimeCounter = 0;
        private int _hitPoints;
        private int _armorPoints;

        public Sprite[] GetSprites => Properties.SpaceObjectSprites;
        public int HitPoints => _hitPoints;
        public int ArmorPoints => _armorPoints;

        public SpaceObjectProperties Properties
        {
            get 
            {
                if (_spaceObjectProperties == null)
                {
                    _spaceObjectProperties = Resources.Load<SpaceObjectProperties>(PropertiesPath + _spaceObjectPropertiesPath);
                }

                return _spaceObjectProperties;
            }
        }

        public Action<SpaceObject> OnSpaceObjectHit;
        public Action<SpaceObject> OnLifeTimeTermination;
        public Action OnPlayerHit;

        private void OnEnable()
        {
            _hitPoints = Properties.hitPoints;
            _armorPoints = Properties.armorPoints;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Ammo>())
            {
                var ammo = collision.gameObject;
                var damage = ammo.GetComponent<Ammo>().Properties.Damage;

                if (_armorPoints > 0) _armorPoints -= damage;
                else _hitPoints -= damage;

                OnSpaceObjectHit?.Invoke(this);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == TagOrName.Player)
            {
                OnPlayerHit?.Invoke();
            }
        }

        private void Update()
        {
            Live();
        }

        private void OnDisable()
        {
            _lifeTimeCounter = 0;
        }

        private void OnDestroy()
        {
            if (Properties.isChild) Properties.isChild = false;
        }

        private void Live()
        {
            _lifeTimeCounter += Time.deltaTime;

            if (_lifeTimeCounter >= _spaceObjectProperties.maxLifeTime)
            {
                _lifeTimeCounter = 0;
                OnLifeTimeTermination?.Invoke(this);
            }
        }
    }
}
