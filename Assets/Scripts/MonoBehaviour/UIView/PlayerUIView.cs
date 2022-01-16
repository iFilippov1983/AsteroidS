using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidS
{
    public sealed class PlayerUIView:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreCounter;
        [SerializeField] private TextMeshProUGUI _timerCounter;
        [SerializeField] private List<GameObject> _playerHPList;
#if UNITY_ANDROID
        [SerializeField] private FloatingJoystick _movementJoystick;
        [SerializeField] private FloatingJoystick _targetingJoystick;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _switchAmmoButton;
#endif
        public TextMeshProUGUI ScoreCount => _scoreCounter;
        public TextMeshProUGUI TimerCount => _timerCounter;
        public List<GameObject> PlayerHPList => _playerHPList;
#if UNITY_ANDROID
        public FloatingJoystick MovementJoystick => _movementJoystick;
        public FloatingJoystick TargetingJoystic => _targetingJoystick;
        public Button PauseButton => _pauseButton;
        public Button SwitchAmmoButton => _switchAmmoButton;
#endif
    }
}