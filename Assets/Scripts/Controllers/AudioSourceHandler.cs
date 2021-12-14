using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AsteroidS
{
    public class AudioSourceHandler
    {
        private GameObject _parent;
        public AudioSource backgroundMusicSourse;
        public AudioSource shotWeaponSourse;
        public AudioSource armorHitsSourse;
        public AudioSource asteroidExplosionSourse;
        public AudioSource shipExplosionSourse;
        public AudioSource asteroidHitsSourse;

        public AudioSourceHandler()
        {
            _parent = new GameObject("AudioSourceHandler");
        }

        public void SetAudioSourses()
        {
            backgroundMusicSourse = _parent.AddComponent<AudioSource>();
            shotWeaponSourse = _parent.AddComponent<AudioSource>();
            armorHitsSourse = _parent.AddComponent<AudioSource>();
            asteroidExplosionSourse = _parent.AddComponent<AudioSource>();
            shipExplosionSourse = _parent.AddComponent<AudioSource>();
            asteroidHitsSourse = _parent.AddComponent<AudioSource>();
        }

        public void PlayBackgroundMusic()
        {
            backgroundMusicSourse.Play();
            backgroundMusicSourse.volume = 0.2f; // временно
        }

        public void SetBackgroundMusicVolume(float volume)
        {
            backgroundMusicSourse.volume = volume;
        }

        public void PlayOneShotShotWeaponSourse(AudioClip audioClip)
        {
            shotWeaponSourse.PlayOneShot(audioClip);
        }

        public void PlayOneArmorHitsSourse(AudioClip audioClip)
        {
            armorHitsSourse.PlayOneShot(audioClip);
        }

        public void PlayOneAsteroidExplosionSourse(AudioClip audioClip)
        {
            asteroidExplosionSourse.PlayOneShot(audioClip);
        }

        public void PlayOneShipExplosionSourse(AudioClip audioClip)
        {
            shipExplosionSourse.PlayOneShot(audioClip);
        }

        public void PlayOneAsteroidHitsSourse(AudioClip audioClip)
        {
            asteroidHitsSourse.PlayOneShot(audioClip);
        }

        public void SetSourseVolume(float volume)
        {
            shotWeaponSourse.volume = volume;
            armorHitsSourse.volume = volume;
            asteroidExplosionSourse.volume = volume;
            shipExplosionSourse.volume = volume;
        }
    }
}
