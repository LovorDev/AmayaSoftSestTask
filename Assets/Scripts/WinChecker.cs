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

    
    public void CheckWin()
    {
        _completeAllLevels?.Invoke();
    }
}