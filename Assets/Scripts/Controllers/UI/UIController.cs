using System;

namespace AsteroidS
{
    public class UIController : IInitialization, IExecute, ICleanup
    {
        private UIInitializer _uiInitializer;
        private UIComponentInitializer _uiComponentInitializer;
        private MenuManagementController _menuManagementController;
        private MenuViewHandler _menuViewHandler;
        //private PlayerUIViewManager _playerHPManager;
        private ScoreCountController _scoreCountController;
        private TimerController _timerController;

        public UIInitializer UIInitializer => _uiInitializer;
        public UIComponentInitializer UIComponentInitializer => _uiComponentInitializer;
        public ScoreCountController ScoreCountController => _scoreCountController;

        //public Action<int> PlayerHPChanged;//!!!!!!!
        public Action<GameState> GameStateChangeAction;

        public UIController(GameData gameData)
        {
            _uiInitializer = new UIInitializer(gameData);
            _uiComponentInitializer = new UIComponentInitializer(gameData.SceneData, _uiInitializer);
            _menuManagementController = new MenuManagementController(gameData.SceneData, _uiComponentInitializer);
            _menuViewHandler = new MenuViewHandler(_uiComponentInitializer);
            //_playerHPManager = new PlayerUIViewManager(_uiComponentInitializer.PlayerUIView);//, _gameStateController);
            _scoreCountController = new ScoreCountController(gameData.UIData, _uiComponentInitializer.PlayerUIView.ScoreCount);
            _timerController = new TimerController(gameData, _uiComponentInitializer);
        }

        public void Initialize()
        {
            _uiComponentInitializer.Initialize();
            _menuManagementController.Initialize();
            _menuViewHandler.Initialize();
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
            _menuViewHandler.Cleanup();

            _menuManagementController.MenuStateChangeAction -= MenuStateChanged;
        }

        private void MenuStateChanged(GameState state)
        {
            GameStateChangeAction?.Invoke(state);
        }
    }
}
