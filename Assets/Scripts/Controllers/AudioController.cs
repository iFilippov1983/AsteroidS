using UnityEngine;

namespace AsteroidS
{
    public class AudioController : IInitialization, ICleanup
    {
        private AudioClip _backgroundMusicClip;
        private AudioClip _shotWeaponSourse;
        private SettingsMenuController _settingsMenuController;
        private AudioSourceHandler _audioSourceHandler;
        private ShootingController _shootingController;

        public AudioController(GameData gameData, MenuManagmentController menuManagmentController, ShootingController shootingController)
        {
            _audioSourceHandler = new AudioSourceHandler();
            _settingsMenuController = menuManagmentController.SettingsMenuController;
            _shootingController = shootingController;
            _backgroundMusicClip = gameData.SoundData.BackgroundMusicClip;
            _shotWeaponSourse = gameData.SoundData.ShotWeaponClip;

        } 

        public void Initialize()
        {
            _audioSourceHandler.SetAudioSourses();
            _settingsMenuController.OnSoundVolumeChangebackground += AudioBackgroundVolume;
            _settingsMenuController.OnSoundVolume += AudioSourceVolume;
            _shootingController.OnShot += AudioShotWeaponSourse;
            _audioSourceHandler.backgroundMusicSourse.clip = _backgroundMusicClip;
            _audioSourceHandler.PlayBackgroundMusic();
        }

        public void AudioBackgroundVolume(float volume)
        {
            _audioSourceHandler.SetBackgroundMusicVolume(volume);
        }

        public void AudioShotWeaponSourse()
        {
            _audioSourceHandler.PlayOneShotShotWeaponSourse(_shotWeaponSourse);
        }

        public void AudioSourceVolume(float volume)
        {
            _audioSourceHandler.SetSourseVolume(volume);
        }

        public void Cleanup()
        {
            _settingsMenuController.OnSoundVolumeChangebackground -= AudioBackgroundVolume;
            _settingsMenuController.OnSoundVolume -= AudioSourceVolume;
            _shootingController.OnShot -= AudioShotWeaponSourse;
        }
    }
}
