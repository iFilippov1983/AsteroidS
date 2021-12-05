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
        private Transform _player;
        private float _shotDistance = 50f;
        private float _rateOfFire = 3;
        private float _bulletRemovalTimer = 0.5f;
        private float _speedRate=1;
        private Ammo _ammo;
        private Vector3 _shotOffset;
        private bool _shootingTimer = true;
        private Coroutine _coroutineTimer;
        private Coroutine _counterTimerDelet;


        internal ShootingController(GameData gameData, Transform player)
        {
            _player = player;
            //_rateOfFire = gameData.PlayerData.currentAmmo.Properties.fireRate;
            //_shotDistance = gameData.PlayerData.currentAmmo.Properties.shotDistance;
            //_speedRate = gameData.PlayerData.currentAmmo.Properties.speedRate;
            _ammo = gameData.PlayerData.currentAmmo;
            _shotOffset = gameData.PlayerData.ShotOffset;
        }

        public void Initialize()
        {

        }

		public void Execute(float deltaTime)
		{
			int layerMask = LayerMask.GetMask("SpaceObject");
            var hit = Physics2D.Raycast(_player.position, _player.eulerAngles, _shotDistance, layerMask);
            Debug.DrawRay(_player.position, _player.eulerAngles, Color.red);
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
            _counterTimerDelet = CoroutinesController.StartRoutine(TimerDelet(_bulletRemovalTimer,shot));
        }

        IEnumerator TimerDelet(float timeInSec, GameObject shot)
        {
            yield return new WaitForSeconds(timeInSec);
            Object.Destroy(shot);
            CoroutinesController.StopRoutine(_counterTimerDelet);
        }

	}
}