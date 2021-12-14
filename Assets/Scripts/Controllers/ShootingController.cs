﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AsteroidS
{
    public class ShootingController : IInitialization, IFixedExecute, ICleanup
    {
        private GameData _gameData;
        private Transform _player;
        private AmmoSpawner _spawner;
        private AmmoDriver _ammoDriver;
        private Dictionary<AmmoType, Stack<Ammo>> _ammoPool;

        private float _reloadTime;
        private float _shotDistance;
        private Ammo _ammo;
        private AmmoType _currentAmmoType;
        private bool _ammoReloaded = true;
        private Coroutine _coroutineTimer;

        private LayerMask _mask;
        private bool _stackNotEmpty;

        public event Action OnShot;


        public ShootingController(GameData gameData, Transform player)
        {
            _gameData = gameData;
            _player = player;
            _spawner = new AmmoSpawner(gameData.PlayerData.AmmoPrefabsDictionary);
            _ammoDriver = new AmmoDriver();
        }

        public void Initialize()
        {
            _reloadTime = _gameData.PlayerData.currentAmmo.Properties.reloadTime;
            _shotDistance = _gameData.PlayerData.currentAmmo.Properties.shotDistance;
            _ammo = _gameData.PlayerData.currentAmmo;
            _currentAmmoType = _ammo.Properties.ammoType;
            _ammoPool = _spawner.MakeSpawnedAmmoDictionary();

            _mask = LayerMask.GetMask(MasksHolder.SpaceObject);
            _stackNotEmpty = (_ammoPool[_currentAmmoType].Count != 0);

            SubscribeToEvents(_ammoPool);
            
        }

        public void FixedExecute()
        {

            var hit = Physics2D.Raycast(_player.position, _player.up, _shotDistance, _mask);

            //temp
            Debug.DrawRay(_player.position, _player.up * _shotDistance, Color.red);

            if (hit && _ammoReloaded && _stackNotEmpty)
            {
                _ammoReloaded = false;

                Shoot(_player);
                OnShot?.Invoke();
                _coroutineTimer = CoroutinesController.StartRoutine(FireRateTimer(_reloadTime));
            }
        }

        public void Cleanup()
        {
            var liveAmmo = Object.FindObjectsOfType(typeof(Ammo));
            foreach (Ammo ammo in liveAmmo)
            {
                ammo.LifeTerminationEvent -= OnLifeTermination;
            }

            UnsubscribeFromEvents(_ammoPool);
            
        }

        private void OnLifeTermination(Ammo ammo)
        {
            var type = ammo.Properties.ammoType;

            _ammoDriver.Stop(ammo);
            _ammoPool[type].Push(ammo);

        }

        private void Shoot(Transform transform)
        {
            var ammo = _ammoPool[_currentAmmoType].Pop();
            _ammoDriver.Drive(ammo, transform);
        }

        private void SubscribeToEvents(Dictionary<AmmoType, Stack<Ammo>> keyValuePair)
        {
            for (int index = 1; index <= keyValuePair.Count; index++)
            {
                var type = (AmmoType)index;
                var stack = keyValuePair[type];

                foreach (Ammo a in stack)
                {
                    a.LifeTerminationEvent += OnLifeTermination;
                }
            }
        }

        private void UnsubscribeFromEvents(Dictionary<AmmoType, Stack<Ammo>> keyValuePair)
        {
            for (int index = 1; index <= keyValuePair.Count; index++)
            {
                var type = (AmmoType)index;
                var stack = keyValuePair[type];

                foreach (Ammo a in stack)
                {
                    a.LifeTerminationEvent -= OnLifeTermination;
                }
            }
        }

        IEnumerator FireRateTimer(float timeInSec)
        {
            yield return new WaitForSeconds(timeInSec);
            _ammoReloaded = true;
            CoroutinesController.StopRoutine(_coroutineTimer);
        }
    }
}