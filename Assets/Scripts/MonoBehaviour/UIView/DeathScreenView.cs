using UnityEngine;
using UnityEngine.UI;

public class DeathScreenView : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;


    public Image BackgroundImage => _backgroundImage;
    public Button ContinueButton => _continueButton;
    public Button RestartButton => _restartButton;
    public Button MainMenuButton => _mainMenuButton;
}
