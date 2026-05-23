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
        currentWeek++;

        if (currentWeek > 52)
        {
            currentWeek = 1;

            currentYear++;
        }

        Debug.Log("Week " + currentWeek + ", Year " + currentYear);
    }
}