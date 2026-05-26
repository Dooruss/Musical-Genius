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
        var save = SaveManager.Instance.currentSave;

        save.currentWeek++;
        currentWeek = save.currentWeek;
        checkBirthday();

        if (currentWeek > 52)
        {
            currentWeek = 1;
            currentYear++;
        }

        save.currentWeek = currentWeek;
        save.currentYear = currentYear;

        SaveManager.Instance.Save();
        checkUpcomingReleases();

        //Debug.Log("Week " + currentWeek + ", Year " + currentYear);
    }

    public void LoadTimeFromSave()
    {
        var save = SaveManager.Instance.currentSave;
        currentWeek = save.currentWeek;
        currentYear = save.currentYear;
        Debug.Log("Loaded Time: Week " + currentWeek + ", Year " + currentYear);
    }

    public void checkUpcomingReleases()
    {
        Debug.Log("Checking for upcoming releases for Week " + currentWeek + ", Year " + currentYear);
        var save = SaveManager.Instance.currentSave;
        foreach (SongData song in save.songs)
        {
            if (song.upcomingRelease && song.releaseWeek == currentWeek && song.releaseYear == currentYear)
            {
                song.upcomingRelease = false;
                song.isReleased = true;
                Debug.Log("Released: " + song.songName);
            }
        }
        SaveManager.Instance.Save();
    }

    public void checkBirthday()
    {
        var save = SaveManager.Instance.currentSave;
        if (save.birthday_week == currentWeek)
        {
            Debug.Log("Happy Birthday " + save.playerName + "! You are now " + (save.age + 1) + " years old!");
            save.age += 1;
            SaveManager.Instance.Save();
        }
    }
}