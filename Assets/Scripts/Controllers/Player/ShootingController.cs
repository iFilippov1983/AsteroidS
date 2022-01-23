using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtilities;
using Object = UnityEngine.Object;

namespace AsteroidS
{
    public sealed class ShootingController : IInitialization, IFixedExecute, ILateExecute, ICleanup
    {
        private PlayerData _playerData;
        private Transform _playerGun;
        private Transform _player;
        private AmmoSpawner _spawner;
        private AmmoDriver _ammoDriver;
        private Dictionary<AmmoType, Stack<Ammo>> _ammoPool;
        private FieldOfViewHandler _fovHandler;
        private MeshFilter _fovMeshFilter;

        private float _reloadTime;
        private float _shotDistance;
        private Ammo _ammo;
        private AmmoType _currentAmmoType;
        private bool _ammoReloaded = true;
        private Coroutine _coroutineTimer;

        private bool _stackNotEmpty;

        public event Action OnShot;

        public ShootingController(GameData gameData, Transform player)
        {
            _player = player;
            _playerData = gameData.PlayerData;
            

            _spawner = new AmmoSpawner(_playerData.AmmoPrefabsDictionary);
            _ammoDriver = new AmmoDriver();
        }

        public void Initialize()
        {
            _reloadTime = _playerData.CurrentAmmo.Properties.ReloadTime;
            _shotDistance = _playerData.CurrentAmmo.Properties.ShotDistance;
            _ammo = _playerData.CurrentAmmo;
            _currentAmmoType = _ammo.Properties.AmmoType;
            _ammoPool = _spawner.MakeSpawnedAmmoDictionary();
            _stackNotEmpty = (_ammoPool[_currentAmmoType].Count != 0);
            _playerGun = _player.Find(TagOrName.Gun);
            _fovMeshFilter = _playerGun.Find(TagOrName.FoV).GetComponent<MeshFilter>();
            _fovHandler = new FieldOfViewHandler(_fovMeshFilter, _shotDistance, _ammo.Properties.FieldOfView);

            SubscribeToEvents(_ammoPool);

            _playerData.OnAmmoSwitched += SwitchAmmo;
        }

        //temp
        public void FixedExecute()
        {
            //temp
            Debug.DrawRay(_playerGun.position, _playerGun.up * _shotDistance, Color.red);
        }

        public void Execute()
        {
            Vector3 position = Utilities.GetMouseWorldPosition();
            Vector3 aimDir = (position - _player.position).normalized;

            _fovHandler.SetAimDerection(aimDir);
            _fovHandler.SetOrigin(_playerGun.position);
        }

        public void LateExecute()
        {
            _fovHandler.LateExecute();
        }

        public void Cleanup()
        {
            var liveAmmo = Object.FindObjectsOfType(typeof(Ammo));
            foreach (Ammo ammo in liveAmmo)
            {
                ammo.LifeTerminationEvent -= OnLifeTermination;
            }

            UnsubscribeFromEvents(_ammoPool);

            _playerData.OnAmmoSwitched -= SwitchAmmo;
        }

        public void HandlePrimaryShooting(float value)
        {
            if (value <= 0) return;
            if (_ammoReloaded && _stackNotEmpty)
            {
                _ammoReloaded = false;

                ShootPrimary(_playerGun);
                OnShot?.Invoke();
                _coroutineTimer = CoroutinesController.StartRoutine(FireRateTimer(_reloadTime));
            }
        }

        private void OnLifeTermination(Ammo ammo)
        {
            var type = ammo.Properties.AmmoType;

            _ammoDriver.Stop(ammo);
            _ammoPool[type].Push(ammo);
        }

        private void ShootPrimary(Transform transform)
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

        private void SwitchAmmo()
        {
            _ammo = _playerData.CurrentAmmo;
            _currentAmmoType = _ammo.Properties.AmmoType;
            _fovHandler.ReInitialize(_fovMeshFilter, _ammo.Properties.ShotDistance, _ammo.Properties.FieldOfView);
        }

        IEnumerator FireRateTimer(float timeInSec)
        {
            yield return new WaitForSeconds(timeInSec);
            _ammoReloaded = true;
            CoroutinesController.StopRoutine(_coroutineTimer);
        }
    }
}