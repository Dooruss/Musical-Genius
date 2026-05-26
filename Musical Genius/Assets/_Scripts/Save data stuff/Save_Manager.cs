using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public SaveData currentSave;
    public int currentSlot;

    void Awake()
    {
        Instance = this;
    }

    public void Load(int slot)
    {
        currentSlot = slot;
        currentSave = SaveSystem.LoadGame(slot);
    }

    public void Save()
    {
        SaveSystem.SaveGame(currentSave, currentSlot);
    }
}