using UnityEngine.Audio;

namespace AsteroidS
{
    public class AudioController : IInitialization, ICleanup
    {
        private readonly string _exposedAudioParameter;
        private readonly AudioMixer _audioMixer;
        private readonly AudioSourceHandler _audioSourceHandler;

        public AudioController(SoundData soundData)
        {
            _audioSourceHandler = new AudioSourceHandler();
            _audioMixer = soundData.AudioMixer;
            _exposedAudioParameter = soundData.ExposedAudioParameter;
        } 

        public void Initialize()
        {
            Subscribe();
        }

        public void Cleanup()
        {
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

        private void AudioGroupVolume(float volume)
        {
            _audioMixer.SetFloat(_exposedAudioParameter, volume);
        }
    }
}
