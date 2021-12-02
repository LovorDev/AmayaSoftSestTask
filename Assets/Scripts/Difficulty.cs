using System;
using System.Collections.Generic;
using SettingsScripts;
using UnityEngine;
using UnityEngine.Events;

public class Difficulty : MonoBehaviour
{
    [SerializeField]
    private List<DifficultySettings> _difficultyList;

    private int _currentDifficultyIndex = -1;

    [Serializable]
    public class IncreaseLevelEvent : UnityEvent<DifficultySettings>
    {
    }

    [Serializable]
    public class WinGameEvent : UnityEvent
    {
    }

    [SerializeField]
    private IncreaseLevelEvent _increaseDifficulty;

    [SerializeField]
    private WinGameEvent _winGame;

    public DifficultySettings CurrentDifficulty => _difficultyList[_currentDifficultyIndex];

    private void Start()
    {
        IncreaseLevel();
    }

    public void IncreaseLevel()
    {
        _currentDifficultyIndex++;

        if (_currentDifficultyIndex >= _difficultyList.Count)

            _winGame?.Invoke();

        else
            _increaseDifficulty?.Invoke(CurrentDifficulty);
    }
}