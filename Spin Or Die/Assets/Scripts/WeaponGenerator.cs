using UnityEngine;
using UnityEngine.UIElements;

public class WeaponGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shuriken;

    private float _generateBulletTimer = 3;
    private float _generateShurikenTimer = 5;


    private void Start()
    {
        InvokeRepeating("SpawnBullets", _generateBulletTimer, _generateBulletTimer);
        InvokeRepeating("SpawnShuriken", _generateShurikenTimer, _generateShurikenTimer);
    }

    private void SpawnBullets()
    {
        float _xPosition = Random.Range(-13, 13);
        float _yPosition = Random.Range(-8, 8);
        Instantiate(_bullet, new Vector3(_xPosition, 8), Quaternion.identity);
        Instantiate(_bullet, new Vector3(_xPosition, -8), Quaternion.identity);
        Instantiate(_bullet, new Vector3(-13, _yPosition), Quaternion.identity);
        Instantiate(_bullet, new Vector3(13, _yPosition), Quaternion.identity);

        if (Player.instance.PointsInGame > 9)
        {
            float _newYPosition = Random.Range(-7, 7);
            Instantiate(_bullet, new Vector3(11, _newYPosition), Quaternion.identity);
        }

    }

    private void SpawnShuriken()
    {
        if(Player.instance.PointsInGame > 4)
        {
            float _xPosition = Random.Range(-13, 13);
            float _yPosition = Random.Range(-8, 8);
            Instantiate(_shuriken, new Vector3(_xPosition, 8), Quaternion.identity);
            Instantiate(_shuriken, new Vector3(-13, _yPosition), Quaternion.identity);
        }
    }
}
