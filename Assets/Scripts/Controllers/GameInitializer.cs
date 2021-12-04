namespace AsteroidS
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var inputInitialiser = new InputInitializer();
            var playerInitializer = new PlayerInitializer(gameData);
            var uiInitialize = new UIInitialize(gameData);
            var scoreCountController = new ScoreCountController(gameData, uiInitialize);
            var timerController = new TimerController(gameData, uiInitialize);

            controllers.Add(new SceneInitializer(gameData));
            controllers.Add(new SpaceObjectsController(gameData));
            controllers.Add(new InputController(inputInitialiser.GetInput()));
            controllers.Add(new PlayerMovementController(gameData, playerInitializer.Player, inputInitialiser.GetInput()));
            controllers.Add(uiInitialize);
            controllers.Add(scoreCountController);
            controllers.Add(timerController);
        }
    }
}
