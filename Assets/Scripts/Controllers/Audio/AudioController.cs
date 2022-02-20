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
        private readonly OnButtonEnterProxyController _onButtonEnterProxy;
        private readonly SpaceObjectsController _spaceObjectsController;

        

        private readonly ISoundEventProxy _shotEventDefault;

        public AudioController(SoundData soundData, MenuManagementController menuManagementsController, ShootingController shootingController, SpaceObjectsController spaceObjectsController, OnButtonEnterProxyController onButtonEnterProxy)
        {
            _audioSourceHandler = new AudioSourceHandler(soundData);
            _audioMixer = soundData.AudioMixer;
            _settingsMenuController = menuManagementsController.SettingsMenuController;
            _shootingController = shootingController;
            _exposedAudioParameter = soundData.ExposedAudioParameter;
            _spaceObjectsController = spaceObjectsController;
            _onButtonEnterProxy = onButtonEnterProxy;

            _shotEventDefault = SoundInitializer.Instance.GetSoundEvents().shotEventDefault;
        } 

        public void Initialize()
        {
            //_audioSourceHandler.SetAudioSources();
            //_audioSourceHandler.SetAudioClips();
            //_audioSourceHandler.PlayBackgroundMusic();

            //_settingsMenuController.OnSoundVolume += AudioGroupVolume;

            ////_shootingController.OnShot += AudioShotWeaponSource;
            //_shotEventDefault.OnSoundEvent += AudioShotWeaponSource;

            //_spaceObjectsController.OnObjectDestroySound += AudioShotDestroy;
            //_spaceObjectsController.OnObjectHitEvent += AudioShotHitsSource;
            //_onButtonEnterProxy.OnButtonSelected += AudioButtonSelected;

            Subscribe();
        }

        public void Cleanup()
        {
            //_settingsMenuController.OnSoundVolume -= AudioGroupVolume;
            ////_shootingController.OnShot -= AudioShotWeaponSource;
            //_spaceObjectsController.OnObjectDestroySound -= AudioShotDestroy;
            //_spaceObjectsController.OnObjectHitEvent -= AudioShotHitsSource;
            //_onButtonEnterProxy.OnButtonSelected -= AudioButtonSelected;

            UnSubscribe();
        }

        private void Subscribe()
        {
            foreach (var s in SoundEventSourceOperator.GetSources())
            {
                s.OnSoundEvent += _audioSourceHandler.Play;
            }
        }

        private void UnSubscribe()
        {
            foreach (var s in SoundEventSourceOperator.GetSources())
            {
                s.OnSoundEvent -= _audioSourceHandler.Play;
            }
        }

        //private void AudioButtonSelected()
        //{
        //    _audioSourceHandler.PlayOneButtonSource();
        //}

        //private void AudioShotWeaponSource()
        //{
        //    _audioSourceHandler.PlayOneShotShotWeaponSource();
        //}

        private void AudioGroupVolume(float volume)
        {
            _audioMixer.SetFloat(_exposedAudioParameter, volume);
        }

        //private void AudioShotHitsSource(string tag)
        //{
        //    if (tag.Equals(TagOrName.Ship))
        //    {
        //        _audioSourceHandler.PlayOneArmorHitsSource();
        //    }
        //    else
        //    {
        //        _audioSourceHandler.PlayOneAsteroidHitsSource();
        //    }
        //}

        //private void AudioShotDestroy(string tag)
        //{
        //    if (tag.Equals(TagOrName.Ship))
        //    {
        //        _audioSourceHandler.PlayOneShipExplosionSource();
        //    }
        //    else
        //    {
        //        _audioSourceHandler.PlayOneAsteroidExplosionSource();
        //    }
        //}
    }
}
