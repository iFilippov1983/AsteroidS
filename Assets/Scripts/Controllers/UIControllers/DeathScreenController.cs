using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AsteroidS
{
    public class DeathScreenController:IInitialization, ICleanup
    {
        private readonly GameData _gameData;
        private readonly UIComponentInitializer _uiComponentInitializer;
        private readonly GameStateController _gameStateController;
        private DeathScreenView _deathScreenView;

        private Button _continueButton;
        private Button _restartButton;
        private Button _mainMenuButton;

        public DeathScreenController(GameData gameData, UIComponentInitializer uiComponentInitializer,
            GameStateController gameStateController)
        {
            _gameData = gameData;
            _uiComponentInitializer = uiComponentInitializer;
            _gameStateController = gameStateController;
        }


        public void Initialize()
        {
            _deathScreenView = _uiComponentInitializer.DeathScreenView;
            GetUIComponents();
            AddListenersToComponents();
        }

        public void Cleanup()
        {
            RemoveListenersFromComponents();
        }

        private void GetUIComponents()
        {
            _continueButton = _deathScreenView.ContinueButton;
            _restartButton = _deathScreenView.RestartButton;
            _mainMenuButton = _deathScreenView.MainMenuButton;
        }

        private void AddListenersToComponents()
        {
            _continueButton.onClick.AddListener(ContinueGame);
            _restartButton.onClick.AddListener(ResetGame);
            _mainMenuButton.onClick.AddListener(ReturnToMenu);
        }

        private void RemoveListenersFromComponents()
        {
            _continueButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
            _mainMenuButton.onClick.RemoveAllListeners();
        }

        private void ContinueGame()
        {
            _gameStateController.ChangeGameState(GameState.Start);
        }

        private void ResetGame()
        {
            SceneManager.LoadScene(_gameData.SceneData.SceneName);
        }

        private void ReturnToMenu()
        {
            _gameStateController.ChangeGameState(GameState.Default);
        }
    }
}