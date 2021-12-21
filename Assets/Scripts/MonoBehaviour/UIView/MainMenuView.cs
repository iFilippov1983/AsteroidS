using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _startButtonText;
    [SerializeField] private TMP_Text _exitButtomText;

    public Button StartButton => _startButton;
    public Button SettingsButton => _settingsButton;
    public Button ExitButton => _exitButton;
    public TMP_Text StartButtonText => _startButtonText;
    public TMP_Text ExitButtonText => _exitButtomText;
}
