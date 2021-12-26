using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class MainMenuView : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _startButtonText;
    [SerializeField] private TMP_Text _exitButtomText;

    public Image BackgroundImage => _backgroundImage;
    public Button StartButton => _startButton;
    public Button SettingsButton => _settingsButton;
    public Button ExitButton => _exitButton;
    public TMP_Text StartButtonText => _startButtonText;
    public TMP_Text ExitButtonText => _exitButtomText;

    public event Action OnButtonEnter;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnButtonEnter?.Invoke();
    }
}
