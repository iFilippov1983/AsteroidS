namespace AsteroidS
{
    public sealed class MenuManagmentController:IInitialization, ICleanup
    {
        private readonly MainMenuController _mainMenuController;
        private readonly SettingsMenuController _settingsMenuController;
        private readonly DeathScreenController _deathScreenController;
        

        public SettingsMenuController SettingsMenuController => _settingsMenuController;

        public MenuManagmentController(GameData gameData, UIComponentInitializer uIComponentInitializer, GameStateController gameStateController) 
        {
            _mainMenuController = new MainMenuController(uIComponentInitializer, gameStateController);
            _settingsMenuController = new SettingsMenuController(uIComponentInitializer, gameStateController);
            _deathScreenController = new DeathScreenController(gameData, uIComponentInitializer, gameStateController);
        }

        public void Initialize()
        {
            _mainMenuController.Initialize();
            _settingsMenuController.Initialize();
            _deathScreenController.Initialize();
        }

        public void Cleanup()
        {
            _mainMenuController.Cleanup();
            _settingsMenuController.Cleanup();
            _deathScreenController.Cleanup();
        }
    }
}
