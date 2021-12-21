using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    public class MainMenuController: IInitialization, ICleanup
    {
        private readonly GameStateController _gameStateController;
        private readonly UIComponentInitializer _uiComponentInitializer;
        private MainMenuView _mainMenuView;
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
            _mainMenuView = _uiComponentInitializer.MainMenuView;
            GetUIComponents();
            AddListenerToComponents();
        }

        public void Cleanup()
        {
            RemoveListenersFromComponents();
        }

        private void GetUIComponents()
        {
            _startButton = _mainMenuView.StartButton;
            _settingsButton = _mainMenuView.SettingsButton;
            _exitButton = _mainMenuView.ExitButton;
            _exitButtonText = _mainMenuView.ExitButtonText;
        }

        private void AddListenerToComponents()
        {
            _startButton.onClick.AddListener(ChangeStateToStart);
            _settingsButton.onClick.AddListener(ChangeStateToSettings);
            _exitButton.onClick.AddListener(ChangeStateToExit);
        }

        private void RemoveListenersFromComponents()
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
                _gameStateController.ChangeGameState(GameState.Exit);
            }
            else
            {
                _gameStateController.ChangeGameState(GameState.Default);
            }
        }
    }
}