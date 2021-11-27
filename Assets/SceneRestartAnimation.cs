using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SceneRestartAnimation : MonoBehaviour
    {
        [SerializeField]
        private Image _fadingImage;

        [SerializeField]
        private Button _restartButton;

        [SerializeField]
        private float _fadeDuration;

        public void Deactivate()
        {
            _restartButton.gameObject.SetActive(false);
            _fadingImage.color = new Color(_fadingImage.color.r, _fadingImage.color.g, _fadingImage.color.b, 1);
            _fadingImage.DOFade(0, _fadeDuration).OnComplete(() =>
                _fadingImage.gameObject.SetActive(false));
        }

        public void Activate()
        {
            _restartButton.gameObject.SetActive(true);
            _restartButton.image.DOFade(1, _fadeDuration / 4);
            _fadingImage.gameObject.SetActive(true);
        }


        public TweenerCore<Color, Color, ColorOptions> AnimateFade()
        {
            return _fadingImage.DOFade(1, _fadeDuration);
        }
    }
}