using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellsSpawner : MonoBehaviour
{
    [Serializable]
    public class CreatedCellsEvent : UnityEvent<List<Cell>>
    {
    }

    [SerializeField]
    private Cell _cellPrefab;

    private Vector2 _cellsGrid;

    [SerializeField]
    [Header("Position")]
    private Transform _cellsParent;

    [SerializeField]
    private Transform _startPoint;

    [SerializeField]
    private PointAlignment _pointAlignment;

    enum PointAlignment
    {
        Zero,
        Center
    }


    private Vector2 _cellSize;

    [SerializeField]
    [Space(12)]
    private CreatedCellsEvent _createdCells;

    private List<Cell> _cells = new List<Cell>();

    public void Spawn(DifficultySettings difficultySettings)
    {
        _cellSize = _cellPrefab.GetComponent<RectTransform>().sizeDelta;

        for (int y = 0; y < difficultySettings.CellsGrid.y; y++)
        {
            for (int x = 0; x < difficultySettings.CellsGrid.x; x++)
            {
                var newCell = Instantiate(_cellPrefab, Position(new Vector2(x, y), difficultySettings.CellsGrid),
                    Quaternion.identity);
                newCell.transform.SetParent(_cellsParent, false);
                newCell.CellAnimation.SetSelfHeightPosition(y + .3f * x + .3f);
                _cells.Add(newCell);
            }
        }

        _cellsGrid = difficultySettings.CellsGrid;
        _createdCells?.Invoke(_cells);
    }

    public void DeletePrevious()
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            _cells[i].DestroySelf(i*.2f);
        }
        _cells = new List<Cell>();
    }

    private Vector3 Position(Vector2 point, Vector2 grid)
    {
        var startPointPosition = _startPoint.position;
        var cellPosition = new Vector3(_cellSize.x * point.x, _cellSize.y * point.y);
        switch (_pointAlignment)
        {
            case PointAlignment.Zero:
                return startPointPosition + cellPosition;
            case PointAlignment.Center:
                return startPointPosition -
                    (new Vector3(_cellSize.x * grid.x, _cellSize.y * grid.y) / 2) + cellPosition;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}