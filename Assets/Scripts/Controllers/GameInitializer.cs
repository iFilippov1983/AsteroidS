namespace AsteroidS
{
    public sealed class GameInitializer
    {
        private readonly SceneInitializer _sceneInitializer;
        private readonly GameProcessInitializer _gameProcessInitializer;

        private readonly UIController _uiController;
        private readonly GameStateController _gameStateController;
        private readonly SceneController _sceneController;
        private readonly PlayerController _playerController;

        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            _uiController = new UIController(gameData);
           
                    //var uiInitialize = new UIInitializer(gameData);
                    //var uiComponentInitializer = new UIComponentInitializer(gameData, uiInitialize);
            var playerInstance = new PlayerInstatiation(gameData);
            var inputInitializer = new InputInitializer();
            _sceneController = new SceneController(gameData, playerInstance.Player);
                    //var gameStateController = new GameStateController(uiInitialize, uiComponentInitializer);
                    //var menuManagementController = new MenuManagementController(gameData, uiComponentInitializer, gameStateController);
                    //var onButtonEnterProxy = new OnButtonEnterProxyController(uiComponentInitializer);
            var spaceObjectsController = new SpaceObjectsController(gameData);
            //var playerHPManagmentController = new PlayerHPManagementController(uiComponentInitializer.PlayerUIView,gameStateController, spaceObjectsController);
                    //var scoreCountController = new ScoreCountController(gameData, uiComponentInitializer);
                    //var timerController = new TimerController(gameData, uiComponentInitializer);
            
            _gameStateController = new GameStateController(_uiController.UIInitializer, _uiController.UIComponentInitializer);
            _playerController = new PlayerController(gameData, playerInstance.Player, inputInitializer, _gameStateController);
            controllers.Add(_uiController);

            controllers.Add(_sceneController);
                    //controllers.Add(uiComponentInitializer);
            controllers.Add(_gameStateController);
                    //controllers.Add(menuManagementController);
                    //controllers.Add(onButtonEnterProxy);
            controllers.Add(spaceObjectsController);
                    //controllers.Add(playerHPManagmentController);
                    //controllers.Add(scoreCountController);
                    //controllers.Add(timerController);
            controllers.Add(_playerController);

            controllers.Add(new InputController(inputInitializer));
            controllers.Add(new GameProgressController(gameData, spaceObjectsController, _uiController.ScoreCountController, _gameStateController));//////////////////
            controllers.Add(new AudioController(gameData, _uiController.MenuManagementController, _playerController.ShootingController, spaceObjectsController, _uiController.OnButtonEnterProxy));
        }

        public void Configure()
        {
            _playerController.EscapePressed += _gameStateController.SetPauseState;
            _uiController.GameStateChangeAction += _gameStateController.ChangeGameState;
        }

        public void Cleanup()
        {
            _playerController.EscapePressed -= _gameStateController.SetPauseState;
            _uiController.GameStateChangeAction -= _gameStateController.ChangeGameState;
        }
    }
}
