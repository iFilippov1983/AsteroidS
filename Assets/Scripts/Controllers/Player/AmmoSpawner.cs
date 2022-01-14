using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    public sealed class AmmoSpawner
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
                var amount = prefab.Properties.AmmoAmount;

                dictionary.Add(ammoType, new Stack<Ammo>());

                for (int index = 0; index < amount; index++)
                {
                    var obj = SpawnUnactiveAmmoObject(ammoType);
                    dictionary[ammoType].Push(obj);
                }
            }

            return dictionary;
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

