using System.Collections.Generic;
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

        int slot = Game_Manager.Instance.currentSlot;

        SaveData data = SaveSystem.LoadGame(slot);

        // CREATE BUTTONS

        foreach (SongData song in data.songs)
        {
            if (!song.isReleased)
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