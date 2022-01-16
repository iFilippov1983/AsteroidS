using System;
using UnityEngine.UI;

namespace AsteroidS
{
    public class AndroidPLayerUIController: IInitialization, ICleanup
    {
        private const float AmmoNumber = 1;
        private readonly GameStateController _gameStateController;
        private readonly PlayerData _playerData;
        private readonly Button _pauseButton;
        private readonly Button _switchAmmoButton;

        public event Action<float> OnAmmoSwitch;

        public AndroidPLayerUIController(UIComponentInitializer uiComponentInitializer,
            GameStateController gameStateController, GameData gameData)
        {
            _gameStateController = gameStateController;
            _playerData = gameData.PlayerData;
            _pauseButton = uiComponentInitializer.PlayerUIView.PauseButton;
            _switchAmmoButton = uiComponentInitializer.PlayerUIView.SwitchAmmoButton;
        }

        public void Initialize()
        {
            _pauseButton.onClick.AddListener(PauseGame);
            _switchAmmoButton.onClick.AddListener(SwitchAmmo);
        }

        public void Cleanup()
        {
            _pauseButton.onClick.RemoveAllListeners();
            _switchAmmoButton.onClick.RemoveAllListeners();
        }

        private void PauseGame()
        {
            _gameStateController.ChangeGameState(GameState.Pause);
        }

        private void SwitchAmmo()
        {
            OnAmmoSwitch?.Invoke(AmmoNumber);
        }
    }
}