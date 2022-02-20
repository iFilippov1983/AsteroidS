using System;
using UnityEditor;
using UnityEngine;

namespace AsteroidS
{
    public interface ISoundEventSource
    {
        event Action<SoundSource> OnSoundEvent;
    }
}