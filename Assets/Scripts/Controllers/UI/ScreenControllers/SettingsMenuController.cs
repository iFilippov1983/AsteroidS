using System;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace AsteroidS
{
    public sealed class SettingsMenuController: MenuStateController
    {
        private SettingMenuView _settingMenuView;

        private Button _backButton;
        private Slider _volumeSlider;
        private DropdownMenu _graphicsDropdown;

        public event Action<float> OnSoundVolume;
        public event Action<int> OnGraphicsChange;

        public SettingsMenuController(SettingMenuView settingMenuView)
        {
            _settingMenuView = settingMenuView;
        }
        public override void Initialize()
        {
            GetUIComponents();
            AddListenersToComponents();
        }

        public override void Cleanup()
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
        }

        private void RemoveListenersFromComponents()
        {
            _backButton.onClick.RemoveAllListeners();
            _volumeSlider.onValueChanged.RemoveAllListeners();
        }

        private void GoBackToMainMenu()
        {
            StateChanged?.Invoke(GameState.Default);
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
