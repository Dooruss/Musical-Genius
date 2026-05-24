using UnityEngine;
using TMPro;
using System.Globalization; 

public class SaveSlotUI : MonoBehaviour
{
    [Header("UI Text References")]
    public TMP_Text nameText;
    public TMP_Text moneyText;
    public TMP_Text timeText;

    public void Setup(SaveData data)
    {
        nameText.text = data.playerName;
        moneyText.text = "$" + data.current_Money.ToString("N0", new CultureInfo("nl-NL"));
        timeText.text = "Week " + data.currentWeek + ", " + data.currentYear;
    }

    public void SetupEmpty(int slotIndex)
    {
        nameText.text = "Empty Slot";
        moneyText.text = "";
        timeText.text = "Slot " + slotIndex;
    }
}