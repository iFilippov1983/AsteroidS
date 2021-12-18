using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    internal class DefaultStateController
    {
        private readonly UIComponentInitializer _uiComponentInitializer;
        
        private Button _startButton;
        private Button _settingsButton;
        private Button _exitButton;
        private TMP_Text _startButtonText;
        private TMP_Text _exitButtonText;

        public DefaultStateController(UIComponentInitializer uiComponentInitializer)
        {
            _uiComponentInitializer = uiComponentInitializer;
        }

        public void Init()
        {
            GetUIComponents();
        }

        internal void DefaultState(GameObject mainMenu, GameObject settingsMenu, GameObject playerUI, GameObject deathScreen, GameState gameState)
        {
            Time.timeScale = 0;
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
            playerUI.SetActive(false);
            deathScreen.SetActive(false);
            SetButtons(gameState);
        }

        private void GetUIComponents()
        {
            _startButton = _uiComponentInitializer.StartButton.GetComponent<Button>();
            _settingsButton = _uiComponentInitializer.SettingsButton.GetComponent<Button>();
            _exitButton = _uiComponentInitializer.ExitButton.GetComponent<Button>();

            _startButtonText = _startButton.gameObject.GetComponentInChildren<TMP_Text>();
            _exitButtonText = _exitButton.gameObject.GetComponentInChildren<TMP_Text>();
        }

        private void SetButtons(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Default:
                    _startButtonText.text = UIObjectNames.Start;
                    _exitButtonText.text = UIObjectNames.Exit;
                    _settingsButton.gameObject.SetActive(true);
                    break;
                case GameState.Pause:
                    _startButtonText.text = UIObjectNames.Continue;
                    _exitButtonText.text = UIObjectNames.ToMainMenu;
                    _settingsButton.gameObject.SetActive(false);
                    break;
            }
        }
    }
}