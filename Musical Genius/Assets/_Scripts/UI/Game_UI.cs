using System.Globalization;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text pronounText;
    public TMP_Text moneyText;
    public GameObject[] gameUI;
    public GameObject[] SectionUI;

    private void Start()
    {
        int slot = Game_Manager.Instance.currentSlot;

        SaveData data = SaveSystem.LoadGame(slot);

        if (data != null)
        {
            nameText.text = data.playerName;
            pronounText.text = data.pronouns;
            moneyText.text = "$" + data.current_Money.ToString("N0", new CultureInfo("nl-NL"));
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
}