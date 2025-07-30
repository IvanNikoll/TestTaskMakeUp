using UnityEngine;
using System;

public class MakeupItem : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private Sprite defaultSprite;
    public event Action<ItemType> OnItemClick;
    public ItemType ItemType => itemType;
    public void SetPickedUp(bool value) => _isPickedUp = value;
    public Sprite DefaultSprite { get { return defaultSprite; } }
    public bool IsPickedUp => _isPickedUp;
    private bool _isPickedUp;
    private Sprite _selectedColor;

    public void SetColorSprite(Sprite newSprite)
    {
        _selectedColor = newSprite;
    }

    public Sprite GetSelectedColor()
    {
        return _selectedColor;
    }

    public void OnClickItem()
    {
        OnItemClick?.Invoke(itemType);
    }
}