using UnityEngine;

public class ColourButton : MonoBehaviour
{
    [SerializeField] private MakeupItem targetItem;
    [SerializeField] private Sprite colorSprite;

    public void OnClick()
    {
        if (targetItem != null)
            targetItem.SetColorSprite(colorSprite);
    }
}