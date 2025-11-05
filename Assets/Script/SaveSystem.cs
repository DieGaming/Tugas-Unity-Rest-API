using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string savePath = Application.persistentDataPath + "/save.json";

    public static void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Game saved to: {savePath}");
    }

    public static SaveData LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("Save file not found, returning new SaveData.");
            return new SaveData();
        }

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        Debug.Log("Game loaded successfully.");
        return data;
    }

    public static void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save file deleted.");
        }
    }
}