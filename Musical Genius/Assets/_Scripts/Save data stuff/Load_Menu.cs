using UnityEngine;

public class LoadMenu : MonoBehaviour
{
    public GameObject[] saveInfoPanels;

    void Start()
    {
        LoadSaveSlots();
    }

    void LoadSaveSlots()
    {
        for (int i = 1; i < 3; i++)
        {
            SaveSlotUI ui = saveInfoPanels[i - 1].GetComponent<SaveSlotUI>();
            if (SaveSystem.SaveExists(i))
            {
                SaveData data = SaveSystem.LoadGame(i);
                ui.Setup(data);
            } else
            {
                ui.SetupEmpty(i);
            }
        }
    }
}