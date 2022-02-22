using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AsteroidS
{
    public sealed class DeathScreenView : MonoBehaviour, IPointerEnterHandler, ISoundSource
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private List<SoundSource> _soundSources = new List<SoundSource>();

        public Image BackgroundImage => _backgroundImage;
        public Button ContinueButton => _continueButton;
        public Button RestartButton => _restartButton;
        public Button MainMenuButton => _mainMenuButton;
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
