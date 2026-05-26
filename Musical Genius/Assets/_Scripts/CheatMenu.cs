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
            default:
                Debug.Log("Unknown command." + cmd);
                break;
        }
    }


    public void SetMoney(int amount)
    {
        var data = SaveManager.Instance.currentSave;
        data.current_Money = amount;
        SaveManager.Instance.Save();
    }

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

    public void AdvanceTime(int weeks)
    {
        for (int i = 0; i < weeks; i++)
        {
            TimeManager.Instance.AdvanceWeek();
        }
    }

}
