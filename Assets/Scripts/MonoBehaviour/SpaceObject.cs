using System;
using System.Collections.Generic;
using UnityEngine;


namespace AsteroidS
{
    public sealed class SpaceObject : MonoBehaviour, ISoundSource
    {
        private const string PropertiesPath = "SpaceObjectsProperties/";

        [SerializeField] private string _spaceObjectPropertiesPath;
        [SerializeField] private List<SoundSource> _soundSources;
        private SpaceObjectProperties _spaceObjectProperties;
        private SpriteRenderer _spriteRenderer;
        private int _hitPoints;
        private int _armorPoints;
        [HideInInspector] public float lifeTimeCounter = 0;

        public List<SoundSource> SoundSources => _soundSources;
        public Sprite[] GetSprites => Properties.SpaceObjectSprites;
        public int HitPoints => _hitPoints;
        public int ArmorPoints => _armorPoints;
        

        public SpaceObjectProperties Properties
        {
            get
            {
                if (_spaceObjectProperties == null)
                {
                    _spaceObjectProperties =
                        Resources.Load<SpaceObjectProperties>(PropertiesPath + _spaceObjectPropertiesPath);
                }

                return _spaceObjectProperties;
            }
        }

        public Action<SpaceObject> OnSpaceObjectHit;
        public Action<SpaceObject> OnLifeTimeTermination;
        public Action OnPlayerHit;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _hitPoints = Properties.hitPoints;
            _armorPoints = Properties.armorPoints;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Ammo>())
            {
                var ammo = collision.gameObject;
                var damage = ammo.GetComponent<Ammo>().Properties.Damage;

                if (_armorPoints > 0) _armorPoints -= damage;
                else _hitPoints -= damage;

                OnSpaceObjectHit?.Invoke(this);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals(TagOrName.Player))
            {
                OnPlayerHit?.Invoke();
            }
        }

        private void Update()
        {
            Live();
        }

        private void OnDisable()
        {
            lifeTimeCounter = 0;
        }

        private void Live()
        {
            lifeTimeCounter += Time.deltaTime;

            if (lifeTimeCounter >= _spaceObjectProperties.maxLifeTime && !_spriteRenderer.isVisible)
            {
                lifeTimeCounter = 0;
                OnLifeTimeTermination?.Invoke(this);
            }
        }

        public SoundSource GetSoundSourceTypeOf(SoundType type)
        {
            return _soundSources.Find(ss => ss.type.Equals(type));
        }
    }
}