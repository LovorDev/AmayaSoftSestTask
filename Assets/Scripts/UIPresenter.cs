using SettingsScripts;
using TMPro;
using UnityEngine;

public class UIPresenter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _taskText, _difficultyName, _levelNumber;

    [SerializeField]
    private string _taskPrefix = "Find";
    
    public void SetTaskText(SimpleSymbol symbol)
    {
        _taskText.text = $"{_taskPrefix} {symbol.Name}";
    }

    public void SetDifficulty(DifficultySettings difficultySettings)
    {
        _difficultyName.text = difficultySettings.DifficultyName;
    }
    
}