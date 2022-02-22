using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

namespace AsteroidS
{
    public sealed class SettingMenuView:MonoBehaviour, IPointerEnterHandler, ISoundSource
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private DropdownMenu _graphicsDropdown;
        [SerializeField] private List<SoundSource> _soundSources = new List<SoundSource>();

        public Image BackgroundImage => _backgroundImage;
        public Button BackButton => _backButton;
        public Slider VolumeSlider => _volumeSlider;
        public DropdownMenu GraphicsDropdown => _graphicsDropdown;

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