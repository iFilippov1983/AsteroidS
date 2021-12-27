using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AsteroidS
{
    public sealed class PlayerUIView:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreCounter;
        [SerializeField] private TextMeshProUGUI _timerCounter;
        [SerializeField] private List<GameObject> _playerHPList;

        public TextMeshProUGUI ScoreCount => _scoreCounter;
        public TextMeshProUGUI TimerCount => _timerCounter;
        public List<GameObject> PlayerHPList => _playerHPList;
    }
}