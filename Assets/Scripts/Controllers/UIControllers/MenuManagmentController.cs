﻿
namespace AsteroidS
{
    public sealed class MenuManagmentController:IInitialization, ICleanup
    {
        private readonly MainMenuController _mainMenuController;
        private readonly SettingsMenuController _settingsMenuController;

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

        public SettingsMenuController SettingsMenuController => _settingsMenuController;
    }
}
