namespace AsteroidS
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var uiInitialize = new UIInitializer(gameData);
            var uiComponentInitializer = new UIComponentInitializer(gameData, uiInitialize);
            var playerInitializer = new PlayerInitializer(gameData);
            var inputInitializer = new InputInitializer(uiComponentInitializer);
            var sceneController = new SceneController(gameData, playerInitializer.Player);
            var gameStateController = new GameStateController(uiInitialize, uiComponentInitializer);
            var menuManagementController = new MenuManagementController(gameData, uiComponentInitializer, gameStateController);
            var onButtonEnterProxy = new OnButtonEnterProxyController(uiComponentInitializer);
#if UNITY_ANDROID
            var androidPlayerUIController =
                new AndroidPLayerUIController(uiComponentInitializer, gameStateController, gameData);
#endif
            var spaceObjectsController = new SpaceObjectsController(gameData);
            var scoreCountController = new ScoreCountController(gameData, uiComponentInitializer);
            var timerController = new TimerController(gameData, uiComponentInitializer);
            
#if UNITY_STANDALONE
            
            var playerController = new PlayerController(gameData, playerInitializer.Player, inputInitializer, gameStateController);
#elif UNITY_ANDROID
var playerController = new PlayerController(gameData, playerInitializer.Player, inputInitializer, gameStateController, androidPlayerUIController);
#endif
            controllers.Add(sceneController);
            controllers.Add(uiComponentInitializer);
            controllers.Add(gameStateController);
            controllers.Add(menuManagementController);
            controllers.Add(onButtonEnterProxy);
#if UNITY_ANDROID
            controllers.Add(androidPlayerUIController);      
#endif
            controllers.Add(spaceObjectsController);
            controllers.Add(scoreCountController);
            controllers.Add(timerController);
            controllers.Add(playerController);

            controllers.Add(new InputController(inputInitializer));
            controllers.Add(new GameProgressController(gameData, spaceObjectsController, scoreCountController, gameStateController));
            controllers.Add(new AudioController(gameData, menuManagementController, playerController.ShootingController, spaceObjectsController, onButtonEnterProxy));
        }
    }
}
