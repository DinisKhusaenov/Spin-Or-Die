using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 _scale = new Vector3(0.3f, 0.3f, 0.3f);

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale += _scale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale -= _scale;
    }
}
