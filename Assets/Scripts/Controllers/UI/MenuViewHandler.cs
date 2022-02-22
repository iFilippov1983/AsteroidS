using System;

namespace AsteroidS
{
    public sealed class MenuViewHandler : IInitialization, ICleanup, ISoundEventSource
    {
        private readonly UIComponentInitializer _uiComponentInitializer;
        private MainMenuView _mainMenuView;
        private DeathScreenView _deathScreenView;
        private SettingMenuView _settingMenuView;

        public event Action<SoundSource> OnSoundEvent;

        public MenuViewHandler(UIComponentInitializer uiComponentInitializer)
        {
            _uiComponentInitializer = uiComponentInitializer;
            SoundEventSourceOperator.Add(this);
        }

        public void Initialize()
        {
            GetUIComponents();
            AddSubscriptions();
        }

        public void Cleanup()
        {
            RemoveSubscriptions();
        }

        private void GetUIComponents()
        {
            _mainMenuView = _uiComponentInitializer.MainMenuView;
            _settingMenuView = _uiComponentInitializer.SettingMenuView;
            _deathScreenView = _uiComponentInitializer.DeathScreenView;
        }

        private void AddSubscriptions()
        {
            _mainMenuView.OnButtonEnter += ButtonSelected;
            _settingMenuView.OnButtonEnter += ButtonSelected;
            _deathScreenView.OnButtonEnter += ButtonSelected;
        }

        private void RemoveSubscriptions()
        {
            _mainMenuView.OnButtonEnter -= ButtonSelected;
            _settingMenuView.OnButtonEnter -= ButtonSelected;
            _deathScreenView.OnButtonEnter -= ButtonSelected;
        }

        private void ButtonSelected(ISoundSource source)
        {
            OnSoundEvent?.Invoke(source.GetSoundSourceTypeOf(SoundType.ButtonEnter));
        }
    }
}