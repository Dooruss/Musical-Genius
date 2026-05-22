using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(SaveData data, int slot)
    {
        string path = GetSavePath(slot);

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, json);

        Debug.Log("Saved to slot " + slot);
    }

    public static SaveData LoadGame(int slot)
    {
        string path = GetSavePath(slot);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            return JsonUtility.FromJson<SaveData>(json);
        }

        return null;
    }

    public static bool SaveExists(int slot)
    {
        return File.Exists(GetSavePath(slot));
    }

    private static string GetSavePath(int slot)
    {
        return Application.persistentDataPath +
               "/save_slot_" + slot + ".json";
    }
}