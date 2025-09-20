using UnityEngine;
using DG.Tweening;

public class PopUpUI : MonoBehaviour
{
    [Header("Popup Settings")]
    public float duration = 0.3f;
    public float startScale = 0.2f;
    public Ease easeType = Ease.OutBack;

    private void OnEnable()
    {
        transform.localScale = Vector3.one * startScale;

        transform.DOScale(1f, duration).SetEase(easeType).SetUpdate(true);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
