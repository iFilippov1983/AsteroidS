
namespace AsteroidS
{
    public sealed class MenuManagmentController:IInitialization, ICleanup
    {
        private readonly MainMenuController _mainMenuController;
        private readonly SettingsMenuController _settingsMenuController;
        private readonly PauseMenuController _pauseMenuController;

        public SettingsMenuController SettingsMenuController => _settingsMenuController;

        public MenuManagmentController(UIComponentInitializer uIComponentInitializer, GameStateController gameStateController) 
        {
            _mainMenuController = new MainMenuController(uIComponentInitializer, gameStateController);
            _settingsMenuController = new SettingsMenuController(uIComponentInitializer, gameStateController);
            _pauseMenuController = new PauseMenuController(gameStateController, uIComponentInitializer);
        }

        public void Initialize()
        {
            _mainMenuController.Initialize();
            _settingsMenuController.Initialize();
            _pauseMenuController.Initialize();
        }

        public void Cleanup()
        {
            _mainMenuController.Cleanup();
            _settingsMenuController.Cleanup();
            _pauseMenuController.Cleanup();
        }

        public MainMenuController MenuController => _mainMenuController;
    }
}
