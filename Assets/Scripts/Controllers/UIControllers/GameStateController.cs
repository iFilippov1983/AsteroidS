﻿using UnityEditor;
using UnityEngine;

namespace AsteroidS
{
    public sealed class GameStateController:IInitialization
    {
        private readonly DefaultStateController _defaultStateController;
        private readonly StartGameStateController _startGameController;
        private readonly SettingsStateController _settingsStateController;
        private readonly DeathStateController _deathStateController;
        private readonly ExitStateController _exitStateController;

        private GameState _currentGameState;
        private GameState _previousGameState;

        public GameStateController(UIInitializer uiInitializer, UIComponentInitializer uiComponentInitializer)
        {
            _defaultStateController = new DefaultStateController(uiInitializer, uiComponentInitializer, this);
            _startGameController = new StartGameStateController(uiInitializer);
            _settingsStateController = new SettingsStateController(uiInitializer);
            _deathStateController = new DeathStateController(uiInitializer);
            _exitStateController = new ExitStateController();
        }

        public void Initialize()
        {
            _defaultStateController.Init();
            ChangeGameState(GameState.Default);
        }

        public void ChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Start:
                    GetPreviousState(gameState);
                    _startGameController.StartGame();
                    break;
                case GameState.Settings:
                    _settingsStateController.SettingsMenu();
                    break;
                case GameState.Pause:
                    GetPreviousState(gameState);
                    _defaultStateController.DefaultState(gameState, _previousGameState);
                    break;
                case GameState.Death:
                    GetPreviousState(gameState);
                    _deathStateController.DeathState();
                    break;
                case GameState.Exit:
                    _exitStateController.ExitGame();
                    break;
                case GameState.Default:
                    GetPreviousState(gameState);
                    _defaultStateController.DefaultState(gameState, _previousGameState);
                    break;
            }
        }

        private void GetPreviousState(GameState gameState)
        {
            _previousGameState = _currentGameState;
            _currentGameState = gameState;
            Debug.LogWarning($"{_currentGameState}, {_previousGameState}");
        }
    }
}