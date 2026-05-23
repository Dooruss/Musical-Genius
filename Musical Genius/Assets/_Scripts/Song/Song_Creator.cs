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

        // MAKE SURE NOT EMPTY

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

        // LOAD CURRENT SAVE

        int slot = Game_Manager.Instance.currentSlot;

        SaveData data = SaveSystem.LoadGame(slot);

        // CREATE SONG

        SongData newSong = new SongData();

        newSong.songName = songName;

        newSong.genre = selectedGenre;

        newSong.isReleased = false;

        newSong.onEP = false;

        newSong.onAlbum = false;


        // add stuff for quality here later!!!!!!!!!!!


        // ADD TO SONG LIST

        data.songs.Add(newSong);

        // SAVE AGAIN

        SaveSystem.SaveGame(data, slot);

        Debug.Log("Song Created!");
    }
}