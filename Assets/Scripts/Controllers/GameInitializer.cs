namespace AsteroidS
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var inputInitialiser = new InputInitializer();
            var playerInitializer = new PlayerInitializer(gameData);
            var uiInitialize = new UIInitializer(gameData);
            var uiComponentInitializer = new UIComponentInitializer(uiInitialize);
            var gameStateController = new GameStateController(uiInitialize, uiComponentInitializer);
            var menuManagmentController = new MenuManagmentController(gameData, uiComponentInitializer, gameStateController);
            var spaceObjectsController = new SpaceObjectsController(gameData);
            var scoreCountController = new ScoreCountController(gameData, uiComponentInitializer);
            var timerController = new TimerController(gameData, uiComponentInitializer);
            var shootingController = new ShootingController(gameData, playerInitializer.Player.transform);

            controllers.Add(uiComponentInitializer);
            controllers.Add(gameStateController);
            controllers.Add(menuManagmentController);
            controllers.Add(spaceObjectsController);
            controllers.Add(scoreCountController);
            controllers.Add(timerController);
            controllers.Add(shootingController);

            controllers.Add(new SceneInitializer(gameData));
            controllers.Add(new InputController(inputInitialiser));
            controllers.Add(new PlayerController(gameData, playerInitializer.Player, inputInitialiser, gameStateController));
            controllers.Add(new GameProgressController(gameData, spaceObjectsController, scoreCountController, gameStateController));
            controllers.Add(new AudioController(gameData, menuManagmentController, shootingController));
        }
    }
}
