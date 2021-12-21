namespace AsteroidS
{
    public class MenuManagmentController:IInitialization, ICleanup
    {
        private MainMenuController _mainMenuController;
        private SettingsMenuController _settingsMenuController;

        public SettingsMenuController SettingsMenuController => _settingsMenuController;

        public MenuManagmentController(UIComponentInitializer uIComponentInitializer, GameStateController gameStateController) 
        {
            _mainMenuController = new MainMenuController(uIComponentInitializer, gameStateController);
            _settingsMenuController = new SettingsMenuController(uIComponentInitializer, gameStateController);
        }

        public void Initialize()
        {
            _mainMenuController.Initialize();
            _settingsMenuController.Initialize();
        }

        public void Cleanup()
        {
            _mainMenuController.Cleanup();
            _settingsMenuController.Cleanup();
        }
    }
}
