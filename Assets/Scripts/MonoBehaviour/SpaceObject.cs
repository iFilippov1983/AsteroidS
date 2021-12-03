using System;
using UnityEngine;

namespace AsteroidS
{
    public class SpaceObject : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private string _spaceObjectPropertiesPath;

        private SpaceObjectProperties _properties;
        private float _lifeTimeCounter = 0;

        public Collider2D Collider => GetComponent<Collider2D>();
        public Rigidbody2D Rigidbody => GetComponent<Rigidbody2D>();
        public Sprite[] GetSprites => _sprites;

        public SpaceObjectProperties GetSpaceObjectProperties
        {
            get 
            {
                if (_properties == null)
                {
                    _properties = Resources.Load<SpaceObjectProperties>("GameData/" + _spaceObjectPropertiesPath);
                }

                return _properties;
            }
        }

        public Action<SpaceObject> OnSpaceObjectHit;
        public Action<SpaceObject> OnLifeTimeIsOver;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.GetType() == typeof(Ammo)) OnSpaceObjectHit?.Invoke(this);
            if (_properties.isChild) Destroy(gameObject);
        }

        private void Update()
        {
            _lifeTimeCounter += Time.deltaTime;

            if (_lifeTimeCounter >= _properties.maxLifeTime)
            {
                _lifeTimeCounter = 0;
                OnLifeTimeIsOver?.Invoke(this);
            } 
        }

        private void OnDisable()
        {
            _lifeTimeCounter = 0;
        }
    }
}
