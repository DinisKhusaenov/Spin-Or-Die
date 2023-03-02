using DG.Tweening;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private SpriteRenderer _spriteRenderer;
    private Color _color = new Color(0.773374f, 0.664151f, 1f);

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.DOColor(_color, 15).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {

        float _cameraHeight = _camera.pixelHeight;

        var _bottomLeft = _camera.ScreenToWorldPoint(new Vector2(0, 0));
        var _topLeft = _camera.ScreenToWorldPoint(new Vector2(0, _cameraHeight));

        var _height = new Vector2(_topLeft.x - _bottomLeft.x, _topLeft.y - _bottomLeft.y);

        float ScaleY = _height.magnitude;

        float ScaleX = ScaleY * Screen.width / Screen.height;

        transform.localScale = new Vector3(ScaleX / 19.2f, ScaleY / 10.7f, 1f);
    }
}