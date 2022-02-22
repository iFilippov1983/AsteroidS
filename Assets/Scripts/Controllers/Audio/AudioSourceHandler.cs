using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace AsteroidS
{
    public class AudioSourceHandler
    {
        private GameObject _audioPlayer;
        private List<AudioSource> _audioSourcesList;
        private bool _thisExists;

        public AudioSourceHandler()
        {
            _audioPlayer = new GameObject("AudioPlayer");
            _audioSourcesList = new List<AudioSource>();
            _thisExists = true;
        }

        public void Play(SoundSource source)
        {
            AddAndPlaySource(source);
            HandleSourcesRemove();
        }

        private void AddAndPlaySource(SoundSource source)
        {
            var audioSource = _audioPlayer.AddComponent<AudioSource>();
            audioSource.clip = source.source.clip;
            audioSource.Play();
            _audioSourcesList.Add(audioSource);
        }

        private async void HandleSourcesRemove()
        {
            while (_thisExists)
            {
                for (var i = 0; i < _audioSourcesList.Count; i++)
                {
                    var source = _audioSourcesList[i];
                    if (source.isPlaying) continue;
                    Object.Destroy(source);
                    _audioSourcesList.Remove(source);
                }
                await Task.Yield();   
            }
        }

        ~AudioSourceHandler()
        {
            _thisExists = false;
        }
    }
}
