using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(menuName = "GameData/BulletData", fileName = "BulletData")]
    internal class BulletData
    {
        [SerializeField] private GameObject _bulletPrefab;

        internal GameObject PlayerPrefab { get { return _bulletPrefab; } }
    }
}
