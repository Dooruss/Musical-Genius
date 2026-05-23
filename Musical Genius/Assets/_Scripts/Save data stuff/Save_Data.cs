using System;
using System.Collections.Generic;

[Serializable] //to tell that this class can be turned into a JSON
public class SaveData
{
    //Stores the player's name and pronouns for saving/loading purposes
    public string playerName;
    public string pronouns;
    public int current_Money;

    public List<SongData> songs = new List<SongData>();
}