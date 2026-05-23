using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TMP_Text timeText;

    void Update()
    {
        timeText.text = "Week " + TimeManager.Instance.currentWeek + ", Year " + TimeManager.Instance.currentYear;
    }
}