using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTweener : MonoBehaviour
{
    [SerializeField] private float scaleAmount = 1.2f;
    [SerializeField] private float duration = 0.2f;

    public void PopUp()
    {
        transform.DOScale(scaleAmount, duration)
               .SetEase(Ease.OutQuad)
               .OnComplete(() => transform.DOScale(1f, duration).SetEase(Ease.OutQuad));
    }
}