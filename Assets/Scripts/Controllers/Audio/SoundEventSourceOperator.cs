using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AsteroidS
{
    public static class SoundEventSourceOperator
    {
        private static List<ISoundEventSource> _soundEventSources;

        public static void Add(ISoundEventSource source)
        {
            if (_soundEventSources == null) _soundEventSources = new List<ISoundEventSource>();
            _soundEventSources.Add(source);
        }

        public static List<ISoundEventSource> GetSources()
        {
            if (_soundEventSources != null) return _soundEventSources;
            return new List<ISoundEventSource>();
        }
    }
}