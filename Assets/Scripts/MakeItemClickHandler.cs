using UnityEngine;

public class MakeItemClickHandler : MonoBehaviour
{
    [SerializeField] private HandController handController;
    [SerializeField] private MakeupItem[] makeupItems;

    private void Start()
    {
        foreach (var item in makeupItems)
            item.OnItemClick += OnItemClicked;
    }

    private void OnItemClicked(ItemType type)
    {
        var clickedItem = System.Array.Find(makeupItems, i => i.ItemType == type);
        if (clickedItem != null && !clickedItem.IsPickedUp)
            handController.PickUpItem(clickedItem);
    }

    private void OnDestroy()
    {
        foreach (var item in makeupItems)
            item.OnItemClick -= OnItemClicked;
    }
}