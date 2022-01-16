namespace AsteroidS
{
    public class GameProcessInitializer
    {
        private GameData _gameData;
        private ControllersProxy _controllers;
        public SpaceObjectsController spaceObjectsController;
        public PlayerInstatiation playerInstance;
        public PlayerController playerController;

        public GameProcessInitializer(ControllersProxy controllers, GameData gameData)
        {
            _gameData = gameData;
            _controllers = controllers;

            playerInstance = new PlayerInstatiation(gameData);
            spaceObjectsController = new SpaceObjectsController(gameData);

            
            controllers.Add(spaceObjectsController);
        }

        public void LateInit
            (
            UIComponentInitializer uiComponentInitializer, 
            GameStateController gameStateController
#if UNITY_ANDROID
            , AndroidPLayerUIController androidPLayerUiController
#endif
            )
        {
            var inputInitializer = new InputInitializer(uiComponentInitializer);
            var scoreCountController = new ScoreCountController(_gameData, uiComponentInitializer);
            var timerController = new TimerController(_gameData, uiComponentInitializer);

#if UNITY_STANDALONE

            playerController = new PlayerController(_gameData, playerInstance.Player, inputInitializer, gameStateController);
#elif UNITY_ANDROID
playerController = new PlayerController(_gameData, playerInstance.Player, inputInitializer, gameStateController, androidPlayerUIController);
#endif

            _controllers.Add(playerController);
            _controllers.Add(scoreCountController);
            _controllers.Add(timerController);
            _controllers.Add(new InputController(inputInitializer));
            _controllers.Add(new GameProgressController(_gameData, spaceObjectsController, scoreCountController, gameStateController));
        }
    }
}
