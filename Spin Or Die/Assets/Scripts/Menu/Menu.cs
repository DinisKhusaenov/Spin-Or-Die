using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text _result;
    [SerializeField] private TMP_Text _record;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip _soundClip;
    [SerializeField] private Sprite _soundOnIcon;
    [SerializeField] private Sprite _musicOnIcon;
    [SerializeField] private Sprite _soundOffIcon;
    [SerializeField] private Sprite _musicOffIcon;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _musicButton;

    private bool _isSoundOn = true;
    private bool _isMusicOn = true;

    private void Start()
    {
        _shopPanel.SetActive(false);
        _settingsPanel.SetActive(false);
        _result.text = "0";
        _musicSource.Play();
    }

    private void Update()
    {
        if (Player.instance?.PointsInGame.ToString() == null)
            _result.text = "0";
        else _result.text = Player.instance.PointsInGame.ToString();

        _record.text = PlayerPrefs.GetInt("Record").ToString();
    }
    public void OnClickPlayButton()
    {
        _soundSource.PlayOneShot(_soundClip);
        SceneManager.LoadScene(1);
    }

    public void OnClickShopButton()
    {
        _soundSource.PlayOneShot(_soundClip);
        _shopPanel.SetActive(true); ;
    }

    public void OnClickSettingsButton()
    {
        _soundSource.PlayOneShot(_soundClip);
        _settingsPanel.SetActive(true);
    }

    public void OnClickMenuButton()
    {
        _soundSource.PlayOneShot(_soundClip);
        _shopPanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }

    public void OnSoundButtonClick()
    {
        if (_isSoundOn)
        {
            _soundSource.volume = 0;
            _soundButton.GetComponent<Image>().sprite = _soundOffIcon;
            _isSoundOn = false;
        }
        else {
            _soundSource.volume = 1;
            _soundButton.GetComponent<Image>().sprite = _soundOnIcon;
            _isSoundOn = true;
        }
    }

    public void OnMusicButtonClick()
    {
        if (_isMusicOn)
        {
            _musicSource.volume = 0;
            _musicButton.GetComponent<Image>().sprite = _musicOffIcon;
            _isMusicOn = false;
        }
        else
        {
            _musicSource.volume = 1;
            _musicButton.GetComponent<Image>().sprite = _musicOnIcon;
            _isMusicOn = true;
        }
    }
}
