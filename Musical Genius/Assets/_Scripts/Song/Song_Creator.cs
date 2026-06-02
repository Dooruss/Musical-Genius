using TMPro;
using UnityEngine;

public class SongCreator : MonoBehaviour
{
    public TMP_InputField songNameInput;

    private string selectedGenre = "";

    public void SelectGenre(string genre)
    {
        selectedGenre = genre;

        Debug.Log("Selected Genre: " + genre);
    }

    public void CreateSong()
    {
        string songName = songNameInput.text.Trim();

        CheckIfFilled(songName);


        // CREATE SONG

        SongData newSong = new SongData();
        newSong.songID = System.Guid.NewGuid().ToString(); //NewGuid makes a unique ID for the song (Tbh very handy)
        newSong.songName = songName;
        newSong.genre = selectedGenre;
        newSong.isReleased = false;
        newSong.onEP = false;
        newSong.onAlbum = false;
        newSong.onMixTape = false;

        // Quality
        newSong.quality = MakeQuality();

        // SAVE AGAIN

        SaveManager.Instance.currentSave.songs.Add(newSong);
        SaveManager.Instance.Save();
    }

    private void CheckIfFilled(string songName)
    {
        if (string.IsNullOrEmpty(songName))
        {
            Debug.Log("Song needs a name.");
            return;
        }

        if (string.IsNullOrEmpty(selectedGenre))
        {
            Debug.Log("Select a genre.");
            return;
        }
    }


    private int MakeQuality()
    {
        var data = SaveManager.Instance.currentSave;
        Genre_Data Genre = Genre_Database.GetGenre(selectedGenre);

       if (Genre == null)
        {
            Debug.LogError("Genre not found: " + selectedGenre);
            return 0; // Return a default quality if genre is not found
        }

       float quality = data.vocals * Genre.VocalsWeight + data.producing * Genre.ProducingWeight + data.songWriting * Genre.SongWritingWeight + data.livePerformance * Genre.LivePerformanceWeight;
        quality += Random.Range(-5f, 25f); // Add some randomness to the quality

        return Mathf.Clamp(Mathf.RoundToInt(quality), 0, 100); // Ensure quality is between 0 and 100
    }
}