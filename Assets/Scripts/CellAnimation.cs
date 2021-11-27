using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class CellAnimation : MonoBehaviour
{
    private Transform _cellImageTransform;

    [SerializeField]
    private float _rightAnswerShakeForce;

    [field: SerializeField]
    public float RightAnswerShakeDuration { get; private set; } = 1;

    [SerializeField]
    private float _wrongAnswerShakeForce;

    [SerializeField]
    private float _fadeAnimationDuration=.5f;


    private float _fallHeight;

    private void Awake()
    {
        _fallHeight = (float)Screen.width / 2 + (GetComponent<RectTransform>().sizeDelta.y + 20);
    }

    public void SetCellImageTransform(Transform transform)
    {
        _cellImageTransform = transform;
    }

    public void SetSelfHeightPosition(float delay = 0)
    {
        var yPosition = transform.localPosition.y;
        
        transform.localPosition = new Vector3(transform.localPosition.x, _fallHeight) ;

        transform.DOLocalMoveY(yPosition, _fadeAnimationDuration).SetEase(Ease.OutBounce).SetDelay(delay);
    }

    public void OnWrongAnswer()
    {
        _cellImageTransform.DOShakePosition(1f, new Vector3(_wrongAnswerShakeForce, 0, 0));
    }

    public void OnRightAnswer()
    {
        _cellImageTransform.DOShakePosition(RightAnswerShakeDuration, new Vector3(0, _rightAnswerShakeForce, 0));
       
    }

    public TweenerCore<Vector3, Vector3, VectorOptions> Fall(float delay = 0)
    {
        return transform.DOLocalMoveY(-_fallHeight, _fadeAnimationDuration).SetEase(Ease.InBack).SetDelay(delay);
    }
}