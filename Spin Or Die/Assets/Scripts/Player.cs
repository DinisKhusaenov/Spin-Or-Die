using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Skin> _skins;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private GameObject _characterExplosion;

    private float _angle = 0;
    private int _points = 0;
    private bool _isCircleMade = true;

    public static Player instance;
    public int PointsInGame => _points;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        ChangeSkin();
    }

    private void Update()
    {
        float _radius = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2));

        PlayerMovement(_radius);

        CountingPoints();
    }

    private void PlayerMovement(float _radius)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _angle += Time.deltaTime;
            var x = Mathf.Sin(_angle * _speed) * _radius;
            var y = Mathf.Cos(_angle * _speed) * _radius;
            transform.position = new Vector2(x, y);
        }
    }
    private void CountingPoints()
    {
        if (transform.position.x >= 0 & _isCircleMade)
        {
            _points++;
            _isCircleMade = false;
        }
        else if (transform.position.x < 0) { _isCircleMade = true; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BulletController>( out BulletController bulletController))
        {
            _ = EndGame();
        }

        if (collision.TryGetComponent<ShurikenController>(out ShurikenController shurikenController))
        {
            _ = EndGame();
        }
    }

    private async Task EndGame()
    {
        GameObject _explosionRef = (GameObject)Instantiate(_characterExplosion);  
        _explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Destroy(gameObject);

        Time.timeScale = 0.3f;

        await Task.Delay(TimeSpan.FromSeconds(1.5f));

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void ChangeSkin()
    {
        for (int i = 0; i < _skins.Count; i++)
        {
            if (_skins[i].Label == PlayerPrefs.GetString("ActiveSkin"))
            {
                GetComponent<SpriteRenderer>().sprite = _skins[i].Icon;
            }
        }
    }
}
