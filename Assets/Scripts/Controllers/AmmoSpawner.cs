using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    public class AmmoSpawner
    {
        private Dictionary<AmmoType, Ammo> _ammoPrefabsDictionary;

        public AmmoSpawner(Dictionary<AmmoType, Ammo> dictionary)
        {
            _ammoPrefabsDictionary = dictionary;
        }

        public Dictionary<AmmoType, Stack<Ammo>> MakeSpawnedAmmoDictionary()
        {
            var dictionary = new Dictionary<AmmoType, Stack<Ammo>>();

            for (int prefabIndex = 1; prefabIndex <= _ammoPrefabsDictionary.Count; prefabIndex++)
            {
                var ammoType = (AmmoType)prefabIndex;
                var prefab = _ammoPrefabsDictionary[ammoType];
                var amount = CalculateAmmoAmount(prefab.Properties);
                dictionary.Add(ammoType, new Stack<Ammo>());

                for (int index = 0; index < amount; index++)
                {
                    var obj = SpawnUnactiveAmmoObject(ammoType);
                    dictionary[ammoType].Push(obj);
                }
            }

            return dictionary;
        }

        //public Ammo Respawn(Ammo ammo, Transform transform)
        //{
        //    var spawnedAmmo = Object.Instantiate(ammo, transform.position, transform.rotation);

        //    return spawnedAmmo;
        //}

        private int CalculateAmmoAmount(AmmoProperties properties)
        {
            int amount;
            var reloadTime = properties.reloadTime;
            var lifetime = properties.LifeTime;

            if (reloadTime > lifetime) amount = 1;
            else amount = (int)(lifetime/reloadTime + 1);
            
            return amount;
        }

        private Ammo SpawnUnactiveAmmoObject(AmmoType type)
        {
            var prefab = _ammoPrefabsDictionary[type];
            var obj = Object.Instantiate(prefab);
            obj.gameObject.SetActive(false);

            return obj;
        }
    }
}

