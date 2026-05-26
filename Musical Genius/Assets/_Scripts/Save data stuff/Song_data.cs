using System;

[Serializable]
public class SongData
{
    public string songID;
    public string songName;
    public string genre;
    public string[] subjectsWithEffect;
    public string[] subjectsNoEffect;
    public bool isExplicit;

    //Project related
    public bool onEP;
    public string epName;
    public bool onAlbum;
    public string albumName;
    public bool onMixTape;
    public string mixtapeName;
    public bool onSoundtrack;
    public string soundtrackName;

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