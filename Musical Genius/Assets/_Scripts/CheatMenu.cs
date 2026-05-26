using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheatMenu : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField input;

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.f1Key.wasPressedThisFrame)
        {
            panel.SetActive(!panel.activeSelf);
            Debug.Log("Cheat menu toggled");
        }

        //do it
        if (Keyboard.current.enterKey.wasPressedThisFrame && panel.activeSelf)
        {
            ExecuteCommand();
        }
    }

    public void ExecuteCommand()
    {
        string command = input.text;
        string[] parts = command.Split(' ');
        string cmd = parts[0].ToLower();

        switch (cmd)
        {
            case "setmoney":
                SetMoney(int.Parse(parts[1]));
                break;
            case "checkupcomingreleases":
                CheckUpcomingReleases();
                break;
            case "advancetime":
                AdvanceTime(int.Parse(parts[1]));
                break;
            case "checkstat":
                checkStat(parts[1]);
                break;
            case "setstat":
                Setstats(parts[1], int.Parse(parts[2]));
                break;
            default:
                Debug.Log("Unknown command." + cmd);
                break;
        }
    }

    #region Setting stuff
    public void SetMoney(int amount)
    {
        var data = SaveManager.Instance.currentSave;
        data.current_Money = amount;
        SaveManager.Instance.Save();
    }

    public void AdvanceTime(int weeks)
    {
        for (int i = 0; i < weeks; i++)
        {
            TimeManager.Instance.AdvanceWeek();
        }
    }

    public void Setstats(string stat, int value)
    {
        var data = SaveManager.Instance.currentSave;
        switch (stat.ToLower())
        {
            case "performance":
                data.livePerformance = value;
                break;
            case "writing":
                data.songWriting = value;
                break;
            case "vocals":
                data.vocals = value;
                break;
            case "producing":
                data.producing = value;
                break;
            default:
                Debug.Log("Unknown stat." + stat);
                break;
        }
        checkIllegallStats();
        SaveManager.Instance.Save();
    }
    #endregion

    #region Checking Stuff
    public void CheckUpcomingReleases()
    {
        SaveData data = SaveManager.Instance.currentSave;
        foreach (SongData song in data.songs)
        {
            if (song.upcomingRelease && song.releaseYear == TimeManager.Instance.currentYear && song.releaseWeek == TimeManager.Instance.currentWeek)
            {
                Debug.Log("Upcoming release: " + song.songName + " on Week " + song.releaseWeek + ", Year " + song.releaseYear);
            }
        }
    }

    public void checkStat(string stat)
    {
        var data = SaveManager.Instance.currentSave;
        switch (stat.ToLower())
        {
            case "performance":
                Debug.Log("Live Performance: " + data.livePerformance);
                break;
            case "writing":
                Debug.Log("Song Writing: " + data.songWriting);
                break;
            case "vocals":
                Debug.Log("Vocals: " + data.vocals);
                break;
            case "producing":
                Debug.Log("Producing: " + data.producing);
                break;
            default:
                Debug.Log("Unknown stat." + stat);
                break;
        }
    }
    #endregion

    private void checkIllegallStats()
    {
        var data = SaveManager.Instance.currentSave;
        if (data.livePerformance < 0 || data.songWriting < 0 || data.vocals < 0 || data.producing < 0)
        {
            if (data.livePerformance < 0) data.livePerformance = 0;
            if (data.songWriting < 0) data.songWriting = 0;
            if (data.vocals < 0) data.vocals = 0;
            if (data.producing < 0) data.producing = 0;
        }
        if (data.livePerformance > 100 || data.songWriting > 100 || data.vocals > 100 || data.producing > 100)
        {
            if (data.livePerformance > 100) data.livePerformance = 100;
            if (data.songWriting > 100) data.songWriting = 100;
            if (data.vocals > 100) data.vocals = 100;
            if (data.producing > 100) data.producing = 100;
        }
    }
}
