namespace AsteroidS
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var inputInitialiser = new InputInitializer();
            var playerInitializer = new PlayerInitializer(gameData);
            var sceneInitializer = new SceneInitializer(gameData);
            var uiInitialize = new UIInitializer(gameData);
            var uiComponentInitializer = new UIComponentInitializer(gameData, uiInitialize);
            var gameStateController = new GameStateController(uiInitialize, uiComponentInitializer);
            var menuManagmentController = new MenuManagmentController(gameData, uiComponentInitializer, gameStateController);
            var onButtonEnterProxy = new OnButtonEnterProxyController(uiComponentInitializer);
            var spaceObjectsController = new SpaceObjectsController(gameData);
            var scoreCountController = new ScoreCountController(gameData, uiComponentInitializer);
            var timerController = new TimerController(gameData, uiComponentInitializer);
            var playerController = new PlayerController(gameData, playerInitializer.Player, inputInitialiser, gameStateController);

            controllers.Add(sceneInitializer);
            controllers.Add(uiComponentInitializer);
            controllers.Add(gameStateController);
            controllers.Add(menuManagmentController);
            controllers.Add(onButtonEnterProxy);
            controllers.Add(spaceObjectsController);
            controllers.Add(scoreCountController);
            controllers.Add(timerController);
            controllers.Add(playerController);

            controllers.Add(new InputController(inputInitialiser));
            controllers.Add(new GameProgressController(gameData, spaceObjectsController, scoreCountController, gameStateController));
            controllers.Add(new AudioController(gameData, menuManagmentController, playerController.ShootingController, spaceObjectsController, onButtonEnterProxy));
        }
    }
}
