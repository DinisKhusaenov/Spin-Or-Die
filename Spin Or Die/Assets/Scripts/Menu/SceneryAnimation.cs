using UnityEngine;
using DG.Tweening;

public class SceneryAnimation: MonoBehaviour
{
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private GameObject _circleWithCorners;

    private Vector3[] _waypoints = new Vector3[5];

    private void Start()
    {
        foreach (var star in _stars)
            star.transform.DORotate(new Vector3(0, 0, 360), 10f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);

        PointAssigment();

        Tween tween = _circleWithCorners.transform.DOPath(_waypoints, 30f, PathType.CatmullRom).SetOptions(true);
        tween.SetEase(Ease.Linear).SetLoops(-1);
        _circleWithCorners.transform.DORotate(new Vector3(0, 0, 360), 10f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }

    private void PointAssigment()
    {
        for (int i = 0; i < _waypoints.Length; i++) {
            _waypoints[i].y = Random.Range(0, 1000); 
            _waypoints[i].x = Random.Range(0, 1800); 
        }
    }
}
