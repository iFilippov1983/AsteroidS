using AsteroidS;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    internal class BulletsController : IInitialization, IExecute
    {
        private List<Asteroid> _asteroids;
        private Rigidbody2D _rigidbody2D;
        private float _distanse = 2f;
        private Transform _transform;
        private bool _shootingTimer = true;
        private float _rateOfFaire = 5f;
        internal BulletsController(List<Asteroid> asteroids, Transform player)
        {
            _asteroids = asteroids;
            _rigidbody2D = player.GetComponent<Rigidbody2D>();
            _transform = player.transform;
        }

        public Bullet _bullets;
        public void Execute(float deltaTime)
        {

            Vector2 rotation = new Vector2(_transform.rotation.x, _transform.rotation.y);
            RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position, rotation, _distanse);
            if (hit != null)
            {
                if (_shootingTimer)
                {
                    var asteroidHut = GetAsteroid(hit);
                    _shootingTimer = false;
                    //asteroidHut.damag();
                    Timer(_rateOfFaire);
                }
            }
        }

        public void Initialize()
        {
            
        }

        private Asteroid GetAsteroid(RaycastHit2D hit)
        {
            Asteroid result = null; 
            foreach (var item in _asteroids)
            {
                if (item.gameObject == hit)
                {
                    result = item;
                }                
            }
            return result;
        }

        private void Timer(float rateOfFaire)
        {
            rateOfFaire -= Time.deltaTime;
            if (rateOfFaire < 0)
            {
                _shootingTimer = true;
                return;
            }
        }
    }
}
