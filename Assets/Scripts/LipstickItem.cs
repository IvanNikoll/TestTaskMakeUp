using UnityEngine;

public class LipstickItem : MakeupItem, IApplicable
{
    [SerializeField] private FadeInSprite fadeInSprite;
    [SerializeField] private Sprite lipstickSprite;

    public void Apply(Vector3 position)
    {
        fadeInSprite.FadeIn(lipstickSprite);
    }
}