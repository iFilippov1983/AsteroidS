using System;

namespace AsteroidS
{
    public class ProxyShotEventDefault : ISoundEventProxy
    {
        public event Action OnSoundEvent = delegate () { };
        public event Action<float> OnSoundChangeEvent = delegate(float f) { };
        public void Invoke()
        {
            OnSoundEvent?.Invoke();
        }
    }
}