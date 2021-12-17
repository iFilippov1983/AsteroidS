using UnityEngine.UI;

namespace AsteroidS
{
    public class PauseMenuController: IInitialization, ICleanup
    {
        private readonly GameStateController _gameStateController;
        private readonly UIComponentInitializer _uiComponentInitializer;

        private Button _startButton;
        private Button _exitButton;

        public PauseMenuController(GameStateController gameStateController,
            UIComponentInitializer uiComponentInitializer)
        {
            _gameStateController = gameStateController;
            _uiComponentInitializer = uiComponentInitializer;
        }
        
        public void Initialize()
        {
            _startButton = _uiComponentInitializer.StartButton.GetComponent<Button>();
            _exitButton = _uiComponentInitializer.ExitButton.GetComponent<Button>();
            _startButton.onClick.AddListener(ContinueGame);
            _exitButton.onClick.AddListener(BackToMenu);
        }

        public void Cleanup()
        {
            _startButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }

        private void BackToMenu()
        {
            _gameStateController.ChangeGameState(GameState.Default);
        }

        private void ContinueGame()
        {
            _gameStateController.ChangeGameState(GameState.Start);
        }
    }
}