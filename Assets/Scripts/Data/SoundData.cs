using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(menuName = "GameData/SoundData", fileName = "SoundData")]
    public class SoundData : ScriptableObject
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private AudioMixerGroup _effectsMixerGroup;
        [SerializeField] private AudioClip _backgroundMusicClip;
        [SerializeField] private AudioClip _shotWeaponClip;
        [SerializeField] private AudioClip _armorHitsClip;
        [SerializeField] private AudioClip _asteroidExplosionClip;
        [SerializeField] private AudioClip _shipExplosionClip;
        [SerializeField] private AudioClip _asteroidHitsClip;
        [SerializeField] private AudioClip _buttonClip;
        [SerializeField] private string _exposedAudioParameter;

        public AudioMixer AudioMixer => _audioMixer;
        public AudioMixerGroup AudioMixerGroup => _audioMixerGroup;
        public AudioMixerGroup EffectsMixerGroup => _effectsMixerGroup;
        public AudioClip BackgroundMusicClip => _backgroundMusicClip;
        public AudioClip ShotWeaponClip => _shotWeaponClip;
        public AudioClip ArmorHitsClip => _armorHitsClip;
        public AudioClip AsteroidExplosionClip => _asteroidExplosionClip;
        public AudioClip ShipExplosionClip => _shipExplosionClip;
        public AudioClip AsteroidHitsClip => _asteroidHitsClip;
        public AudioClip ButtonClip => _buttonClip;
        public string ExposedAudioParameter => _exposedAudioParameter;
    }
}
