using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text pronounText;
    public TMP_Text moneyText;
    public GameObject[] gameUI;
    public GameObject[] SectionUI;
    public Image VocalsImage;
    public Image SongwritingImage;
    public Image LivePerformanceImage;
    public Image ProducingImage;

    private void Start()
    {

        var data = SaveManager.Instance.currentSave;

        if (data != null)
        {
            nameText.text = data.playerName;
            pronounText.text = data.pronouns + ", " + data.age;
            moneyText.text = "$" + data.current_Money.ToString("N0", new CultureInfo("nl-NL"));
            StatsPhotoUpdate();
        }
    }

    public void ToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MENU");
    }

    public void CloseAllUI(GameObject TurnOn)
    {
        foreach (GameObject go in gameUI)
        {
            go.SetActive(false);
        }
        TurnOn.SetActive(true);
    }

    public void CloseAllSection(GameObject TurnOn)
    {
        foreach(GameObject go in SectionUI)
        {
            go.SetActive(false);
        }   
        TurnOn.SetActive(true);
    }

    public void NextWeek()
    {
        TimeManager.Instance.AdvanceWeek();
        var data = SaveManager.Instance.currentSave;
        pronounText.text = data.pronouns + ", " + data.age;
        moneyText.text = "$" + data.current_Money.ToString("N0", new CultureInfo("nl-NL"));
        StatsPhotoUpdate();
    }

    public void StatsPhotoUpdate()
    {
        var data = SaveManager.Instance.currentSave;
        VocalsImage.fillAmount = data.vocals / 100f;
        SongwritingImage.fillAmount = data.songWriting / 100f;
        LivePerformanceImage.fillAmount = data.livePerformance / 100f;
        ProducingImage.fillAmount = data.producing / 100f;
    }
}