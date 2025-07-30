using UnityEngine;

public class MakeUpItemContext : MonoBehaviour
{
    [Header("Brush")]
    [SerializeField] private Transform brushDefaultPosition;
    [SerializeField] private Transform brushDragPosition;
    
    [Header("Cream")]
    [SerializeField] private Transform creamDefaultPosition;
    [SerializeField] private Transform creamDragPosition;

    [Header("Lipstick")]
    [SerializeField] private Transform lipstickDefaultPosition;
    [SerializeField] private Transform lipstickDragPosition;

    public Transform GetItemPosition(bool isDefault, ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Brush:
                return isDefault ? brushDefaultPosition : brushDragPosition;
            case ItemType.Cream:
                return isDefault ? creamDefaultPosition : creamDragPosition;
            case ItemType.Lipstick:
                return isDefault ? lipstickDefaultPosition : lipstickDragPosition;
            default:
                throw new System.ArgumentException(nameof(itemType));
        }
    }
}