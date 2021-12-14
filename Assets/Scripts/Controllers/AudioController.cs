using UnityEngine;
using UnityEngine.Audio;

namespace AsteroidS
{
    public class AudioController : IInitialization, ICleanup
    {
        private readonly SettingsMenuController _settingsMenuController;
        private readonly ShootingController _shootingController;
        private readonly string _exposedAudioParameter;
        private readonly AudioMixer _audioMixer;
        private readonly AudioSourceHandler _audioSourceHandler;

        public AudioController(GameData gameData, MenuManagmentController menuManagementsController, ShootingController shootingController)
        {
            _audioSourceHandler = new AudioSourceHandler(gameData);
            _audioMixer = gameData.SoundData.AudioMixer;
            _settingsMenuController = menuManagementsController.SettingsMenuController;
            _shootingController = shootingController;
            _exposedAudioParameter = gameData.SoundData.ExposedAudioParameter;
        } 

        public void Initialize()
        {
            _audioSourceHandler.SetAudioSources();
            _audioSourceHandler.SetAudioClips();
            _audioSourceHandler.PlayBackgroundMusic();

            _settingsMenuController.OnSoundVolume += AudioGroupVolume;
            _shootingController.OnShot += AudioShotWeaponSource;
        }
        
        private void AudioShotWeaponSource()
        {
            _audioSourceHandler.PlayOneShotShotWeaponSource();
        }

        private void AudioGroupVolume(float volume)
        {
            _audioMixer.SetFloat(_exposedAudioParameter, volume);
        }

        public void Cleanup()
        {
            _settingsMenuController.OnSoundVolume -= AudioGroupVolume;
            _shootingController.OnShot -= AudioShotWeaponSource;
        }
    }
}
