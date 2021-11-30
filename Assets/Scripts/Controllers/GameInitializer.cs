namespace AsteroidS
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var asteroidsSpawner = new AsteroidsSpawner(gameData);
            var inputInitialiser = new InputInitializer();
            var playerInitializer = new PlayerInitializer(gameData);

            controllers.Add(new SceneInitializer(gameData));
            controllers.Add(new AsteroidsController(asteroidsSpawner.GetAsteroids()));
            controllers.Add(new InputController(inputInitialiser.GetInput()));
            controllers.Add(new PlayerMovementController(gameData, playerInitializer.Player, inputInitialiser.GetInput()));
        }
    }
}
