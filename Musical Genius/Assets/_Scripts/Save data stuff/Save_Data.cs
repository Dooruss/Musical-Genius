using System;
using System.Collections.Generic;

[Serializable] //to tell that this class can be turned into a JSON
public class SaveData
{
    //Info
    public string playerName;
    public int age;
    public int birthday_week;
    public string pronouns;
    public int current_Money;
    //Time
    public int startYear;
    public int currentYear;
    public int currentWeek;

    //Stats
    public int availablePoints = 50;
    public int livePerformance = 0;
    public int songWriting = 0;
    public int vocals = 0;
    public int producing = 0;
    public RegionalPopularity popularity;

    // Projects!
    public List<SongData> songs = new List<SongData>();
    public List<AlbumData> albums = new List<AlbumData>();
    public List<SoundtrackData> soundtracks = new List<SoundtrackData>();
    public List<MixtapeData> mixtapes = new List<MixtapeData>();
    public List<EPData> eps = new List<EPData>();

    //Others
    public Job_Data currentJob;
}