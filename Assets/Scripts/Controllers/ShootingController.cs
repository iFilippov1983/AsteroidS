using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AsteroidS
{
    internal class ShootingController : IInitialization, IExecute
    {
        private Transform _player;
        private float _shotDistance;
        private bool _ammoReloaded = true;
        private float _rateOfFire;
        private float _counter = 0;
        private float _speedRate;
        private Ammo _ammo;
        private Vector3 _shotOffset;

        internal ShootingController(GameData gameData, Transform player)
        {
            _player = player;
            _rateOfFire = gameData.PlayerData.currentAmmo.Properties.fireRate;
            _shotDistance = gameData.PlayerData.currentAmmo.Properties.shotDistance;
            _speedRate = gameData.PlayerData.currentAmmo.Properties.speedRate;
            _ammo = gameData.PlayerData.currentAmmo;
            _shotOffset = gameData.PlayerData.ShotOffset;
        }

        public void Initialize()
        {

        }

        public void Execute(float deltaTime)
        {
            Timer(deltaTime);
            var hit = Physics2D.Raycast(_player.position + _shotOffset, _player.eulerAngles, _shotDistance);
            
            if (hit && _ammoReloaded)
            {
                Shoot();
                _ammoReloaded = false;   
            }
        }

        private void Timer(float deltaTime)
        {
            _counter += deltaTime;
            if (_counter > _rateOfFire && !_ammoReloaded)
            {
                _counter = 0;
                _ammoReloaded = true;
            }
        }

        private void Shoot()
        {
            var shot = Object.Instantiate(_ammo.gameObject, _player.position, _player.rotation);
            var rb = shot.GetComponent<Rigidbody2D>();
            var vector = _player.localRotation.eulerAngles.normalized;
            rb.AddForce(vector * _speedRate);
        }
    }
}