using System;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    public sealed class Ammo : MonoBehaviour, ISoundSource
    {
        private const string AmmoPropertiesPath = "AmmoProperties/";

        [SerializeField] private string _ammoPropertiesPath;
        [SerializeField] private List<SoundSource> _soundSources;

        private AmmoProperties _ammoProperties;
        private float _lifeTimeCounter;
        private SpriteRenderer _renderer;
        //private Coroutine _desactivationTimer;

        public AmmoProperties Properties
        {
            get 
            {
                if (_ammoProperties == null)
                {
                    _ammoProperties = Resources.Load<AmmoProperties>(AmmoPropertiesPath + _ammoPropertiesPath);
                }

                return _ammoProperties;
            }
        }

        public Action<Ammo> LifeTerminationEvent;

        private void Awake()
        {
            _renderer = GetComponentInChildren<SpriteRenderer>();
            _renderer.sprite = Properties.AmmoSprite;
        }

        private void OnEnable()
        {
            _lifeTimeCounter = 0;
            //_desactivationTimer = CoroutinesController.StartRoutine(LifeTimer(Properties.LifeTime));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //temp
            if (Properties.AmmoType.Equals(AmmoType.Laser)) return;

            if (collision.gameObject.GetComponent<SpaceObject>())
            {
                LifeTerminationEvent?.Invoke(this);
            }
        }

        private void Update()
        {
            _lifeTimeCounter += Time.deltaTime;
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
            if (_lifeTimeCounter >= _ammoProperties.LifeTime || _renderer.isVisible != true)
            {
                _lifeTimeCounter = 0;
                LifeTerminationEvent?.Invoke(this);
            }
        }

        public SoundSource GetSoundSourceTypeOf(SoundType type)
        {
            return _soundSources.Find(ss => ss.type.Equals(type)); ;
        }

        //IEnumerator LifeTimer(float timeInSec)
        //{
        //    LifeTerminationEvent?.Invoke(this);
        //    yield return new WaitForSeconds(timeInSec);
        //    CoroutinesController.StopRoutine(_desactivationTimer);
        //}
    }
}

