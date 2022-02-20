using System;

namespace AsteroidS
{
    public sealed class MenuManagementController
    {
        private readonly MainMenuController _mainMenuController;
        private readonly SettingsMenuController _settingsMenuController;
        private readonly DeathScreenController _deathScreenController;

        public SettingsMenuController SettingsMenuController => _settingsMenuController;

        public Action<GameState> MenuStateChangeAction;

        public MenuManagementController(SceneData sceneData, UIComponentInitializer uIComponentInitializer)
        {
            _mainMenuController = new MainMenuController(uIComponentInitializer.MainMenuView);
            _settingsMenuController = new SettingsMenuController(uIComponentInitializer.SettingMenuView);
            _deathScreenController = new DeathScreenController(uIComponentInitializer.DeathScreenView, sceneData.ThisSceneName);
        }

        public void Initialize()
        {
            _mainMenuController.Initialize();
            _settingsMenuController.Initialize();
            _deathScreenController.Initialize();

            _mainMenuController.StateChanged += MenuStateChanged;
            _settingsMenuController.StateChanged += MenuStateChanged;
            _deathScreenController.StateChanged += MenuStateChanged;
        }

        public void Cleanup()
        {
            _mainMenuController.Cleanup();
            _settingsMenuController.Cleanup();
            _deathScreenController.Cleanup();

            _mainMenuController.StateChanged -= MenuStateChanged;
            _settingsMenuController.StateChanged -= MenuStateChanged;
            _deathScreenController.StateChanged -= MenuStateChanged;
        }

        private void MenuStateChanged(GameState state)
        {
            MenuStateChangeAction?.Invoke(state);
        }
    }
}
