using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnreleasedSongsUI : MonoBehaviour
{
    public Transform contentParent;

    public GameObject songButtonPrefab;

    public SongDetailsUI detailsUI;

    public void OpenUnreleasedSongs()
    {
        // CLEAR OLD BUTTONS

        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        var data = SaveManager.Instance.currentSave;

        // CREATE BUTTONS

        foreach (SongData song in data.songs)
        {
            if (!song.isReleased && !song.upcomingRelease)
            {
                GameObject buttonObj = Instantiate( songButtonPrefab, contentParent);

                TMP_Text text = buttonObj.GetComponentInChildren<TMP_Text>();

                text.text = song.songName;

                Button button = buttonObj.GetComponent<Button>();

                button.onClick.AddListener(() =>
                {
                    detailsUI.ShowSong(song);
                });
            }
        }
    }


}