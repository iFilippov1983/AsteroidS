using Assets.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AsteroidS
{
    internal class ShootingController : IInitialization, IExecute, ICleanup
    {
        private GameData _gameData;
        private Transform _player;
        private AmmoSpawner _spawner;
        private AmmoDriver _ammoDriver;
        private Dictionary<AmmoType, Stack<Ammo>> _ammoPool;

        private float _reloadTime;
        private float _reloadTimeCounter;
        private float _shotDistance;
        private Ammo _ammo;
        private AmmoType _currentAmmoType;
        private bool _ammoRloaded = true;

        //private Coroutine _coroutineTimer;
        //private Coroutine _counterTimerDelete;


        internal ShootingController(GameData gameData, Transform player)
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
            SubscribeToEvents(_ammoPool);
        }

        public void Execute(float deltaTime)
        {
            _reloadTimeCounter += deltaTime;
            if (_reloadTimeCounter > _reloadTime)
            {
                _reloadTimeCounter = 0;
                _ammoRloaded = true;
            } 

            int mask = LayerMask.GetMask(MasksHolder.SpaceObject);
            var hit = Physics2D.Raycast(_player.position, _player.up, _shotDistance, mask);
            //temp
            Debug.DrawRay(_player.position, _player.up * _shotDistance, Color.red);

            bool notEmpty = (_ammoPool[_currentAmmoType].Count != 0);

            if (hit && _ammoRloaded && notEmpty)
            {
                _ammoRloaded = false;

                Shoot(_player);

                //_coroutineTimer = CoroutinesController.StartRoutine(Timer(_rateOfFire));
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
            var shot = Object.Instantiate(ammo, transform.position, transform.rotation);
            //var shotVector = _player.rotation * _player.position;
            _ammoDriver.Drive(shot, _player.up);

            //var shot = Object.Instantiate(_ammo.gameObject, _player.position, _player.rotation);
            //_counterTimerDelete = CoroutinesController.StartRoutine(TimerDelete(_bulletRemovalTimer, shot));
        }

        private void SubscribeToEvents(Dictionary<AmmoType, Stack<Ammo>> keyValuePair)
        {
            for (int index = 1; index <= _ammoPool.Count; index++)
            {
                var type = (AmmoType)index;
                var stack = _ammoPool[type];

                foreach (Ammo a in stack)
                {
                    a.LifeTerminationEvent += OnLifeTermination;
                }
            }
        }

        private void UnsubscribeFromEvents(Dictionary<AmmoType, Stack<Ammo>> keyValuePair)
        {
            for (int index = 1; index <= _ammoPool.Count; index++)
            {
                var type = (AmmoType)index;
                var stack = _ammoPool[type];

                foreach (Ammo a in stack)
                {
                    a.LifeTerminationEvent -= OnLifeTermination;
                }
            }
        }

        //IEnumerator Timer(float timeInSec)
        //{
        //    yield return new WaitForSeconds(timeInSec);
        //    _ammoRloaded = true;
        //    CoroutinesController.StopRoutine(_coroutineTimer);
        //}

        //IEnumerator TimerDelete(float timeInSec, GameObject shot)
        //{
        //    yield return new WaitForSeconds(timeInSec);
        //    Object.Destroy(shot);
        //    CoroutinesController.StopRoutine(_counterTimerDelete);
        //}
    }
}