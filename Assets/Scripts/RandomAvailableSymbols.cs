using System.Collections.Generic;
using UnityEngine;

public class RandomAvailableSymbols
{
    public List<SimpleSymbol> Get(List<SimpleSymbol> alphabet, int quantity)
    {
        var indexes = RandomSymbols(alphabet, quantity);

        return (List<SimpleSymbol>)indexes;
    }

    private IList<T> RandomSymbols<T>(IEnumerable<T> list, int quantity)
    {
        var shuffledSymbols = new List<T>(list);
        for (var i = 2; i < shuffledSymbols.Count; i++)
        {
            var temp = shuffledSymbols[i];
            var nextRandom = Random.Range(0, i - 1);
            shuffledSymbols[i] = shuffledSymbols[nextRandom];
            shuffledSymbols[nextRandom] = temp;
        }

        var trimmedIndexes = new List<T>();

        for (int i = 0; i < quantity; i++)
        {
            trimmedIndexes.Add(shuffledSymbols[i]);
        }

        return trimmedIndexes;
    }
}