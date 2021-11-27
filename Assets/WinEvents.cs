using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WinEvents : MonoBehaviour
{
    [Serializable]
    public class WinEventsDoneEvent : UnityEvent { }

    [Serializable]
    public class StartWinningEvents : UnityEvent { }


    [SerializeField]
    private float _nextDifficultyDelay;

    [SerializeField]
    private WinEventsDoneEvent _winEventsDone;


    [SerializeField]
    private StartWinningEvents _startWinning;

    public void StartWinning()
    {
        _startWinning?.Invoke();
        StartCoroutine(WinningEventsDelay());
    }

    private IEnumerator WinningEventsDelay()
    {
        yield return new WaitForSeconds(_nextDifficultyDelay);
        _winEventsDone?.Invoke();
    }
}