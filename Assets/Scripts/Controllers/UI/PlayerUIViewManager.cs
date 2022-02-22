using System;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    public sealed class PlayerUIViewManager : IInitialization, ICleanup
    {
        private readonly List<GameObject> _playerHPList;
        private readonly Stack<GameObject> _activeHP;
        private readonly Stack<GameObject> _deactivatedHP;

        //public Action PlayerIsDead;

        public PlayerUIViewManager(PlayerUIView playerUiView)
        {
            _playerHPList = playerUiView.PlayerHPList;
            _activeHP = new Stack<GameObject>();
            _deactivatedHP = new Stack<GameObject>();
        }

        public void Initialize()
        {
            //_spaceObjectsController.OnPlayerDamageEvent += LooseHP;

            foreach (var gameObject in _playerHPList)
            {
                _activeHP.Push(gameObject);
            }
        }

        public void Cleanup()
        {
            //_spaceObjectsController.OnPlayerDamageEvent -= LooseHP;
        }

        public void LooseHP()
        {
            var spendedHP = _activeHP.Pop();
            spendedHP.SetActive(false);
            _deactivatedHP.Push(spendedHP);
            if (_activeHP.Count == 0)
            {
                //PlayerIsDead?.Invoke();
                //_gameStateController.ChangeGameState(GameState.Death);
            }
        }

        public void RestoreHP()
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