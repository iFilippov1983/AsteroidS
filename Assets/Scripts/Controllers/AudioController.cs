using UnityEngine;

namespace AsteroidS
{
    public class AudioController : IInitialization, ICleanup
    {
        private AudioClip _backgroundMusicClip;
        private AudioClip _shotWeaponClip;
        private AudioClip _armorHitsClip;
        private AudioClip _asteroidExplosionClip;
        private AudioClip _shipExplosionClip;
        private AudioClip _asteroidHitsClip;
        private MenuController _menuController;
        private AudioSourceHandler _audioSourceHandler;
        private ShootingController _shootingController;
        private SpaceObjectsController _spaceObjectsController;

        public AudioController(GameData gameData, MenuController settingsMenuController, ShootingController shootingController, SpaceObjectsController spaceObjectsController)
        {
            _audioSourceHandler = new AudioSourceHandler();
            _menuController = settingsMenuController;
            _shootingController = shootingController;
            _spaceObjectsController = spaceObjectsController;
            _backgroundMusicClip = gameData.SoundData.BackgroundMusicClip;
            _shotWeaponClip = gameData.SoundData.ShotWeaponClip;
            _armorHitsClip = gameData.SoundData.ArmorHitsClip;
            _asteroidExplosionClip = gameData.SoundData.AsteroidExplosionClip;
            _shipExplosionClip = gameData.SoundData.ShipExplosionClip;
            _asteroidHitsClip = gameData.SoundData.AsteroidHitsClip;
        } 

        public void Initialize()
        {
            _audioSourceHandler.SetAudioSourses();
            _menuController.OnSoundVolumeChangebackground += AudioBackgroundVolume;
            _menuController.OnSoundVolume += AudioSourceVolume;
            _shootingController.OnShot += AudioShotWeaponSourse;
            _spaceObjectsController.OnObjectDestroy += AudioShotDestroy;
            _spaceObjectsController.OnObjectHitEvent += AudioShotHitsSourse;
            _audioSourceHandler.backgroundMusicSourse.clip = _backgroundMusicClip;
            _audioSourceHandler.PlayBackgroundMusic();


        }

        public void AudioBackgroundVolume(float volume)
        {
            _audioSourceHandler.SetBackgroundMusicVolume(volume);
        }

        public void AudioShotWeaponSourse()
        {
            _audioSourceHandler.PlayOneShotShotWeaponSourse(_shotWeaponClip);
        }

        public void AudioSourceVolume(float volume)
        {
            _audioSourceHandler.SetSourseVolume(volume);
        }
        public void AudioShotHitsSourse(string tag)
        {
            if(tag == TagsHolder.Ship)
            {
                _audioSourceHandler.PlayOneArmorHitsSourse(_armorHitsClip);
            }
            else
            {
                _audioSourceHandler.PlayOneAsteroidHitsSourse(_asteroidHitsClip);
            }
        }
        public void AudioShotDestroy(string tag)
        {
            if (tag == TagsHolder.Ship)
            {
                _audioSourceHandler.PlayOneShipExplosionSourse(_shipExplosionClip);
            }
            else
            {
                _audioSourceHandler.PlayOneAsteroidExplosionSourse(_asteroidExplosionClip);
            }
        }

        public void Cleanup()
        {
            _menuController.OnSoundVolumeChangebackground -= AudioBackgroundVolume;
            _menuController.OnSoundVolume -= AudioSourceVolume;
            _shootingController.OnShot -= AudioShotWeaponSourse;
            _spaceObjectsController.OnObjectDestroy -= AudioShotDestroy;
            _spaceObjectsController.OnObjectHitEvent -= AudioShotHitsSourse;
        }
    }
}
