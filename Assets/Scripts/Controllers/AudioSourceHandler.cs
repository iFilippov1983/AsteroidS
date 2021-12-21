using UnityEngine;
using UnityEngine.Audio;

namespace AsteroidS
{
    public class AudioSourceHandler
    {
        private const string ParentName = "AudioSourceHandler";
        
        private AudioSource _backgroundMusicSource;
        private AudioSource _shotWeaponSource;
        private AudioSource _armorHitsSource;
        private AudioSource _asteroidExplosionSource;
        private AudioSource _shipExplosionSource;
        private AudioSource _asteroidHitsSource;
        
        private AudioClip _backgroundMusicClip;
        private AudioClip _shotWeaponSourceClip;
        private AudioClip _armorHitSourceClip;
        private AudioClip _asteroidExplosionClip;
        private AudioClip _shipExplosionClip;
        private AudioClip _asteroidHitClip;
        
        private AudioMixerGroup _audioMainMixerGroup;
        private AudioMixerGroup _audioMixerGroupEffects;
        private GameObject _parent;

        public AudioSourceHandler(GameData gameData)
        {
            _audioMainMixerGroup = gameData.SoundData.AudioMixerGroup;
            _parent = new GameObject(ParentName);
            _backgroundMusicClip = gameData.SoundData.BackgroundMusicClip;
            _shotWeaponSourceClip = gameData.SoundData.ShotWeaponClip;
            _armorHitSourceClip = gameData.SoundData.ArmorHitsClip;
            _asteroidExplosionClip = gameData.SoundData.AsteroidExplosionClip;
            _shipExplosionClip = gameData.SoundData.ShipExplosionClip;
            _asteroidHitClip = gameData.SoundData.AsteroidHitsClip;
            _audioMixerGroupEffects = gameData.SoundData.EffectsMixerGroup;
        }

        public void SetAudioSources()
        {
            _backgroundMusicSource = SetParentAndMixerGroup(_audioMainMixerGroup);
            _shotWeaponSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
            _armorHitsSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
            _asteroidExplosionSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
            _shipExplosionSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
            _asteroidHitsSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
        }

        public void PlayBackgroundMusic()
        {
            _backgroundMusicSource.Play();
        }

        public void SetAudioClips()
        {
            _backgroundMusicSource.clip = _backgroundMusicClip;
            _shotWeaponSource.clip = _shotWeaponSourceClip;
        }

        public void PlayOneShotShotWeaponSource()
        {
            _shotWeaponSource.PlayOneShot(_shotWeaponSourceClip);
        }

        public void PlayOneArmorHitsSource()
        {
            _armorHitsSource.PlayOneShot(_armorHitSourceClip);
        }

        public void PlayOneAsteroidExplosionSource()
        {
            _asteroidExplosionSource.PlayOneShot(_asteroidExplosionClip);
        }

        public void PlayOneShipExplosionSource()
        {
            _shipExplosionSource.PlayOneShot(_shipExplosionClip);
        }

        public void PlayOneAsteroidHitsSource()
        {
            _asteroidHitsSource.PlayOneShot(_asteroidHitClip);
        }

        private AudioSource SetParentAndMixerGroup( AudioMixerGroup audioMixerGroup)
        {
            var audioSource = _parent.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = audioMixerGroup;
            return audioSource;
        }
    }
}
