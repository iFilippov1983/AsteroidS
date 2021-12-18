using System;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace AsteroidS
{
    public class SettingsMenuController: IInitialization, ICleanup
    {
        private GameStateController _gameStateController;
        private SettingMenuView _settingMenuView;
        private Button _backButton;
        private Slider _volumeSlider;
        private DropdownMenu _graphicsDropdown;
        private UIComponentInitializer _uiComponentInitializer;

        //public event Action<float> OnSoundVolumeChangebackground;
        public event Action<float> OnSoundVolume;
        public event Action<int> OnGraphicsChange;

        public SettingsMenuController (UIComponentInitializer uiComponentInitializer, GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _uiComponentInitializer = uiComponentInitializer;
        }
        public void Initialize()
        {
            _settingMenuView = _uiComponentInitializer.SettingMenuView;
            GetUIComponents();
            AddListenersToComponents();
        }

        public void Cleanup()
        {
            RemoveListenersFromComponents();
        }

        private void GetUIComponents()
        {
            _backButton = _settingMenuView.BackButton;
            _volumeSlider = _settingMenuView.VolumeSlider;
            _graphicsDropdown = _settingMenuView.GraphicsDropdown;
        }

        private void AddListenersToComponents()
        {
            _backButton.onClick.AddListener(GoBackToMainMenu);
            _volumeSlider.onValueChanged.AddListener(ChangeVolumeLevel);
            //_screenResolutoionDropDown.onValueChanged.AddListener(ChangeGraphicsPreset);
        }

        private void RemoveListenersFromComponents()
        {
            _backButton.onClick.RemoveAllListeners();
            _volumeSlider.onValueChanged.RemoveAllListeners();
        }

        private void GoBackToMainMenu()
        {
            _gameStateController.ChangeGameState(GameState.Default);
        }

        private void ChangeVolumeLevel(float value)
        {
            OnSoundVolume?.Invoke(value);
        }

        private void ChangeGraphicsPreset(int value) 
        {
            OnGraphicsChange?.Invoke(value);
        }
    }
}
