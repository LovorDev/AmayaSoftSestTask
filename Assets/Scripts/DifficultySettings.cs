using UnityEngine;

[CreateAssetMenu(fileName = "New difficulty", menuName = "Difficulty", order = 0)]
public class DifficultySettings : ScriptableObject
{
    [field: SerializeField]
    public Vector2 CellsGrid { get; private set; }

    [field: SerializeField]
    public string DifficultyName { get; private set; }

    [field: SerializeField]
    public int LevelsQuantity { get; private set; }
    
}