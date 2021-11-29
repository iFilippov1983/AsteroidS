using System;

namespace AsteroidS
{ 
    public interface IAmmo
    {
        public event Action<int> OnHitEvent;
        void Hit();
    }
}


