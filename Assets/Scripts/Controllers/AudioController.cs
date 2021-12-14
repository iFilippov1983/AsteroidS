using UnityEngine;
using UnityEngine.Audio;

namespace AsteroidS
{
    public class AudioController : IInitialization, ICleanup
    {
        private AudioMixer _audioMixer;
        private AudioClip _backgroundMusicClip;
        private AudioClip _shotWeaponSourse;
        private SettingsMenuController _settingsMenuController;
        private AudioSourceHandler _audioSourceHandler;
        private ShootingController _shootingController;
        private readonly string _exposedAudioParameter;

        public AudioController(GameData gameData, MenuManagmentController menuManagmentController, ShootingController shootingController)
        {
            _audioSourceHandler = new AudioSourceHandler(gameData.SoundData.AudioMixerGroup);
            _audioMixer = gameData.SoundData.AudioMixer;
            _settingsMenuController = menuManagmentController.SettingsMenuController;
            _shootingController = shootingController;
            _backgroundMusicClip = gameData.SoundData.BackgroundMusicClip;
            _shotWeaponSourse = gameData.SoundData.ShotWeaponClip;
            _exposedAudioParameter = gameData.SoundData.ExposedAudioParameter;
        } 

        public void Initialize()
        {
            _audioSourceHandler.SetAudioSourses();
            _settingsMenuController.OnSoundVolumeChangebackground += AudioBackgroundVolume;
            _settingsMenuController.OnSoundVolume += AudioGroupVolume;
            _shootingController.OnShot += AudioShotWeaponSourse;
            _audioSourceHandler.BackgroundMusicSource.clip = _backgroundMusicClip;
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

        public void AudioGroupVolume(float volume)
        {
            
            _audioMixer.SetFloat(_exposedAudioParameter, volume);
        }

        public void Cleanup()
        {
            _settingsMenuController.OnSoundVolumeChangebackground -= AudioBackgroundVolume;
            _settingsMenuController.OnSoundVolume -= AudioGroupVolume;
            _shootingController.OnShot -= AudioShotWeaponSourse;
        }
    }
}
