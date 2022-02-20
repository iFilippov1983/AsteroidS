namespace AsteroidS
{
    public sealed class GameProcessInitializer
    {
        private readonly GameData _gameData;
        private readonly ControllersProxy _controllers;
        internal readonly SpaceObjectsController SpaceObjectsController;
        internal readonly PlayerInstantiation PlayerInstance;
        internal PlayerController PlayerController;
        

        public GameProcessInitializer(ControllersProxy controllers, GameData gameData)
        {
//            _gameData = gameData;
//            _controllers = controllers;

//            PlayerInstance = new PlayerInstatiation(gameData);
//            SpaceObjectsController = new SpaceObjectsController(gameData);

            
//            controllers.Add(SpaceObjectsController);
//        }

//        public void LateInit
//            (
//            UIComponentInitializer uiComponentInitializer, 
//            GameStateController gameStateController
//#if UNITY_ANDROID
//            , AndroidPlayerUIController androidPlayerUIController
//#endif
//            )
//        {
//            var inputInitializer = new InputInitializer(uiComponentInitializer);
//            var scoreCountController = new ScoreCountController(_gameData, uiComponentInitializer);
//            var timerController = new TimerController(_gameData, uiComponentInitializer);
//#if UNITY_STANDALONE
//            PlayerController = new PlayerController(_gameData, PlayerInstance.Player, inputInitializer, gameStateController);

//#elif UNITY_ANDROID
//            PlayerController = new PlayerController(_gameData, PlayerInstance.Player, inputInitializer, gameStateController, androidPlayerUIController);
//#endif

//            _controllers.Add(PlayerController);
//            _controllers.Add(scoreCountController);
//            _controllers.Add(timerController);
//            _controllers.Add(new InputController(inputInitializer));
//            _controllers.Add(new GameProgressController(_gameData, SpaceObjectsController, scoreCountController,
//                gameStateController));
        }
    }
}
