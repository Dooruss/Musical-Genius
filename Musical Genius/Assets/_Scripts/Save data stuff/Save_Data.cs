using System;

[Serializable] //to tell that this class can be turned into a JSON
public class SaveData
{
    //Stores the player's name and pronouns for saving/loading purposes
    public string playerName;
    public string pronouns;
}