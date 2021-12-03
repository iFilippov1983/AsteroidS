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
