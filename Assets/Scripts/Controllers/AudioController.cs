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
        private SpaceObjectsController _spaceObjectsController;

        public AudioController(GameData gameData, MenuManagmentController menuManagementsController, ShootingController shootingController, SpaceObjectsController spaceObjectsController)
        {
            _audioSourceHandler = new AudioSourceHandler(gameData);
            _audioMixer = gameData.SoundData.AudioMixer;
            _settingsMenuController = menuManagementsController.SettingsMenuController;
            _shootingController = shootingController;
            _exposedAudioParameter = gameData.SoundData.ExposedAudioParameter;
            _spaceObjectsController = spaceObjectsController;
        } 

        public void Initialize()
        {
            _audioSourceHandler.SetAudioSources();
            _audioSourceHandler.SetAudioClips();
            _audioSourceHandler.PlayBackgroundMusic();
            _settingsMenuController.OnSoundVolume += AudioGroupVolume;
            _shootingController.OnShot += AudioShotWeaponSource;
            _spaceObjectsController.OnObjectDestroy += AudioShotDestroy;
            _spaceObjectsController.OnObjectHitEvent += AudioShotHitsSourse;
        }
        
        private void AudioShotWeaponSource()
        {
            _audioSourceHandler.PlayOneShotShotWeaponSource();
        }

        private void AudioGroupVolume(float volume)
        {
            _audioMixer.SetFloat(_exposedAudioParameter, volume);
        }
        public void AudioShotHitsSourse(string tag)
        {
            if (tag == TagsHolder.Ship)
            {
                _audioSourceHandler.PlayOneArmorHitsSource();
            }
            else
            {
                _audioSourceHandler.PlayOneAsteroidHitsSource();
            }
        }
        public void AudioShotDestroy(string tag)
        {
            if (tag == TagsHolder.Ship)
            {
                _audioSourceHandler.PlayOneShipExplosionSource();
            }
            else
            {
                _audioSourceHandler.PlayOneAsteroidExplosionSource();
            }
        }
        public void Cleanup()
        {
            _settingsMenuController.OnSoundVolume -= AudioGroupVolume;
            _shootingController.OnShot -= AudioShotWeaponSource;
            _spaceObjectsController.OnObjectDestroy -= AudioShotDestroy;
            _spaceObjectsController.OnObjectHitEvent -= AudioShotHitsSourse;
        }
    }
}
