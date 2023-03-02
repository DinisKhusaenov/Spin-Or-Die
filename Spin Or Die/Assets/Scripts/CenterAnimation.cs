using UnityEngine;
using DG.Tweening;

public class CenterAnimation : MonoBehaviour
{
    private void Start()
    {
        transform.DOScale(1f, 0.6f).SetLoops(-1, LoopType.Yoyo);
    }
}
