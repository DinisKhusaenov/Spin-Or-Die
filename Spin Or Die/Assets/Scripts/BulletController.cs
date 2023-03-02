using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Object _bulletExplosion;

    private Rigidbody2D _rigidbody2D;
    private bool _isSurpassedFour = true;
    private bool _isSurpassedTwentyFive = true;
    private bool _isSurpassedThirtyFive = true;
    private bool _isSurpassedSixty = true;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-transform.position.x, transform.position.y) * Mathf.Rad2Deg);
    }

    private void Update()
    {
        _rigidbody2D.AddForce(-transform.position * _bulletSpeed * Time.deltaTime);

        SpeedUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Center")
        {
            GameObject _explosionRef = (GameObject)Instantiate(_bulletExplosion);
            _explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Destroy(gameObject);
        }
    }

    private void SpeedUp()
    {
        if (Player.instance.PointsInGame > 4 & _isSurpassedFour)
        {
            _bulletSpeed += 2f;
            _isSurpassedFour = false;
        }

        if (Player.instance.PointsInGame > 24 & _isSurpassedTwentyFive)
        {
            _bulletSpeed += 2f;
            _isSurpassedTwentyFive = false;
        }

        if (Player.instance.PointsInGame > 34 & _isSurpassedThirtyFive)
        {
            _bulletSpeed += 2f;
            _isSurpassedThirtyFive = false;
        }

        if (Player.instance.PointsInGame > 59 & _isSurpassedSixty)
        {
            _bulletSpeed += 2f;
            _isSurpassedSixty = false;
        }
    }
}
