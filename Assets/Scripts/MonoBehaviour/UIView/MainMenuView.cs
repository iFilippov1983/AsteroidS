using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace AsteroidS
{
    public sealed class MainMenuView : MonoBehaviour, IPointerEnterHandler, ISoundSource
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private TMP_Text _startButtonText;
        [SerializeField] private TMP_Text _exitButtomText;
        [SerializeField] private List<SoundSource> _soundSources = new List<SoundSource>();

        public Image BackgroundImage => _backgroundImage;
        public Button StartButton => _startButton;
        public Button SettingsButton => _settingsButton;
        public Button ExitButton => _exitButton;
        public TMP_Text StartButtonText => _startButtonText;
        public TMP_Text ExitButtonText => _exitButtomText;

        public event Action<ISoundSource> OnButtonEnter;

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnButtonEnter?.Invoke(this);
        }

        public SoundSource GetSoundSourceTypeOf(SoundType type)
        {
            return _soundSources.Find(ss => ss.type.Equals(type));
        }
    }
}
