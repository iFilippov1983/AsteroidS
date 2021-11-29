using System;
using UnityEngine;

namespace AsteroidS
{
    public abstract class Ammo : MonoBehaviour, IAmmo
    {
        [SerializeField] private AmmoPrefs _ammoPrefs;

        public event Action<int> OnHitEvent;

        public abstract void Hit();
      
        private struct AmmoPrefs
        {
            public AmmoType ammoType;
            public int damage;
            public float speed;
        }
    }

    
}

