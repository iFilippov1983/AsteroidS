using UnityEngine.UI;

namespace AsteroidS
{
    public class MainMenuController: IInitialization, ICleanup
    {
        private GameStateController _gameStateController;
        private UIComponentInitializer _uiComponentInitializer;
        private Button _startButton;
        private Button _settingsButton;
        private Button _exitButton;
        
        public MainMenuController(UIComponentInitializer uiComponentInitializer, GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _uiComponentInitializer = uiComponentInitializer;
        }

        public void Initialize()
        {
            _startButton = _uiComponentInitializer.StartButton.GetComponent<Button>();
            _settingsButton = _uiComponentInitializer.SettingsButton.GetComponent<Button>();
            _exitButton = _uiComponentInitializer.ExitButton.GetComponent<Button>();
            _startButton.onClick.AddListener(ChangeStateToStart);
        }

        public void Cleanup()
        {
            _startButton.onClick.RemoveAllListeners();
        }

        private void ChangeStateToStart()
        {
            _gameStateController.ChangeGameState(GameState.Start);
        }
    }
}