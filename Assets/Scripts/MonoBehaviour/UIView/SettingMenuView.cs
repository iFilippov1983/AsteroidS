using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace AsteroidS
{
    public class SettingMenuView:MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private DropdownMenu _graphicsDropdown;

        public Button BackButton => _backButton;
        public Slider VolumeSlider => _volumeSlider;
        public DropdownMenu GraphicsDropdown => _graphicsDropdown;
    }
}