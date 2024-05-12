using DG.Tweening;
using UnityEngine;

public class BootstrapLoadingFadeEffectController : SingletonPersistent<BootstrapLoadingFadeEffectController>
{
    [SerializeField]
    private CanvasGroup _backdropImageCanvasGroup;

    [SerializeField]
    [Range(0f, 5f)]
    private float _fadeDuration;

    public static bool EndFadeIn { get; set; } = false;
    public static bool EndFadeOut { get; set; } = false;

    public void FadeIn()
    {
        EndFadeOut = false;

        _backdropImageCanvasGroup.gameObject.SetActive(true);

        _backdropImageCanvasGroup.DOFade(1f, _fadeDuration).OnComplete(
            () =>
            {
                EndFadeIn = true;
            }
        );
    }

    public void FadeOut()
    {
        EndFadeIn = false;

        _backdropImageCanvasGroup.DOFade(0f, _fadeDuration).OnComplete(
            () =>
            {
                _backdropImageCanvasGroup.gameObject.SetActive(false);
                EndFadeOut = true;
            }
        );
    }

    public void FadeAll()
    {
        _backdropImageCanvasGroup.DOFade(1f, _fadeDuration).OnComplete(
            () =>
            {
                DOVirtual.DelayedCall(1f, () =>
                {
                    _backdropImageCanvasGroup.DOFade(0f, _fadeDuration);
                }
                );
            }
        );
    }
}
