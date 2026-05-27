using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PractiseUI : MonoBehaviour
{
    public ErrorPopup popup;
    public Image VocalsImage;
    public Image SongwritingImage;
    public Image LivePerformanceImage;
    public Image ProducingImage;
    public TMP_Text moneyText;

    #region Button Functions
    public void PractiseVocals(int cost)
    {
        Practise("Vocals", cost);
    }

    public void PractiseSongWriting(int cost)
    {
        Practise("SongWriting", cost);
    }

    public void PractiseProducing(int cost)
    {
        Practise("Producing", cost);
    }

    public void PractiseLivePerformance(int cost)
    {
        Practise("LivePerformance", cost);
    }
    #endregion
    // Main function
    private void Start()
    {
        StatsPhotoUpdate();
    }

    private void Practise(string statType, int cost)
    {
        var data = SaveManager.Instance.currentSave;

        // CHECK MAX

        if (CheckIfMaxed(statType))
        {
            popup.ShowError("This stat is already maxed out.");
            return;
        }

        // CHECK MONEY

        if (data.current_Money < cost)
        {
            popup.ShowError("Not enough money to practise.");
            return;
        }

        // DETERMINE STAT GAIN

        int statGain = 0;

        switch (cost)
        {
            case 100:
                statGain = 1;
                break;

            case 500:
                statGain = 5;
                break;

            case 1000:
                statGain = 10;
                break;

            default:
                popup.ShowError("Invalid practise cost.");
                return;
        }

        // REMOVE MONEY

        data.current_Money -= cost;

        // ADD STAT

        switch (statType)
        {
            case "LivePerformance":

                data.livePerformance += statGain;
                if (data.livePerformance > 100) data.livePerformance = 100;
                break;

            case "SongWriting":
                data.songWriting += statGain;
                if (data.songWriting > 100) data.songWriting = 100;
                break;

            case "Vocals":

                data.vocals += statGain;
                if (data.vocals > 100) data.vocals = 100;
                break;

            case "Producing":

                data.producing += statGain;
                if (data.producing > 100) data.producing = 100;
                break;
        }

        // SAVE
        StatsPhotoUpdate();
        SaveManager.Instance.Save();
    }

    // Max check

    private bool CheckIfMaxed(string statType)
    {
        var data = SaveManager.Instance.currentSave;

        switch (statType)
        {
            case "LivePerformance":
                return data.livePerformance >= 100;

            case "SongWriting":
                return data.songWriting >= 100;

            case "Vocals":
                return data.vocals >= 100;

            case "Producing":
                return data.producing >= 100;
        }

        return false;
    }

    // Update UI
    public void StatsPhotoUpdate()
    {
        var data = SaveManager.Instance.currentSave;
        VocalsImage.fillAmount = data.vocals / 100f;
        SongwritingImage.fillAmount = data.songWriting / 100f;
        LivePerformanceImage.fillAmount = data.livePerformance / 100f;
        ProducingImage.fillAmount = data.producing / 100f;
        moneyText.text = "$" + data.current_Money.ToString("N0", new CultureInfo("nl-NL"));
    }
}