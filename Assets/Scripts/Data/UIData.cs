using UnityEngine;

[CreateAssetMenu(menuName = "GameData/UIData", fileName = "UIData")]
public class UIData : ScriptableObject
{
    [Header("Text constance")] 
    [SerializeField]
    private string _scoreMessage = "Score:";

    [SerializeField] 
    private string _timerMessage = "Time alive:";
    
    

}
