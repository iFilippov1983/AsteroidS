using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Button = UnityEngine.UI.Button;

namespace AsteroidS
{
    public sealed class MainMenuController : MenuStateController, IPointerEnterHandler
    {
        private readonly MainMenuView _mainMenuView;

        private Button _startButton;
        private Button _settingsButton;
        private Button _exitButton;
        private TMP_Text _exitButtonText;

        public MainMenuController(MainMenuView mainMenuView)
        {
            _mainMenuView = mainMenuView;
        }

        public override void Initialize()
        {
            GetUIComponents();
            AddListenerToComponents();
        }

        public override void Cleanup()
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
            StateChanged?.Invoke(GameState.Start);
            //_gameStateController.ChangeGameState(GameState.Start);
        }

        private void ChangeStateToSettings() 
        {
            StateChanged?.Invoke(GameState.Settings);
        }

        private void ChangeStateToExit() 
        {
            if (_exitButtonText.text == UIObjectName.Exit)
            {
                StateChanged?.Invoke(GameState.Exit);
            }
            else
            {
                StateChanged?.Invoke(GameState.Default);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("hi");
        }
    }
}