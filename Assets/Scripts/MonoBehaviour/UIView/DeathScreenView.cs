using UnityEngine;
using UnityEngine.UI;

public class DeathScreenView : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    public Button ContinueButton => _continueButton;
    public Button RestartButton => _restartButton;
    public Button MainMenuButton => _mainMenuButton;
}
