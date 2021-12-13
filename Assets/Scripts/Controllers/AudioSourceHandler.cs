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
        private GameObject parent;
        public AudioSource backgroundMusicSourse;
        public AudioSource shotWeaponSourse;

        public AudioSourceHandler()
        {
            parent = new GameObject("AudioSourceHandler");
        }

        public void SetAudioSourses()
        {
            backgroundMusicSourse = parent.AddComponent<AudioSource>();
            shotWeaponSourse = parent.AddComponent<AudioSource>();
        }

        public void PlayBackgroundMusic()
        {
            backgroundMusicSourse.Play();
        }

        public void SetBackgroundMusicVolume(float volume)
        {
            backgroundMusicSourse.volume = volume;
        }

        public void PlayOneShotShotWeaponSourse(AudioClip audioClip)
        {
            shotWeaponSourse.PlayOneShot(audioClip);
        }

        public void SetSourseVolume(float volume)
        {
            shotWeaponSourse.volume = volume;
        }
    }
}
