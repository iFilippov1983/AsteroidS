using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    public sealed class PlayerHPManagementController : IInitialization, ICleanup
    {
        private readonly List<GameObject> _playerHPList;
        private readonly GameStateController _gameStateController;
        private readonly SpaceObjectsController _spaceObjectsController;
        private readonly Stack<GameObject> _activeHP;
        private readonly Stack<GameObject> _deactivatedHP;

        public PlayerHPManagementController(PlayerUIView playerUiView, GameStateController gameStateController,
            SpaceObjectsController spaceObjectsController)
        {
            _playerHPList = playerUiView.PlayerHPList;
            _gameStateController = gameStateController;
            _spaceObjectsController = spaceObjectsController;
            _activeHP = new Stack<GameObject>();
            _deactivatedHP = new Stack<GameObject>();
        }

        public void Initialize()
        {
            _spaceObjectsController.OnPlayerDamageEvent += LooseHP;

            foreach (var gameObject in _playerHPList)
            {
                _activeHP.Push(gameObject);
            }
        }

        public void Cleanup()
        {
            _spaceObjectsController.OnPlayerDamageEvent -= LooseHP;
        }

        private void LooseHP()
        {
            var spendedHP = _activeHP.Pop();
            spendedHP.SetActive(false);
            _deactivatedHP.Push(spendedHP);
            if (_activeHP.Count == 0)
            {
                _gameStateController.ChangeGameState(GameState.Death);
            }
        }

        private void RestoreHP()
        {
            for (var i = 0; i < _playerHPList.Count; i++)
            {
                var restoredHP = _deactivatedHP.Pop();
                restoredHP.SetActive(true);
                _activeHP.Push(restoredHP);
            }
        }
    }
}