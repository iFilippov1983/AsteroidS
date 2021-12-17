using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    public class MainMenuController: IInitialization, ICleanup
    {
        private readonly GameStateController _gameStateController;
        private readonly UIComponentInitializer _uiComponentInitializer;
        private Button _startButton;
        private Button _settingsButton;
        private Button _exitButton;
        private TMP_Text _exitButtonText;

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
            _exitButtonText = _exitButton.GetComponentInChildren<TMP_Text>();
            _startButton.onClick.AddListener(ChangeStateToStart);
            _settingsButton.onClick.AddListener(ChangeStateToSettings);
            _exitButton.onClick.AddListener(ChangeStateToExit);
        }

        public void Cleanup()
        {
            _startButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }

        private void ChangeStateToStart()
        {
            _gameStateController.ChangeGameState(GameState.Start);
        }

        private void ChangeStateToSettings() 
        {
            _gameStateController.ChangeGameState(GameState.Settings);
        }

        private void ChangeStateToExit() 
        {
            if (_exitButtonText.text == UIObjectNames.Exit)
            {
                Debug.Log("Exit");
                _gameStateController.ChangeGameState(GameState.Exit);
            }
            else
            {
                Debug.Log("MainMenu");
                _gameStateController.ChangeGameState(GameState.Default);
            }
        }
    }
}