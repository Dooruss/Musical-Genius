using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text Current_Chosen_PRNS;
    public ErrorPopup popup;

    private string selectedPronouns = "";

    private void Start()
    {
        nameInput.characterLimit = 20;
    }

    public void SelectPronouns(string pronouns)
    {
        selectedPronouns = pronouns;
        Current_Chosen_PRNS.text = "Current Pronouns: " + pronouns;
    }

    public void ConfirmCharacter()
    {
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

        if (string.IsNullOrEmpty(selectedPronouns))
        {
            popup.ShowError("Please select pronouns.");
            return;
        }

        SaveData data = new SaveData();

        data.playerName = playerName;
        data.pronouns = selectedPronouns;
        data.current_Money = 10000;

        SaveSystem.SaveGame(
            data,
            Game_Manager.Instance.currentSlot
        );

        SceneManager.LoadScene("GAME");
    }
}