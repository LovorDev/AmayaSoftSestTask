using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsFiller : MonoBehaviour
{
    private List<Cell> _cells;
    

    public void SetCells(List<Cell> cells)
    {
        _cells = cells;
    }
    
    public void FillSymbols(List<SimpleSymbol> symbols)
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            _cells[i].SetSymbol(symbols[i]);
        }
    }
}
