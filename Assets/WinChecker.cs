using System;
using UnityEngine;
using UnityEngine.Events;

public class WinChecker : MonoBehaviour
{
    [SerializeField]
    private Difficulty _difficulty;

    [Serializable]
    public class WinLevelEvent : UnityEvent
    {
    }    
    [Serializable]
    public class NotWinningEvent : UnityEvent
    {
    }

    [SerializeField]
    private WinLevelEvent _completeAllLevels;

    [SerializeField]
    private NotWinningEvent _completeOneLevels;

    private int _currentLevelsCompleted;


    public void CheckWin()
    {
        _currentLevelsCompleted++;

        if (_currentLevelsCompleted < _difficulty.CurrentDifficulty.LevelsQuantity) {_completeOneLevels?.Invoke(); return;}
        
        _currentLevelsCompleted = 0;
        _completeAllLevels?.Invoke();
    }
}