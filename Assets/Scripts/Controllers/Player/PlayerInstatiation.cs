using UnityEngine;
using Object = UnityEngine.Object;

namespace AsteroidS
{
    public sealed class PlayerInstatiation
    {
        private readonly GameObject _player;

        public Transform Player => _player.transform;

        public PlayerInstatiation(GameData gameData)
        {
            var playerPrefab = gameData.PlayerData.PlayerPrefab;
            _player = Object.Instantiate(playerPrefab);
        }
    }
}
