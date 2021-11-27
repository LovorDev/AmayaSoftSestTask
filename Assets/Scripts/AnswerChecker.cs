using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnswerChecker : MonoBehaviour
{
    [Serializable]
    public class TapOnRightSymbolEvent : UnityEvent
    {
    }    
    [Serializable]
    public class TapOnWrongSymbolEvent : UnityEvent
    {
    }

    [SerializeField]
    private TapOnRightSymbolEvent _tapOnRightSymbol;

    [SerializeField]
    private TapOnWrongSymbolEvent _tapOnWrongSymbolEvent;

    
    
    public List<SimpleSymbol> AvailableSymbols { get; private set; }

    private SimpleSymbol _taskSymbol;

    public void OnUpdateAvailableSymbols(List<SimpleSymbol> availableSymbols)
    {
        AvailableSymbols = availableSymbols;
    }

    public void SetTaskSymbol(SimpleSymbol simpleSymbol)
    {
        _taskSymbol = simpleSymbol;
    }

    public bool CheckSymbol(SimpleSymbol simpleSymbol)
    {
        if (simpleSymbol.Name == _taskSymbol.Name)
        {
            _tapOnRightSymbol?.Invoke();
            return true;
        }
        _tapOnWrongSymbolEvent?.Invoke();
        return false;
    }
}