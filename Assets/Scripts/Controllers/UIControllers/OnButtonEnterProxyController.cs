using System;

namespace AsteroidS
{
    public class OnButtonEnterProxyController : IInitialization, ICleanup
    {
        private readonly UIComponentInitializer _uiComponentInitializer;
        private MainMenuView _mainMenuView;
        private DeathScreenView _deathScreenView;
        private SettingMenuView _settingMenuView;

        public event Action OnButtonSelected;

        public OnButtonEnterProxyController(UIComponentInitializer uiComponentInitializer)
        {
            _uiComponentInitializer = uiComponentInitializer;
            
        }

        public void Initialize()
        {
            GetUIComponents();
            _mainMenuView.OnButtonEnter += OnButtonSelected;
            _settingMenuView.OnButtonEnter += OnButtonSelected;
            _deathScreenView.OnButtonEnter += OnButtonSelected;
        }

        private void GetUIComponents()
        {
            _mainMenuView = _uiComponentInitializer.MainMenuView;
            _settingMenuView = _uiComponentInitializer.SettingMenuView;
            _deathScreenView = _uiComponentInitializer.DeathScreenView;
        }

        public void Cleanup()
        {
            _mainMenuView.OnButtonEnter -= OnButtonSelected;
            _settingMenuView.OnButtonEnter -= OnButtonSelected;
            _deathScreenView.OnButtonEnter -= OnButtonSelected;
        }
    }
}