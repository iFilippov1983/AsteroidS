﻿using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

namespace AsteroidS
{
    public class SettingMenuView:MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private DropdownMenu _graphicsDropdown;

        public Image BackgroundImage => _backgroundImage;
        public Button BackButton => _backButton;
        public Slider VolumeSlider => _volumeSlider;
        public DropdownMenu GraphicsDropdown => _graphicsDropdown;
    }
}