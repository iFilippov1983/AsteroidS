namespace AsteroidS
{
    public sealed class GameInitializer
    {
        private readonly UIController _uiController;
        private readonly GameStateController _gameStateController;
        private readonly SceneController _sceneController;
        private readonly PlayerController _playerController;
        private readonly SpaceObjectsController _spaceObjectsController;
        private readonly GameProgressController _gameProgressController;
        private readonly AudioController _audioController;

        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            _spaceObjectsController = new SpaceObjectsController(gameData);
            _uiController = new UIController(gameData);
            _gameStateController = new GameStateController(_uiController.UIInitializer, _uiController.UIComponentInitializer);
            _playerController = new PlayerController(gameData.PlayerData);
            _sceneController = new SceneController(gameData, _playerController.Player);
            _gameProgressController = new GameProgressController(gameData, _spaceObjectsController, _uiController.ScoreCountController, _gameStateController);
            _audioController = new AudioController(gameData, _uiController.MenuManagementController, _playerController.ShootingController, _spaceObjectsController, _uiController.OnButtonEnterProxy);

            controllers.Add(_uiController);
            controllers.Add(_sceneController);
            controllers.Add(_gameStateController);
            controllers.Add(_spaceObjectsController);
            controllers.Add(_playerController);
            controllers.Add(_gameProgressController);
            controllers.Add(_audioController);
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
