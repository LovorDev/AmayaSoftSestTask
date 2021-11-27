using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellSelector : MonoBehaviour
{
    [Serializable]
    public class SelectedCellNameEvent : UnityEvent<string>
    {
    }

    [Serializable]
    public class SelectedCellEvent : UnityEvent<SimpleSymbol>
    {
    }

    [SerializeField]
    private AnswerChecker _answerChecker;

    [SerializeField]
    private ParticleSystem _rightParticles;

    private List<Cell> _cells;

    public void SubToCells(List<Cell> cells)
    {
        _cells = cells;
        foreach (var cell in _cells)
        {
            cell.OnButtonClicked += OnClickedCell;
        }
    }

    public void UnSubFromCell()
    {
        foreach (var cell in _cells)
        {
            cell.OnButtonClicked -= OnClickedCell;
        }
    }

    private void OnClickedCell(Cell cell)
    {
        if (_answerChecker.CheckSymbol(cell.Symbol))
        {
            cell.CellAnimation.OnRightAnswer();
            _rightParticles.transform.position = cell.transform.position + Vector3.one;
            _rightParticles.Play();
        }
        else
            cell.CellAnimation.OnWrongAnswer();
    }
}