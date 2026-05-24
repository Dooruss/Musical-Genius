using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // NEW GAME

    public void NewGame(int slot)
    {
        Game_Manager.Instance.currentSlot = slot;

        SceneManager.LoadScene("CHARACTER");
    }

    // LOAD GAME

    public void LoadGame(int slot)
    {
        if (SaveSystem.SaveExists(slot))
        {
            Game_Manager.Instance.currentSlot = slot;
            TimeManager.Instance.LoadTimeFromSave();

            SceneManager.LoadScene("GAME");
        }
        else
        {
            Debug.Log("No save in slot " + slot);
        }
    }
}