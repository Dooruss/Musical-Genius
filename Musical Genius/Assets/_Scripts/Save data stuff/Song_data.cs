using System;

[Serializable]
public class SongData
{
    public string songName;

    public string genre;

    public bool isReleased;

    public bool onEP;

    public bool onAlbum;

    //Release date 

    public int releaseWeek;
    public int releaseYear;

    //Future stuff

    public int quality;
    public string artworkPath;
    public string featureDisplayType;
}