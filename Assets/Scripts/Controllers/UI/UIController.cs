using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    public class UIController : IInitialization, IExecute, ICleanup
    {
        private UIInitializer _uiInitializer;
        private UIComponentInitializer _uiComponentInitializer;
        private MenuManagementController _menuManagementController;
        private OnButtonEnterProxyController _onButtonEnterProxy;
        private PlayerUIViewManager _playerHPManager;
        private ScoreCountController _scoreCountController;
        private TimerController _timerController;

        public UIInitializer UIInitializer => _uiInitializer;
        public UIComponentInitializer UIComponentInitializer => _uiComponentInitializer;
        public MenuManagementController MenuManagementController => _menuManagementController;
        public OnButtonEnterProxyController OnButtonEnterProxy => _onButtonEnterProxy;
        public ScoreCountController ScoreCountController => _scoreCountController;

        public Action<int> PlayerHPChanged;//!!!!!!!
        public Action<GameState> GameStateChangeAction;

        public UIController(GameData gameData)
        {
            _uiInitializer = new UIInitializer(gameData);
            _uiComponentInitializer = new UIComponentInitializer(gameData.SceneData, _uiInitializer);
            _menuManagementController = new MenuManagementController(gameData.SceneData, _uiComponentInitializer);//, _gameStateController);
            _onButtonEnterProxy = new OnButtonEnterProxyController(_uiComponentInitializer);
            //_playerHPManager = new PlayerUIViewManager(_uiComponentInitializer.PlayerUIView);//, _gameStateController);
            _scoreCountController = new ScoreCountController(gameData.UIData, _uiComponentInitializer.PlayerUIView);
            _timerController = new TimerController(gameData, _uiComponentInitializer);
        }

        public void Initialize()
        {
            _uiComponentInitializer.Initialize();
            _menuManagementController.Initialize();
            _onButtonEnterProxy.Initialize();
            _scoreCountController.Initialize();
            _timerController.Initialize();

            _menuManagementController.MenuStateChangeAction += MenuStateChanged;
        }

        public void Execute(float deltaTime)
        {
            _scoreCountController.Execute();
            _timerController.Execute(deltaTime);
        }

        public void Cleanup()
        {
            _menuManagementController.Cleanup();
            _onButtonEnterProxy.Cleanup();

            _menuManagementController.MenuStateChangeAction -= MenuStateChanged;
        }

        private void MenuStateChanged(GameState state)
        {
            GameStateChangeAction?.Invoke(state);
        }
    }
}
