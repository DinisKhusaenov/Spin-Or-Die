using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;

    private void Update()
    {
        _pointsText.text = Player.instance.PointsInGame.ToString();

        if (Player.instance.PointsInGame > PlayerPrefs.GetInt("Record"))
            PlayerPrefs.SetInt("Record", Player.instance.PointsInGame);

    }

}
