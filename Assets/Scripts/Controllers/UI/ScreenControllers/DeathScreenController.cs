using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AsteroidS
{
    public sealed class DeathScreenController : MenuStateController
    {
        private readonly string _thisSceneName;
        private DeathScreenView _deathScreenView;

        private Button _continueButton;
        private Button _restartButton;
        private Button _mainMenuButton;

        public DeathScreenController(DeathScreenView deathScreenView, string sceneName)
        {
            _deathScreenView = deathScreenView;
            _thisSceneName = sceneName;
        }

        public override void Initialize()
        {
            GetUIComponents();
            AddListenersToComponents();
            ToMainMenu();
        }

        public override void Cleanup()
        {
            RemoveListenersFromComponents();
        }

        private void GetUIComponents()
        {
            _continueButton = _deathScreenView.ContinueButton;
            _restartButton = _deathScreenView.RestartButton;
            _mainMenuButton = _deathScreenView.MainMenuButton;
        }

        private void AddListenersToComponents()
        {
            _continueButton.onClick.AddListener(ContinueGame);
            _restartButton.onClick.AddListener(ResetGame);
            _mainMenuButton.onClick.AddListener(ToMainMenu);
        }

        private void RemoveListenersFromComponents()
        {
            _continueButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
            _mainMenuButton.onClick.RemoveAllListeners();
        }

        private void ContinueGame()
        {
            StateChanged?.Invoke(GameState.Start);
        }

        private void ResetGame()
        {
            SceneManager.LoadScene(_thisSceneName);
        }

        private void ToMainMenu()
        {
            StateChanged?.Invoke(GameState.Default);
        }
    }
}