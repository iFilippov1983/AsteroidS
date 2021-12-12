namespace AsteroidS
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var inputInitialiser = new InputInitializer();
            var playerInitializer = new PlayerInitializer(gameData);
            var uiInitialize = new UIInitializer(gameData);
            var spaceObjectsController = new SpaceObjectsController(gameData);
            var scoreCountController = new ScoreCountController(gameData, uiInitialize);
            var timerController = new TimerController(gameData, uiInitialize);
            var menuController = new MenuController();
            var shootingController = new ShootingController(gameData, playerInitializer.Player.transform);

            controllers.Add(uiInitialize);
            controllers.Add(spaceObjectsController);
            controllers.Add(scoreCountController);
            controllers.Add(timerController);
            controllers.Add(new SceneInitializer(gameData));
            controllers.Add(new InputController(inputInitialiser.GetInput()));
            controllers.Add(new PlayerMovementController(gameData, playerInitializer.Player, inputInitialiser.GetInput()));
            controllers.Add(shootingController);
            controllers.Add(new GameProgressController(gameData, spaceObjectsController, scoreCountController, timerController));
            controllers.Add(new AudioController(gameData, menuController, shootingController));
        }
    }
}
