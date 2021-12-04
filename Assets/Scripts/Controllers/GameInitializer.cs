namespace AsteroidS
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var inputInitialiser = new InputInitializer();
            var playerInitializer = new PlayerInitializer(gameData);
            var scoreCountController = new ScoreCountController(gameData);
            var timerController = new TimerController(gameData);

            controllers.Add(new SceneInitializer(gameData));
            controllers.Add(new SpaceObjectsController(gameData));
            controllers.Add(new InputController(inputInitialiser.GetInput()));
            controllers.Add(new PlayerMovementController(gameData, playerInitializer.Player, inputInitialiser.GetInput()));
            controllers.Add(scoreCountController);
            controllers.Add(timerController);
        }
    }
}
