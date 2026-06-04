using UnityEngine;
using UnityEngine.UI;

public class CoverButton : MonoBehaviour
{
    public Image coverImage;
    public Sprite currentSprite;

    public void Setup(Sprite sprite)
    {
        coverImage.sprite = sprite;
        currentSprite = sprite;
    }

    public void SetCover()
    {
        SongDetailsUI detailsUI = FindFirstObjectByType<SongDetailsUI>();
        if (detailsUI != null)
        {
            detailsUI.artworkImage.sprite = currentSprite;
            gameObject.transform.parent.parent.parent.gameObject.SetActive(false);
        }
    }
}