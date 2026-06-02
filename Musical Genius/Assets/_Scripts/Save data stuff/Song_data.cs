using NUnit.Framework;
using System;
using System.Collections.Generic;

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

    //Features
    public List<NPCArtist> featuredArtists;
    public string featureDisplayType;

    // Other
    public int quality;

    //Future stuff
    public string artworkPath;
}