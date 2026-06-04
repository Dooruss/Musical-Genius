using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC_Artist", menuName = "Scriptable Objects/NPC_Artist")]
public class NPCArtist : ScriptableObject
{
    //info
    public string artistID;
    [Header("Info")]
    public string npcName;
    public string npcStageName;
    public int npcAge;
    public int npcBirthdayWeek;
    public string pronouns;
    public Sprite artistPhoto;
    public string currentLabel;

    [Header("Songs & Projects")]
    // Songs & projects
    public List<SongData> songs = new List<SongData>();
    public List<AlbumData> albums = new List<AlbumData>();

    // UPCOMING FEATURES:
    // EPS here
    // Mixtapes here
    // Soundtracks here

    //stats max of 100 for all
    [Header("Popularity & Charts")]
    public RegionalPopularity popularity;
    public int AveragePopularity { get { return(popularity.africa + popularity.asia + popularity.europe + popularity.northAmerica + popularity.southAmerica + popularity.australia) / 6; } }
    public List<ChartHistory> chartHistory = new List<ChartHistory>();
}
