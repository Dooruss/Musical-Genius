using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    public TMP_InputField nameInput;

    private string selectedPronouns = "";

    private void Start()
    {
        nameInput.characterLimit = 20;
    }

    public void SelectPronouns(string pronouns)
    {
        selectedPronouns = pronouns;
    }

    public void ConfirmCharacter()
    {
        string playerName = nameInput.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Invalid name.");
            return;
        }

        foreach (char c in playerName)
        {
            if (!char.IsLetterOrDigit(c))
            {
                Debug.Log("Only letters and numbers allowed.");
                return;
            }
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