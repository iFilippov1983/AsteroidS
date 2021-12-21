﻿using System;
using UnityEngine;

namespace AsteroidS
{
    public class KeysHandler
    {
        private GameStateController _gameStateController;
        private PlayerData _playerData;

        public KeysHandler(GameData gameData, GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _playerData = gameData.PlayerData;
        }

        public void EscapeKeyPressed(float cancel)
        {
            if (cancel == 0) return;
            _gameStateController.ChangeGameState(GameState.Default);
        }

        public void NubmerPressed(ref int number)
        {
            _playerData.SwitchAmmoTo(number);
            number = 0;
        }

        public void SwitchKeyPressed(float switchPressed)
        {

        }
    }
}