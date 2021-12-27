using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class DeathScreenView : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;


    public Image BackgroundImage => _backgroundImage;
    public Button ContinueButton => _continueButton;
    public Button RestartButton => _restartButton;
    public Button MainMenuButton => _mainMenuButton;
    public event Action OnButtonEnter; 
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnButtonEnter?.Invoke();
    }
}
