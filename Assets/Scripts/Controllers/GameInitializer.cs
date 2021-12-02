namespace AsteroidS
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData, UIRootView uiRootView)
        {
            var inputInitialiser = new InputInitializer();
            var playerInitializer = new PlayerInitializer(gameData);
            var scoreCountController = new ScoreCountController(uiRootView.ScoreCount);
            var timerController = new TimerController(uiRootView.Timer);

            controllers.Add(new SceneInitializer(gameData));
            controllers.Add(new SpaceObjectsController(gameData));
            controllers.Add(new InputController(inputInitialiser.GetInput()));
            controllers.Add(new PlayerMovementController(gameData, playerInitializer.Player, inputInitialiser.GetInput()));
            controllers.Add(scoreCountController);
            controllers.Add(timerController);
        }
    }
}
