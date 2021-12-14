using UnityEngine;
using UnityEngine.Audio;

namespace AsteroidS
{
    public class AudioSourceHandler
    {
        public AudioSource BackgroundMusicSource;
        public AudioSource ShotWeaponSource;
        public AudioSource ArmorHitsSource;
        public AudioSource AsteroidExplosionSource;
        public AudioSource ShipExplosionSource;
        public AudioSource AsteroidHitsSource;

        private AudioMixerGroup _audioMixerGroup;
        private GameObject _parent;

        public AudioSourceHandler(AudioMixerGroup audioMixerGroup)
        {
            _audioMixerGroup = audioMixerGroup;
            _parent = new GameObject("AudioSourceHandler");
        }

        public void SetAudioSourses()
        {
            BackgroundMusicSource = SetParentAndMixerGroop();
            ShotWeaponSource = SetParentAndMixerGroop();
            ArmorHitsSource = SetParentAndMixerGroop();
            AsteroidExplosionSource = SetParentAndMixerGroop();
            ShipExplosionSource = SetParentAndMixerGroop();
            AsteroidHitsSource = SetParentAndMixerGroop();
        }

        public void PlayBackgroundMusic()
        {
            BackgroundMusicSource.Play();
            BackgroundMusicSource.volume = 0.2f; // временно
        }

        public void SetBackgroundMusicVolume(float volume)
        {
            BackgroundMusicSource.volume = volume;
        }

        public void PlayOneShotShotWeaponSourse(AudioClip audioClip)
        {
            ShotWeaponSource.PlayOneShot(audioClip);
        }

        public void PlayOneArmorHitsSourse(AudioClip audioClip)
        {
            ArmorHitsSource.PlayOneShot(audioClip);
        }

        public void PlayOneAsteroidExplosionSourse(AudioClip audioClip)
        {
            AsteroidExplosionSource.PlayOneShot(audioClip);
        }

        public void PlayOneShipExplosionSourse(AudioClip audioClip)
        {
            ShipExplosionSource.PlayOneShot(audioClip);
        }

        public void PlayOneAsteroidHitsSourse(AudioClip audioClip)
        {
            AsteroidHitsSource.PlayOneShot(audioClip);
        }

        public void SetSourseVolume(float volume)
        {
            ShotWeaponSource.volume = volume;
            ArmorHitsSource.volume = volume;
            AsteroidExplosionSource.volume = volume;
            ShipExplosionSource.volume = volume;
        }

        private AudioSource SetParentAndMixerGroop()
        {
            var AudioSource = _parent.AddComponent<AudioSource>();
            AudioSource.outputAudioMixerGroup = _audioMixerGroup;
            return AudioSource;
        }
    }
}
