using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Skin> _skins;
    [SerializeField] private SkinView _temlate;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _buySound;

    private SkinView _previousActiveSkin;
    private SkinView _activeSkin;

    private void Start()
    {
        for (int i = 0; i < _skins.Count; i++)
        {
            AddItem(_skins[i]);
        }
    }

    private void AddItem(Skin skin)
    {
        var view = Instantiate(_temlate, _itemContainer.transform);
        view.BuyButtonClick += OnBuyButtonClick;
        view.Render(skin);
        view.SelectButtonClick += OnSelectButtonClick;
        
        if (skin.IsActive)
        {
            _activeSkin = view;
        }
    }

    private void OnBuyButtonClick(Skin skin, SkinView view)
    {
        TryBuySkin(skin, view);
        TrySelectSkin(skin, view);
    }

    private void OnSelectButtonClick(Skin skin, SkinView view)
    {
        TrySelectSkin(skin, view);
    }

    private void TryBuySkin(Skin skin, SkinView view)
    {
        if (skin.Price <= PlayerPrefs.GetInt("Record"))
        {
            view.UnlockSkin(skin);
            BuySkin(skin);
            skin.Buy();
            view.BuyButtonClick -= OnBuyButtonClick;
            _audioSource.PlayOneShot(_buySound);
        }
    }

    private void BuySkin(Skin skin)
    {
        PlayerPrefs.SetString("ActiveSkin", skin.Label);
    }

    private void TrySelectSkin(Skin skin, SkinView view)
    {
        if (skin.IsBuyed && !skin.IsActive)
        {
            SelectSkin(skin, view);
            _audioSource.PlayOneShot(_buySound);
        }
    }

    private void SelectSkin(Skin skin, SkinView view)
    {
        for (int i = 0; i < _skins.Count; i++)
        {
            _skins[i].RemoveActivity();
        }

        _previousActiveSkin = _activeSkin;
        _previousActiveSkin.DeactivateSkin();
        _activeSkin = view;
        _activeSkin.ActivateSkin();
        skin.Activate();
        PlayerPrefs.SetString("ActiveSkin", skin.Label);
    }
}
