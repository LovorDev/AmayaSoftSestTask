using System;
using System.Collections.Generic;
using System.Linq;
using SettingsScripts;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[Serializable]
public struct SimpleSymbol
{
    [field: SerializeField]
    public Sprite Sprite { get; private set; }

    [field: SerializeField]
    public string Name { get; private set; }
}

public class SymbolsManager : MonoBehaviour
{
    #region EventsClasses
    [Serializable]
    public class AlphabetUpdatedEvent : UnityEvent<List<SimpleSymbol>>
    {
    }

    [Serializable]
    public class AvailableSymbolsUpdatedEvent : UnityEvent<List<SimpleSymbol>>
    {
    }

    [Serializable]
    public class TaskSymbolUpdateEvent : UnityEvent<SimpleSymbol>
    {
    }
    

    #endregion


    #region SerializeFields

    [SerializeField]
    private List<AlphabetData> _alphabetDatas;

    private List<SimpleSymbol> Alphabet { get; set; }

    [SerializeField]
    private AlphabetUpdatedEvent _alphabetUpdated;


    [SerializeField]
    private AvailableSymbolsUpdatedEvent _availableSymbolsUpdated;

    [SerializeField]
    private TaskSymbolUpdateEvent _taskSymbolUpdate;
    

    #endregion

    private int _availableSymbolsQuantity;
    private List<SimpleSymbol> _bannedSymbols;

    private void Awake()
    {
        UpdateAlphabet(_alphabetDatas[Random.Range(0, _alphabetDatas.Count)].Alphabet);
    }

    private void UpdateAlphabet(List<SimpleSymbol> alphabet)
    {
        Alphabet = new List<SimpleSymbol>(alphabet);
        _bannedSymbols = new List<SimpleSymbol>();
        _alphabetUpdated?.Invoke(Alphabet);
    }

    public void OnLevelIncrease(DifficultySettings difficulty)
    {
        _availableSymbolsQuantity = (int)(difficulty.CellsGrid.x * difficulty.CellsGrid.y);

        UpdateAvailableSymbols();
    }

    public void UpdateAvailableSymbols()
    {
        if (_bannedSymbols.Count >= Alphabet.Count)
            throw new Exception("The number of available symbols is less than the number of banned symbols");

        RandomAvailableSymbols randomAvailableSymbols = new RandomAvailableSymbols();

        var symbols = randomAvailableSymbols.Get(Alphabet, _availableSymbolsQuantity);

        SimpleSymbol randomTaskSymbol;
        while (GenerateRandomTaskSymbol(symbols, out randomTaskSymbol) == false)
        {
            symbols = randomAvailableSymbols.Get(Alphabet, _availableSymbolsQuantity);
        }

        _availableSymbolsUpdated?.Invoke(symbols);
        UpdateTaskSymbol(randomTaskSymbol);
    }

    private bool GenerateRandomTaskSymbol(List<SimpleSymbol> symbols, out SimpleSymbol randomSymbol)
    {
        var simpleSymbols = new List<SimpleSymbol>(symbols).Except(_bannedSymbols).ToList();
        if (simpleSymbols.Count == 0)
        {
            randomSymbol = default;
            return false;
        }

        randomSymbol = simpleSymbols[Random.Range(0, simpleSymbols.Count)];
        _bannedSymbols.Add(randomSymbol);
        return true;
    }


    private void UpdateTaskSymbol(SimpleSymbol symbol)
    {
        _taskSymbolUpdate?.Invoke(symbol);
    }
}