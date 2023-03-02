using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Image _lock;
    [SerializeField] private Object _unlockExplosion;
    [SerializeField] private GameObject _lockPosition;
    [SerializeField] private Image _select;

    private Skin _skin;

    public event UnityAction<Skin, SkinView> BuyButtonClick;
    public event UnityAction<Skin, SkinView> SelectButtonClick;

    private void StartSelect(Skin skin)
    {
        if (!skin.IsActive)
        {
            _select.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnButtonClick); 
        _buyButton.onClick.AddListener(TryLockItem);

        _selectButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnButtonClick);
        _buyButton.onClick.RemoveListener(TryLockItem);

        _selectButton.onClick.RemoveListener(OnButtonClick);
    }

    private void TryLockItem()
    {
        if (_skin.IsBuyed)
        {
            _buyButton.interactable = false;
            _buyButton.gameObject.SetActive(false);
        }
    }

    public void Render(Skin skin)   
    {
        _skin = skin;
        _label.text = skin.Label;
        _price.text = skin.Price.ToString();
        _icon.sprite = skin.Icon;

        if (_skin.IsBuyed)
            Destroy(_lock);

        StartSelect(skin);
    }

    private void OnButtonClick()
    {
        BuyButtonClick?.Invoke(_skin, this);
        SelectButtonClick?.Invoke(_skin, this);
    }

    public void UnlockSkin(Skin skin)
    {
        if (!skin.IsBuyed)
        {
            GameObject _explosionRef = (GameObject)Instantiate(_unlockExplosion);
            _explosionRef.transform.position = new Vector3(_lockPosition.transform.position.x, _lockPosition.transform.position.y, _lockPosition.transform.position.z);

            Destroy(_lock);
        }
    }

    public void ActivateSkin()
    {
        _select.gameObject.SetActive(true);
    }

    public void DeactivateSkin()
    {
        _select.gameObject.SetActive(false);
    }
}
