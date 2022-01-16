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
            var androidPlayerUIController =
                new AndroidPLayerUIController(uiComponentInitializer, gameStateController, gameData);
            var spaceObjectsController = new SpaceObjectsController(gameData);
            var scoreCountController = new ScoreCountController(gameData, uiComponentInitializer);
            var timerController = new TimerController(gameData, uiComponentInitializer);
            var playerController = new PlayerController(gameData, playerInitializer.Player, inputInitializer, gameStateController, androidPlayerUIController);

            controllers.Add(sceneController);
            controllers.Add(uiComponentInitializer);
            controllers.Add(gameStateController);
            controllers.Add(menuManagementController);
            controllers.Add(onButtonEnterProxy);
            controllers.Add(androidPlayerUIController);
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
