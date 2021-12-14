using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidS
{
    public class SettingsMenuController: IInitialization, ICleanup
    {
        private GameStateController _gameStateController;
        private Button _backButton;
        private Slider _volumeSlider;
        private Dropdown _screenResolutoionDropDown;
        public event Action<float> OnSoundVolumeChangebackground;
        public event Action<float> OnSoundVolume;
        public event Action<int> OnGraphicsChange;

        public SettingsMenuController (UIComponentInitializer uIComponentInitializer, GameStateController gameStateController)
        {
            _gameStateController = gameStateController;            
        }
        public void Initialize()
        {
            _backButton = uIComponentInitializer.BackButton.GetComponent<Button>();
            _volumeSlider = uIComponentInitializer.VolumeSlider.GetComponent<Slider>();
            _screenResolutoionDropDown = uIComponentInitializer.ScreenResolutionDropdown<Dropdown>();
            _backButton.onClick.AddListener(GoBackToMainMenu);
            _volumeSlider.onValueChanged.AddListener(ChangeVolumeLevel);
            _screenResolutoionDropDown.onValueChanged.AddListener(ChangeGraphicsPreset);
        }

        public void Cleanup()
        {
            _backButton.onClick.RemoveAllListeners();
            _volumeSlider.onValueChanged.RemoveAllListners();
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
