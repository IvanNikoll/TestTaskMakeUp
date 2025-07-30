using UnityEngine;
using System.Collections;

public class FadeInSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetRenderer;
    [SerializeField] private float fadeDuration = 1f;

    public void FadeIn(Sprite newSprite)
    {
        StartCoroutine(FadeCoroutine(newSprite));
    }

    private IEnumerator FadeCoroutine(Sprite newSprite)
    {
        targetRenderer.sprite = newSprite;
        Color c = targetRenderer.color;
        c.a = 0;
        targetRenderer.color = c;
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1, t / fadeDuration);
            targetRenderer.color = c;
            yield return null;
        }
    }
}