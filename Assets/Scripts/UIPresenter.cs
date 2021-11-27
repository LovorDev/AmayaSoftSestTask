using SettingsScripts;
using TMPro;
using UnityEngine;

public class UIPresenter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _taskText, _difficultyName, _levelNumber;

    [SerializeField]
    private string _taskPrefix = "Find";

    [SerializeField]
    private string LevelNumberPrefix = "Level:";

    private int _maxLevel;
    private int _currentLevel;

    public void SetTaskText(SimpleSymbol symbol)
    {
        _taskText.text = $"{_taskPrefix} {symbol.Name}";
    }

    public void SetDifficulty(DifficultySettings difficultySettings)
    {
        _maxLevel = difficultySettings.LevelsQuantity;
        _currentLevel = 0;
        IncreaseLevel();

        _difficultyName.text = difficultySettings.DifficultyName;
    }
    
    public void IncreaseLevel()
    {
        _currentLevel++;
        _levelNumber.text = $"{LevelNumberPrefix} {_currentLevel} / {_maxLevel}";
    }
}