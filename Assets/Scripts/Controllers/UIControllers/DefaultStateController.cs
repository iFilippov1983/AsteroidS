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
        private TextMeshProUGUI _startButtonText;
        private TextMeshProUGUI _exitButtonText;

        public DefaultStateController(UIComponentInitializer uiComponentInitializer)
        {
            _uiComponentInitializer = uiComponentInitializer;
        }

        public void Init()
        {
            _startButton = _uiComponentInitializer.StartButton.GetComponent<Button>();
            _settingsButton = _uiComponentInitializer.SettingsButton.GetComponent<Button>();
            _exitButton = _uiComponentInitializer.ExitButton.GetComponent<Button>();
            _startButtonText = _startButton.GetComponentInChildren<TextMeshProUGUI>();
            _exitButtonText = _exitButton.GetComponentInChildren<TextMeshProUGUI>();
        }

        internal void DefaultState(GameObject mainMenu, GameObject settingsMenu, GameObject playerUI, int index)
        {
            Time.timeScale = 0;
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
            playerUI.SetActive(false);
        }
        
        private void SetButtons(int index)
        {
            switch (index)
            {
                case 0:
                    _startButtonText.text = UIObjectNames.Start;
                    _exitButtonText.text = UIObjectNames.Exit;
                    _settingsButton.gameObject.SetActive(true);
                    break;
                case 1:
                    _startButtonText.text = UIObjectNames.Continue;
                    _exitButtonText.text = UIObjectNames.ToMainMenu;
                    _settingsButton.gameObject.SetActive(false);
                    break;
            }
        }
    }
}