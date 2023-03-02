using DG.Tweening;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    [SerializeField] private float _shurikenSpeed;
    [SerializeField] private Object _shurikenExplosion;

    private Rigidbody2D _rigidbody2D;
    private bool _isSurpassedFifteen = true;
    private bool _isSurpassedFourty = true;
    private bool _isSurpassedSixtyFive = true;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-transform.position.x, transform.position.y) * Mathf.Rad2Deg);

        transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);
    }

    private void Update()
    {
        _rigidbody2D.AddForce(-transform.position * _shurikenSpeed * Time.deltaTime);

        SpeedUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Center")
        {
            GameObject _explosionRef = (GameObject)Instantiate(_shurikenExplosion);
            _explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Destroy(gameObject);
        }
    }

    private void SpeedUp()
    {
        if (Player.instance.PointsInGame > 14 & _isSurpassedFifteen)
        {
            _shurikenSpeed += 3f;
            _isSurpassedFifteen = false;
        }

        if (Player.instance.PointsInGame > 39 & _isSurpassedFourty)
        {
            _shurikenSpeed += 2f;
            _isSurpassedFourty = false;
        }

        if (Player.instance.PointsInGame > 64 & _isSurpassedSixtyFive)
        {
            _shurikenSpeed += 2f;
            _isSurpassedSixtyFive = false;
        }
    }
}
