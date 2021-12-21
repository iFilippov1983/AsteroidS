<<<<<<< HEAD
﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
=======
﻿using UnityEngine.UI;
>>>>>>> parent of 778962c4 (Merge branch 'UI_by_Nikita_M' into IvanF_work_branch2)

namespace AsteroidS
{
    public class MainMenuController: IInitialization, ICleanup
    {
<<<<<<< HEAD
        private readonly GameStateController _gameStateController;
        private readonly UIComponentInitializer _uiComponentInitializer;
        private MainMenuView _mainMenuView;
=======
        private GameStateController _gameStateController;
        private UIComponentInitializer _uiComponentInitializer;
>>>>>>> parent of 778962c4 (Merge branch 'UI_by_Nikita_M' into IvanF_work_branch2)
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
            _gameStateController.ChangeGameState(GameState.Exit);
        }
    }
}