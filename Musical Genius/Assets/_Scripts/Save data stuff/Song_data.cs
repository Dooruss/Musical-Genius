using System;

[Serializable]
public class SongData
{
    public string songID;
    public string songName;
    public string genre;

    //Project related
    public bool onEP;
    public bool onAlbum;
    public bool onMixTape;

    //Release date 
    public int releaseWeek;
    public int releaseYear;
    public bool isReleased;
    public bool upcomingRelease;

    //Future stuff
    public int quality;
    public string artworkPath;
    public string featureDisplayType;
}