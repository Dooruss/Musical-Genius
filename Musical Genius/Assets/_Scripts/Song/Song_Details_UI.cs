using TMPro;
using UnityEngine;

public class SongDetailsUI : MonoBehaviour
{
    public TMP_Text songNameText;
    public TMP_Text genreText;
    public TMP_Text qualityText;
    public TMP_Text explicityText;
    
    public bool isExplicit;

    private SongData currentSong;

    public TMP_InputField renameInput;

    //Release date stuff
    public TMP_Text releaseDateText;
    private int selectedWeek;
    private int selectedYear;

    public ErrorPopup popup;

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
        var data = SaveManager.Instance.currentSave;

        for (int i = 0; i < data.songs.Count; i++)
        {
            if (data.songs[i].songID == currentSong.songID)
            {   
                data.songs[i] = currentSong;
                break;
            }
        }

        SaveManager.Instance.Save();
        ShowSong(currentSong);
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

    public void makeExplicit()
    {
        currentSong.isExplicit = !currentSong.isExplicit;
        SaveCurrentSongData();
        UpdateExplicitUI();
    }

    public void UpdateExplicitUI()
    {
        if (currentSong.isExplicit)
        {
            explicityText.text = "Explicit";
            explicityText.color = Color.red;
        }
        else
        {
            explicityText.text = "Clean";
            explicityText.color = Color.green;
        }
    }

    public void ReleaseSong()
    {
        if (selectedYear < TimeManager.Instance.currentYear ||
            (selectedYear == TimeManager.Instance.currentYear && selectedWeek <= TimeManager.Instance.currentWeek))
        {
            popup.ShowError("Release date must be in the future.");
            return;
        }

        currentSong.upcomingRelease = true;

        currentSong.releaseWeek = selectedWeek;
        currentSong.releaseYear = selectedYear;

        SaveCurrentSongData();
        FindFirstObjectByType<UnreleasedSongsUI>().OpenUnreleasedSongs();

        Debug.Log(currentSong.songName + " scheduled for release on Week " + currentSong.releaseWeek + ", Year " + currentSong.releaseYear);
        gameObject.SetActive(false);
    }

}