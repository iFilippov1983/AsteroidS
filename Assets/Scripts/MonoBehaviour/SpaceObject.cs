﻿using System;
using UnityEngine;

namespace AsteroidS
{
    public class SpaceObject : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private string _spaceObjectPropertiesPath;

        private SpaceObjectProperties _spaceObjectProperties;
        private float _lifeTimeCounter = 0;

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

        public Action<SpaceObject> SpaceObjectHit;
        public Action<SpaceObject> LifeTimeTermination;
        public Action PlayerHit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == TagsHolder.Ammo)
            {
                var ammo = collision.gameObject;
                var damage = ammo.GetComponent<Ammo>().Properties.damage;
                _spaceObjectProperties.hitPoints -= damage;
                SpaceObjectHit?.Invoke(this);
            }

            if (collision.gameObject.tag == TagsHolder.Player)
            {
                PlayerHit?.Invoke();
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
                LifeTimeTermination?.Invoke(this);
            }
        }

    }
}
