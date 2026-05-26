using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReleasedSongsUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject songButtonPrefab;
    public ReleasedSongDetailsUI detailsUI;

    public void OpenReleasedSongs()
    {
        // CLEAR OLD BUTTONS
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        var data = SaveManager.Instance.currentSave;

        foreach (SongData song in data.songs)
        {
            if (song.isReleased)
            {
                GameObject buttonObj = Instantiate(songButtonPrefab, contentParent);

                TMP_Text text = buttonObj.GetComponentInChildren<TMP_Text>();
                text.text = song.songName;

                Image img = buttonObj.GetComponentInChildren<Image>();

                //Sprite sprite = ImageLoader.LoadSpriteFromFile(song.artworkPath);

                //if (sprite != null) img.sprite = sprite;

                Button button = buttonObj.GetComponent<Button>();

                button.onClick.AddListener(() =>
                {
                    detailsUI.ShowSong(song);
                });
            }
        }
    }
}