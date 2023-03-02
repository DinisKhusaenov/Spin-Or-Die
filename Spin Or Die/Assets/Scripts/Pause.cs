using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _continueButton;

    private void Start()
    {
        _pausePanel.SetActive(false);
    }

    public void OnPauseButtonClick()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnContinueButtonClick()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _continueButton.transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
    }

    public void OnExitButtonClick()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
