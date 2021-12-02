using System;
using System.Collections.Generic;
using SettingsScripts;
using UnityEditorInternal;
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

    [SerializeField]
    [Header("Position")]
    private Transform _cellsParent;

    [SerializeField]
    private RectTransform _startPoint;

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
    private Vector2 _currentGrid = Vector2.zero;

    public void Spawn(DifficultySettings difficultySettings)
    {
        SimpleSpawn(difficultySettings.CellsGrid, _currentGrid == Vector2.zero);
    }

    private void SimpleSpawn(Vector2 grid, bool animationEnabled = true)
    {
        _cellSize = _cellPrefab.GetComponent<RectTransform>().sizeDelta;

        for (int y = (int)_currentGrid.y; y < grid.y; y++)
        {
            for (int x = 0; x < grid.x; x++)
            {
                var newCell = Instantiate(_cellPrefab, Position(new Vector2(x, y), grid),
                    Quaternion.identity);
                newCell.transform.SetParent(_cellsParent, false);
                if (animationEnabled)
                    newCell.CellAnimation.SetSelfHeightPosition(y + .3f * x + .3f);
                _cells.Add(newCell);
            }
        }

        _currentGrid = grid;
        _createdCells?.Invoke(_cells);
    }


    private Vector3 Position(Vector2 point, Vector2 grid)
    {
        var startPointPosition = _startPoint.localPosition;
        var cellPosition = new Vector3(_cellSize.x * point.x, _cellSize.y * point.y);
        switch (_pointAlignment)
        {
            case PointAlignment.Zero:
                return cellPosition + startPointPosition;
            case PointAlignment.Center:
                return startPointPosition -
                    (new Vector3(_cellSize.x * grid.x, _cellSize.y * grid.y) / 2) + cellPosition;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}