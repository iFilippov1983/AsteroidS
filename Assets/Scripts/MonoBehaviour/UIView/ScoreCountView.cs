using TMPro;
using UnityEngine;

public class ScoreCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCount;

    public TextMeshProUGUI ScoreCount => _scoreCount;
}
