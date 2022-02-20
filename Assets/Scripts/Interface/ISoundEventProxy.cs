using System;
using UnityEngine;

namespace AsteroidS
{
    public interface ISoundEventProxy
    {
        event Action OnSoundEvent;
        event Action<float> OnSoundChangeEvent;
        void Invoke();
    }
}