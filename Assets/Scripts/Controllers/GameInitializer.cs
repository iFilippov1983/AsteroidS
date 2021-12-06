namespace AsteroidS
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var inputInitialiser = new InputInitializer();
            var playerInitializer = new PlayerInitializer(gameData);
            var uiInitialize = new UIInitialize(gameData);
            var spaceObjectsController = new SpaceObjectsController(gameData);

            controllers.Add(uiInitialize);
            controllers.Add(spaceObjectsController);
            controllers.Add(new SceneInitializer(gameData));
            controllers.Add(new InputController(inputInitialiser.GetInput()));
            controllers.Add(new PlayerMovementController(gameData, playerInitializer.Player, inputInitialiser.GetInput()));
            controllers.Add(new ShootingController(gameData, playerInitializer.Player.transform));
            controllers.Add(new ScoreCountController(gameData, uiInitialize));
            controllers.Add(new TimerController(gameData, uiInitialize));
            controllers.Add(new GameProgressController(gameData, spaceObjectsController));
        }
    }
}
