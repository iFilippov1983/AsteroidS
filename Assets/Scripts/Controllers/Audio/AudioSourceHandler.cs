using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace AsteroidS
{
    public class AudioSourceHandler
    {
        //private const string ParentName = "AudioSourceHandler";

        //private AudioSource _backgroundMusicSource;
        //private AudioSource _shotWeaponSource;
        //private AudioSource _armorHitsSource;
        //private AudioSource _asteroidExplosionSource;
        //private AudioSource _shipExplosionSource;
        //private AudioSource _asteroidHitsSource;
        //private AudioSource _buttonSource;
        //private readonly AudioClip _backgroundMusicClip;
        //private readonly AudioClip _shotWeaponSourceClip;
        //private readonly AudioClip _armorHitSourceClip;
        //private readonly AudioClip _asteroidExplosionClip;
        //private readonly AudioClip _shipExplosionClip;
        //private readonly AudioClip _asteroidHitClip;
        //private readonly AudioClip _buttonClip;


        //private readonly AudioMixerGroup _audioMainMixerGroup;
        //private readonly AudioMixerGroup _audioMixerGroupEffects;
        //private readonly GameObject _parent;
        private GameObject _audioPlayer;
        private Stack<AudioSource> _audioSources;
        private Stack<Coroutine> _coroutines;
        private List<AudioSource> _audioSourcesList;

        private Coroutine _playSound;

        public AudioSourceHandler(SoundData soundData)
        {
            //_audioMainMixerGroup = soundData.AudioMixerGroup;
            //_parent = new GameObject(ParentName);
            //_backgroundMusicClip = soundData.BackgroundMusicClip;
            //_shotWeaponSourceClip = soundData.ShotWeaponClip;
            //_armorHitSourceClip = soundData.ArmorHitsClip;
            //_asteroidExplosionClip = soundData.AsteroidExplosionClip;
            //_shipExplosionClip = soundData.ShipExplosionClip;
            //_asteroidHitClip = soundData.AsteroidHitsClip;
            //_buttonClip = soundData.ButtonClip;
            //_audioMixerGroupEffects = soundData.EffectsMixerGroup;

            //_sources = new Stack<AudioSource>();
            //_clips = soundData.SoundSources;
            //_source = _parent.AddComponent<AudioSource>();
            _audioPlayer = new GameObject("AudioPlayer");
            _audioSources = new Stack<AudioSource>();
            _coroutines = new Stack<Coroutine>();
            _audioSourcesList = new List<AudioSource>();
        }

        public void Play(SoundSource source)
        {
            AudioSourceAddAndPlayManger(source);
            AudioSourceRemoveManager();
            /*_audioSources.Push(audioSource);
            _playSound = CoroutinesController.StartRoutine(PlaySoundRoutine(audioSource));
            _coroutines.Push(_playSound);*/
        }

        private void AudioSourceAddAndPlayManger(SoundSource source)
        {
            var audioSource = _audioPlayer.AddComponent<AudioSource>();
            audioSource.clip = source.source.clip;
            audioSource.Play();
            _audioSourcesList.Add(audioSource);
        }

        private async void AudioSourceRemoveManager()
        {
            while (true)
            {
                for (var i = 0; i < _audioSourcesList.Count; i++)
                {
                    var source = _audioSourcesList[i];
                    if (source.isPlaying) continue;
                    Debug.Log($"{source.isPlaying} {_audioSourcesList.Count}");
                    Object.Destroy(source);
                    _audioSourcesList.Remove(source);
                }
                await Task.Yield();   
            }
        }

        private IEnumerator PlaySoundRoutine(AudioSource source)
        {
            source.Play();  
            yield return new WaitWhile(() => source.isPlaying);
            foreach (var coroutine in _coroutines)
            {
                CoroutinesController.StopRoutine(coroutine);
            }
            foreach (var audioSource in _audioSources)
            {
                Object.Destroy(audioSource);
            }
            _coroutines.Clear();
            _audioSources.Clear();
        }

        public void SetAudioSources()
        {
            //_backgroundMusicSource = SetParentAndMixerGroup(_audioMainMixerGroup);
            //_shotWeaponSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
            //_armorHitsSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
            //_asteroidExplosionSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
            //_shipExplosionSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
            //_asteroidHitsSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
            //_buttonSource = SetParentAndMixerGroup(_audioMixerGroupEffects);
        }

        public void PlayBackgroundMusic()
        {
            //_backgroundMusicSource.Play();
        }

        public void SetAudioClips()
        {
            //_backgroundMusicSource.clip = _backgroundMusicClip;
            //_shotWeaponSource.clip = _shotWeaponSourceClip;
            //_armorHitsSource.clip = _armorHitSourceClip;
            //_asteroidExplosionSource.clip = _asteroidExplosionClip;
            //_shipExplosionSource.clip = _shipExplosionClip;
            //_asteroidHitsSource.clip = _asteroidExplosionClip;
        }

        //public void PlayOneShotShotWeaponSource()
        //{
        //    _shotWeaponSource.PlayOneShot(_shotWeaponSourceClip);
        //}

        //public void PlayOneArmorHitsSource()
        //{
        //    _armorHitsSource.PlayOneShot(_armorHitSourceClip);
        //}

        //public void PlayOneAsteroidExplosionSource()
        //{
        //    _asteroidExplosionSource.PlayOneShot(_asteroidExplosionClip);
        //}

        //public void PlayOneShipExplosionSource()
        //{
        //    _shipExplosionSource.PlayOneShot(_shipExplosionClip);
        //}

        //public void PlayOneAsteroidHitsSource()
        //{
        //    _asteroidHitsSource.PlayOneShot(_asteroidHitClip);
        //}

        //private AudioSource SetParentAndMixerGroup(AudioMixerGroup audioMixerGroup)
        //{
        //    var audioSource = _parent.AddComponent<AudioSource>();
        //    audioSource.outputAudioMixerGroup = audioMixerGroup;
        //    return audioSource;
        //}

        //public void PlayOneButtonSource()
        //{
        //    _buttonSource.PlayOneShot(_buttonClip);
        //}
    }
}
