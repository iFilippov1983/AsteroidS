using System;
using UnityEngine;

namespace AsteroidS
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private string _ammoPropertiesPath;
        
        private AmmoProperties _ammoProperties;
        
        public AmmoProperties Properties
        {
            get 
            {
                if (_ammoProperties == null)
                {
                    _ammoProperties = Resources.Load<AmmoProperties>("GameData/" + _ammoPropertiesPath);
                }

                return _ammoProperties;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out SpaceObject so))
            {
                Destroy(this);
            } 
        }
    }
}

