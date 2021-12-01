using TMPro;
using UnityEngine;

public class UIRootView : MonoBehaviour
{
    [Header("Path to the prefab")] [SerializeField]
    private string _path;
    
    [Header("Text Displays")]
    [SerializeField][Tooltip("Drag&Drop here score count")]
    private ScoreCountView _scoreCount;

    [SerializeField] [Tooltip("Drag&Drop here timer count")]
    private TimerCountView _timer;

    public string PathToThePrefab => _path;
    public ScoreCountView ScoreCount => _scoreCount;
    public TimerCountView Timer => _timer;
}
