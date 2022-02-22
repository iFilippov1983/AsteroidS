namespace AsteroidS
{
    public sealed class GameStateController:IInitialization
    {
        private readonly DefaultStateController _defaultStateController;
        private readonly StartGameStateController _startGameController;
        private readonly SettingsStateController _settingsStateController;
        private readonly DeathStateController _deathStateController;
        private readonly ExitStateController _exitStateController;

        public GameStateController(UIInitializer uiInitializer, UIComponentInitializer uiComponentInitializer)
        {
            _defaultStateController = new DefaultStateController(uiInitializer, uiComponentInitializer.MainMenuView);
            _startGameController = new StartGameStateController(uiInitializer);
            _settingsStateController = new SettingsStateController(uiInitializer);
            _deathStateController = new DeathStateController(uiInitializer);
            _exitStateController = new ExitStateController();
        }

        public void Initialize()
        {
            _defaultStateController.Init();
            ChangeGameState(GameState.Default);
        }

        public void ChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Start:
                    _startGameController.StartGame();
                    break;
                case GameState.Settings:
                    _settingsStateController.SettingsMenu();
                    break;
                case GameState.Pause:
                    _defaultStateController.DefaultState(gameState);
                    break;
                case GameState.Death:
                    _deathStateController.DeathState();
                    break;
                case GameState.Exit:
                    _exitStateController.ExitGame();
                    break;
                case GameState.Default:
                    _defaultStateController.DefaultState(gameState);
                    break;
            }
        }

        public void SetPauseState()
        {
            ChangeGameState(GameState.Pause);
        }
    }
}