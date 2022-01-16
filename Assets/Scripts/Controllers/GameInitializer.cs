namespace AsteroidS
{
    public class GameInitializer
    {
        private SceneInitializer _sceneInitializer;
        private GameProcessInitializer _gameProcessInitializer;

        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            _sceneInitializer = new SceneInitializer(controllers, gameData);
            _gameProcessInitializer = new GameProcessInitializer(controllers, gameData);

#region Old version
            //var uiInitialize = new UIInitializer(gameData);
            //var uiComponentInitializer = new UIComponentInitializer(gameData, uiInitialize);
            //var playerInstance = new PlayerInstatiation(gameData);
            //var inputInitializer = new InputInitializer(uiComponentInitializer);
            //var sceneController = new SceneController(gameData, playerInstance.Player);
            //var gameStateController = new GameStateController(uiInitialize, uiComponentInitializer);
            //var menuManagementController = new MenuManagementController(gameData, uiComponentInitializer, gameStateController);
            //var onButtonEnterProxy = new OnButtonEnterProxyController(uiComponentInitializer);
//#if UNITY_ANDROID
//            var androidPlayerUIController =
//                new AndroidPLayerUIController(uiComponentInitializer, gameStateController, gameData);
//#endif
            //var spaceObjectsController = new SpaceObjectsController(gameData);
            //var scoreCountController = new ScoreCountController(gameData, uiComponentInitializer);
            //var timerController = new TimerController(gameData, uiComponentInitializer);
            
//#if UNITY_STANDALONE
            
//            var playerController = new PlayerController(gameData, playerInstance.Player, inputInitializer, gameStateController);
//#elif UNITY_ANDROID
//var playerController = new PlayerController(gameData, playerInitializer.Player, inputInitializer, gameStateController, androidPlayerUIController);
//#endif
            //controllers.Add(sceneController);
            //controllers.Add(uiComponentInitializer);
            //controllers.Add(gameStateController);
            //controllers.Add(menuManagementController);
            //controllers.Add(onButtonEnterProxy);
//#if UNITY_ANDROID
//            controllers.Add(androidPlayerUIController);      
//#endif
            //controllers.Add(spaceObjectsController);
            //controllers.Add(scoreCountController);
            //controllers.Add(timerController);
            //controllers.Add(playerController);

            //controllers.Add(new InputController(inputInitializer));
            //controllers.Add(new GameProgressController(gameData, spaceObjectsController, scoreCountController, gameStateController));
            //controllers.Add(new AudioController(gameData, menuManagementController, playerController.ShootingController, spaceObjectsController, onButtonEnterProxy));
#endregion

        }


        public void LateInit()
        {
            _gameProcessInitializer.LateInit
                (
                _sceneInitializer.uiComponentInitializer,
                _sceneInitializer.gameStateController
#if UNITY_ANDROID
                , _sceneInitializer.androidPLayerUiController
#endif
                );

            _sceneInitializer.LateInit
                (
                _gameProcessInitializer.playerInstance.Player,
                _gameProcessInitializer.playerController,
                _gameProcessInitializer.spaceObjectsController
                );
        }
    }
}
