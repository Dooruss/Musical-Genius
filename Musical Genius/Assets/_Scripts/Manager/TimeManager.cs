using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public int currentWeek = 1;

    public int currentYear = 2000;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdvanceWeek()
    {
        int slot = Game_Manager.Instance.currentSlot;
        SaveData data = SaveSystem.LoadGame(slot);

        data.currentWeek++;
        currentWeek = data.currentWeek;

        if (currentWeek > 52)
        {
            currentWeek = 1;
            currentYear++;
            data.age++;
        }

        data.currentWeek = currentWeek;
        data.currentYear = currentYear;

        SaveSystem.SaveGame(data, slot);
        checkUpcomingReleases();

        //Debug.Log("Week " + currentWeek + ", Year " + currentYear);
    }

    public void LoadTimeFromSave()
    {
        int slot = Game_Manager.Instance.currentSlot;
        SaveData data = SaveSystem.LoadGame(slot);
        currentWeek = data.currentWeek;
        currentYear = data.currentYear;
        Debug.Log("Loaded Time: Week " + currentWeek + ", Year " + currentYear);
    }

    public void checkUpcomingReleases()
    {
        int slot = Game_Manager.Instance.currentSlot;
        SaveData data = SaveSystem.LoadGame(slot);
        Debug.Log("Checking for upcoming releases for Week " + currentWeek + ", Year " + currentYear);
        foreach (SongData song in data.songs)
        {
            if (song.upcomingRelease && song.releaseWeek == currentWeek && song.releaseYear == currentYear)
            {
                song.upcomingRelease = false;
                song.isReleased = true;
                Debug.Log("Released: " + song.songName);
            }
        }
        SaveSystem.SaveGame(data, slot);
    }
}