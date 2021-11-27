using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(CellAnimation))]
public class Cell : MonoBehaviour
{
    [SerializeField]
    private Image _symbolImage;

    [field: SerializeField]
    public CellAnimation CellAnimation { get; private set; }

    public SimpleSymbol Symbol { get; private set; }

    public event Action<Cell> OnButtonClicked;

    private Button _button;

    public void SetSymbol(SimpleSymbol symbol)
    {
        Symbol = symbol;

        _symbolImage.sprite = Symbol.Sprite;
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(CallClickedEvent);

        CellAnimation = GetComponent<CellAnimation>();
        CellAnimation.SetCellImageTransform(_symbolImage.transform);
    }
    
    private void CallClickedEvent()
    {
        OnButtonClicked?.Invoke(this);
    }

    public void DestroySelf(float delay = 0)
    {
        _button.interactable = false;
        CellAnimation.Fall(delay).OnComplete(() => Destroy(gameObject,CellAnimation.RightAnswerShakeDuration));
    }
}