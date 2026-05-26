using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReleasedSongDetailsUI : MonoBehaviour
{
    public TMP_Text songNameText;
    public TMP_Text genreText;
    public TMP_Text qualityText;
    public TMP_Text explicityText;
    public TMP_Text releaseDateText;
    public TMP_Text featuresText;
    public Image trackImage;
    private SongData currentSong;
    public void ShowSong(SongData song)
    {
        currentSong = song;
        gameObject.SetActive(true);
        songNameText.text = song.songName;
        genreText.text = "Genre: " + song.genre;
        qualityText.text = "Quality: " + song.quality;
        explicityText.text = "Explicit: " + (song.isExplicit ? "Yes" : "No");
        releaseDateText.text = $"Released: Week {song.releaseWeek}, Year {song.releaseYear}";
        featuresText.text = $"Features: {song.featureDisplayType}";
        //Sprite sprite = ImageLoader.LoadSpriteFromFile(song.artworkPath);
        //if (sprite != null) trackImage.sprite = sprite;
    }
}
