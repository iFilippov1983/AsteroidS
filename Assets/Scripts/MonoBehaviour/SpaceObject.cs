using System;
using UnityEngine;

namespace AsteroidS
{
    public class SpaceObject : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private string _spaceObjectPropertiesPath;

        private SpaceObjectProperties _spaceObjectProperties;
        private float _lifeTimeCounter = 0;

        public Collider2D Collider => GetComponent<Collider2D>();
        public Rigidbody2D Rigidbody => GetComponent<Rigidbody2D>();
        public Sprite[] GetSprites => _sprites;

        public SpaceObjectProperties Properties
        {
            get 
            {
                if (_spaceObjectProperties == null)
                {
                    _spaceObjectProperties = Resources.Load<SpaceObjectProperties>("GameData/" + _spaceObjectPropertiesPath);
                }

                return _spaceObjectProperties;
            }
        }

        public Action<SpaceObject> OnSpaceObjectHit;
        public Action<SpaceObject> OnLifeTimeIsOver;
        public Action OnPlayerHit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Ammo ammo))
            {
                //Debug.Log(ammo);
                var damage = ammo.Properties.damage;
                _spaceObjectProperties.hitPoints -= damage;
                OnSpaceObjectHit?.Invoke(this);
            }

            if (collision.gameObject.tag == TagsHolder.Player)
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

        private void Live()
        {
            _lifeTimeCounter += Time.deltaTime;

            if (_lifeTimeCounter >= _spaceObjectProperties.maxLifeTime)
            {
                _lifeTimeCounter = 0;
                OnLifeTimeIsOver?.Invoke(this);
            }
        }

    }
}
