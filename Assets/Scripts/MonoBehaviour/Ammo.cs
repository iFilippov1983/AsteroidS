using System;
using UnityEngine;

namespace AsteroidS
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private string _ammoPropertiesPath;
        
        private AmmoProperties _ammoProperties;
        private float _lifeTimeCounter;
        //private Coroutine _desactivationTimer;

        public AmmoProperties Properties
        {
            get 
            {
                if (_ammoProperties == null)
                {
                    _ammoProperties = Resources.Load<AmmoProperties>("GameData/" + _ammoPropertiesPath);
                }

                return _ammoProperties;
            }
        }

        public Action<Ammo> LifeTerminationEvent;

        private void OnEnable()
        {
            _lifeTimeCounter = 0;
            //_desactivationTimer = CoroutinesController.StartRoutine(LifeTimer(Properties.LifeTime));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //temp 
            Debug.Log($"Ammo hits object: {collision.gameObject.name}");

            if (collision.gameObject.tag == TagsHolder.SpaceObject)
            {
                LifeTerminationEvent?.Invoke(this);
            }
        }

        private void FixedUpdate()
        {
            Live();
        }

        private void OnDisable()
        {
            //CoroutinesController.StopRoutine(_desactivationTimer);
        }

        private void Live()
        {
            _lifeTimeCounter += Time.deltaTime;

            if (_lifeTimeCounter > _ammoProperties.LifeTime)
            {
                _lifeTimeCounter = 0;
                LifeTerminationEvent?.Invoke(this);
            }
        }

        //IEnumerator LifeTimer(float timeInSec)
        //{
        //    LifeTerminationEvent?.Invoke(this);
        //    yield return new WaitForSeconds(timeInSec);
        //    CoroutinesController.StopRoutine(_desactivationTimer);
        //}
    }
}

