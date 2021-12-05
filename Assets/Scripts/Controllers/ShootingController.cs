using Assets.Scripts.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AsteroidS
{
    internal class ShootingController : IInitialization, IExecute
    {
        private GameData _gameData;
        private Transform _player;
        private float _shotDistance;
        private float _rateOfFire;
        private float _bulletRemovalTimer = 0.5f;
        private float _speedRate=1;
        private Ammo _ammo;
        //private Vector3 _shotOffset;
        private bool _shootingTimer = true;
        private Coroutine _coroutineTimer;
        private Coroutine _counterTimerDelete;


        internal ShootingController(GameData gameData, Transform player)
        {
            _gameData = gameData;
            _player = player;
        }

        public void Initialize()
        {
            _rateOfFire = _gameData.PlayerData.currentAmmo.Properties.fireRate;
            _shotDistance = _gameData.PlayerData.currentAmmo.Properties.shotDistance;
            _speedRate = _gameData.PlayerData.currentAmmo.Properties.speedRate;
            _ammo = _gameData.PlayerData.currentAmmo;
            //_shotOffset = _gameData.PlayerData.ShotOffset;
        }

		public void Execute(float deltaTime)
		{
            int mask = LayerMask.GetMask(MasksHolder.SpaceObject);

            var hit = Physics2D.Raycast(_player.position, _player.up, _shotDistance, mask);
            Debug.DrawRay(_player.position, _player.up*_shotDistance, Color.red);
            
            if (hit == _ammo)
			{
				if (_shootingTimer == true)
				{
					Shoot();
					_shootingTimer = false;
                    _coroutineTimer = CoroutinesController.StartRoutine(Timer(_rateOfFire));
                    Debug.Log("Попадание");   
                }
				Debug.Log("Есть цель");
			}
		}
        IEnumerator Timer(float timeInSec)
        {
            yield return new WaitForSeconds(timeInSec);
            _shootingTimer = true;
            CoroutinesController.StopRoutine(_coroutineTimer);
        }

        private void Shoot()
        {
            var shot = Object.Instantiate(_ammo.gameObject, _player.position, _player.rotation);
            var rb = shot.GetComponent<Rigidbody2D>();
            var vector = _player.localRotation.eulerAngles.normalized;
            rb.AddForce(vector * _speedRate);
            _counterTimerDelete = CoroutinesController.StartRoutine(TimerDelete(_bulletRemovalTimer,shot));
        }

        IEnumerator TimerDelete(float timeInSec, GameObject shot)
        {
            yield return new WaitForSeconds(timeInSec);
            Object.Destroy(shot);
            CoroutinesController.StopRoutine(_counterTimerDelete);
        }

	}
}