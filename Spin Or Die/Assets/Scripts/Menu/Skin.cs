using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] private bool _isActive = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public bool IsActive => _isActive;

    public void Buy()
    {
        _isBuyed = true;
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void RemoveActivity()
    {
        _isActive = false;
    }
}
