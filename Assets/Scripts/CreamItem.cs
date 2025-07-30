using UnityEngine;

public class CreamItem : MakeupItem, IApplicable
{
    [SerializeField] private FadeInSprite fadeInSprite;
    [SerializeField] private Sprite creamSprite;

    public void Apply(Vector3 position)
    {
        fadeInSprite.FadeIn(creamSprite);
    }
}