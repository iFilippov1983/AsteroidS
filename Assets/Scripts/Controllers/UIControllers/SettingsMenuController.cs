using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AsteroidS
{
    public class SettingsMenuController: IInitialization, ICleanup
    {
        private GameStateController _gameStateController;
        private Button _backButton;
        private Slider _volumeSlider;
        private Dropdown _screenResolutoionDropDown;
        private UIComponentInitializer _uiComponentInitializer;

        public event Action<float> OnSoundVolumeChangebackground;
        public event Action<float> OnSoundVolume;
        public event Action<int> OnGraphicsChange;

        public SettingsMenuController (UIComponentInitializer uiComponentInitializer, GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _uiComponentInitializer = uiComponentInitializer;
        }
        public void Initialize()
        {
            _backButton = _uiComponentInitializer.BackButton.GetComponent<Button>();
            _volumeSlider = _uiComponentInitializer.VolumeSlider.GetComponent<Slider>();
            //_screenResolutoionDropDown = _uiComponentInitializer.ScreenResolutionDropdown<Dropdown>();
            _backButton.onClick.AddListener(GoBackToMainMenu);
            //_volumeSlider.onValueChanged.AddListener(ChangeVolumeLevel());
            //_screenResolutoionDropDown.onValueChanged.AddListener(ChangeGraphicsPreset());
        }

        public void Cleanup()
        {
            _backButton.onClick.RemoveAllListeners();
            _volumeSlider.onValueChanged.RemoveAllListeners();
        }

        private void GoBackToMainMenu()
        {
            _gameStateController.ChangeGameState(GameState.Default);
        }

        private void ChangeVolumeLevel()
        {
            OnSoundVolume?.Invoke(_volumeSlider.value);
        }

        private void ChangeGraphicsPreset() 
        {
            OnGraphicsChange?.Invoke(_screenResolutoionDropDown.value);
        }
    }
}
