using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alphabet", menuName = "Alphabets", order = 0)]
public class AlphabetData : ScriptableObject
{   
    [field: SerializeField]
    public List<SimpleSymbol> Alphabet { get; private set; }
}