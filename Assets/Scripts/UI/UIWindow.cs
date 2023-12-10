using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIWindow : MonoBehaviour
{
    private UIManager manager;

    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private RectTransform windowTransform;

    [SerializeField]
    private bool isOverlay = false;
    public bool IsOverlay => isOverlay;

    [Header("Animation")]
    [SerializeField]
    private float animationDuration = 1;

    [SerializeField]
    private Ease animationEase;

    [SerializeField]
    private float anchoredPositionX;
    [SerializeField]
    private float anchoredPositionY;

    [Header("Fade")]
    [SerializeField]
    private float fadeDuration = 1;

    [SerializeField]
    private Ease fadeEase;

    [Header("Scale")]
    [SerializeField] 
    private float scaleAmount = 1.2f;

    [SerializeField] 
    private float scaleDuration = 0.2f;

#if UNITY_EDITOR

    private void OnValidate()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        windowTransform = GetComponent<RectTransform>();
    }

#endif

    private void Start()
    {
        OnOpen();
    }

    public virtual void OnOpen(Action OnComplete = null)
    {
        DOTween.Kill(gameObject, true);

        gameObject.SetActive(true);

        canvasGroup.alpha = 0f;
        windowTransform.anchoredPosition = new Vector2(anchoredPositionX, anchoredPositionY);

        transform.DOScale(scaleAmount, scaleDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => transform.DOScale(1f, scaleDuration).SetEase(Ease.OutQuad));

        canvasGroup.DOFade(1f, fadeDuration);

        windowTransform.DOAnchorPosX(0f, animationDuration).SetEase(animationEase);
        windowTransform.DOAnchorPosY(0f, animationDuration).SetEase(animationEase).OnComplete(() => OnComplete?.Invoke());
    }

    public virtual void OnClose(Action OnComplete = null)
    {
        DOTween.Kill(gameObject, true);

        canvasGroup.DOFade(0f, fadeDuration);

        windowTransform.DOAnchorPosX(anchoredPositionX, animationDuration).SetEase(animationEase);
        windowTransform.DOAnchorPosY(anchoredPositionY, animationDuration).SetEase(animationEase).OnComplete(() => OnComplete?.Invoke());

        transform.DOScale(scaleAmount, animationDuration).SetEase(animationEase).OnComplete(() =>
        {
            gameObject.SetActive(false);
            OnComplete?.Invoke();
        });
    }
}