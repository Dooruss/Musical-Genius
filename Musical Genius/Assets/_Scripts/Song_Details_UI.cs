using TMPro;
using UnityEngine;

public class SongDetailsUI : MonoBehaviour
{
    public TMP_Text songNameText;

    public TMP_Text genreText;

    public TMP_Text qualityText;

    private SongData currentSong;

    public TMP_InputField renameInput;

    //Release date stuff
    public TMP_Text releaseDateText;
    private int selectedWeek;
    private int selectedYear;

    public void ShowSong(SongData song)
    {
        currentSong = song;

        gameObject.SetActive(true);

        songNameText.text = song.songName;

        genreText.text = "Genre: " + song.genre;

        qualityText.text = "Quality: " + song.quality;

        selectedWeek = TimeManager.Instance.currentWeek;

        selectedYear = TimeManager.Instance.currentYear;

        UpdateReleaseDateUI();
    }

    private void SaveCurrentSongData()
    {
        int slot = Game_Manager.Instance.currentSlot;

        SaveData data = SaveSystem.LoadGame(slot);

        for (int i = 0; i < data.songs.Count; i++)
        {
            if (data.songs[i] == currentSong)
            {
                data.songs[i] = currentSong;
            }
        }

        SaveSystem.SaveGame(data, slot);
    }

    public void ChangeName()
    {
        string newName = renameInput.text.Trim();

        if (string.IsNullOrEmpty(newName)) return;

        currentSong.songName = newName;

        SaveCurrentSongData();

        ShowSong(currentSong);
    }


    private void UpdateReleaseDateUI()
    {
        releaseDateText.text = "Week " + selectedWeek + ", Year " + selectedYear;
    }

    public void NextReleaseWeek()
    {
        selectedWeek++;

        if (selectedWeek > 52)
        {
            selectedWeek = 1;

            selectedYear++;
        }

        // LIMIT 1 YEAR AHEAD

        int currentYear = TimeManager.Instance.currentYear;

        if (selectedYear > currentYear + 1)
        {
            selectedYear = currentYear + 1;

            selectedWeek = 52;
        }

        UpdateReleaseDateUI();
    }

    public void PreviousReleaseWeek()
    {
        selectedWeek--;

        if (selectedWeek < 1)
        {
            selectedWeek = 52;

            selectedYear--;
        }

        UpdateReleaseDateUI();
    }

    public void ReleaseSong()
    {
        currentSong.isReleased = true;

        currentSong.releaseWeek = selectedWeek;
        currentSong.releaseYear = selectedYear;

        SaveCurrentSongData();

        Debug.Log(currentSong.songName + " scheduled for release.");
    }

}