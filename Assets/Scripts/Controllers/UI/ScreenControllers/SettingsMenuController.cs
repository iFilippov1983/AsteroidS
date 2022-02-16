using System;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace AsteroidS
{
    public sealed class SettingsMenuController: MenuStateController
    {
        //private readonly GameStateController _gameStateController;
        private SettingMenuView _settingMenuView;

        private Button _backButton;
        private Slider _volumeSlider;
        private DropdownMenu _graphicsDropdown;
        //private UIComponentInitializer _uiComponentInitializer;

        public event Action<float> OnSoundVolume;
        public event Action<int> OnGraphicsChange;

        //public SettingsMenuController (UIComponentInitializer uiComponentInitializer)
        //    : base(uiComponentInitializer) //, GameStateController gameStateController)
        public SettingsMenuController(SettingMenuView settingMenuView)
        {
            _settingMenuView = settingMenuView;
            //_settingMenuView = _uiComponentInitializer.SettingMenuView;
            //_gameStateController = gameStateController;
            //_uiComponentInitializer = uiComponentInitializer;
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
            //_screenResolutoionDropDown.onValueChanged.AddListener(ChangeGraphicsPreset);
        }

        private void RemoveListenersFromComponents()
        {
            _backButton.onClick.RemoveAllListeners();
            _volumeSlider.onValueChanged.RemoveAllListeners();
        }

        private void GoBackToMainMenu()
        {
            StateChanged?.Invoke(GameState.Default);
            //_gameStateController.ChangeGameState(GameState.Default);
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
