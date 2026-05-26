using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TMP_InputField birthdayweekInput;
    public TMP_InputField startYearInput;
    public TMP_Text Current_Chosen_PRNS;
    public ErrorPopup popup;

    private string selectedPronouns = "";

    private void Start()
    {
        nameInput.characterLimit = 20;
        ageInput.characterLimit = 3;
        startYearInput.characterLimit = 4;
    }

    public void SelectPronouns(string pronouns)
    {
        selectedPronouns = pronouns;
        Current_Chosen_PRNS.text = "Current Pronouns: " + pronouns;
    }

    public void ConfirmCharacter()
    {
        // NAME
        string playerName = nameInput.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            popup.ShowError("Invalid name. Please enter a valid name.");
            return;
        }

        foreach (char c in playerName)
        {
            if (!char.IsLetterOrDigit(c))
            {
                popup.ShowError("Only Letters and numbers allowed");
                return;
            }
        }

        //PRONOUNS
        if (string.IsNullOrEmpty(selectedPronouns))
        {
            popup.ShowError("Please select pronouns.");
            return;
        }

        //AGE
        if (!int.TryParse(ageInput.text, out int age) || age < 15 || age > 90)
        {
            popup.ShowError("Invalid age. Please enter a valid age between 15 and 90.");
            return;
        }

        if (!int.TryParse(birthdayweekInput.text, out int birthdayWeek) || birthdayWeek < 1 || birthdayWeek > 52)
        {
            popup.ShowError("Invalid birthday week. Please enter a valid week between 1 and 52.");
            return;
        }

        //START YEAR
        if (!int.TryParse(startYearInput.text, out int startYear) || startYear < 1930)
        {
            popup.ShowError("Please enter a valid start year. It must be 1930 or later.");
            return;
        }

        //SAVING
        SaveData data = new SaveData();

        data.playerName = playerName;
        data.pronouns = selectedPronouns;
        data.age = age;
        data.birthday_week = birthdayWeek;
        data.startYear = startYear;
        data.current_Money = 10000;
        data.currentYear = startYear;
        data.currentWeek = 1;

        SaveManager.Instance.currentSave = data;
        SaveManager.Instance.Save();

        TimeManager.Instance.LoadTimeFromSave();

        SceneManager.LoadScene("GAME");
    }
}