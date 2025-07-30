using UnityEngine;

public class BrushItem : MakeupItem, IApplicable
{
    [SerializeField] private FadeInSprite fadeInSprite;
    [SerializeField] private Sprite blushSprite;

    public void Apply(Vector3 position)
    {
        Sprite selected = GetSelectedColor();
        Sprite spriteToUse = selected != null ? selected : DefaultSprite;
        fadeInSprite.FadeIn(spriteToUse);
    }
}