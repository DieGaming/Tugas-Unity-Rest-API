using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;


public static class SaveSystemREST
{
    private static string baseUrl = "http://localhost:5254/Save";

    public static async Task SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data);

        using (UnityWebRequest req = UnityWebRequest.PostWwwForm(baseUrl, ""))
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bytes);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");

            await req.SendWebRequest();
            Debug.Log(req.downloadHandler.text);
        }
    }

    public static async Task<SaveData> LoadGame()
    {
        using (UnityWebRequest req = UnityWebRequest.Get(baseUrl))
        {
            await req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Load failed: " + req.error);
                return new SaveData();
            }

            return JsonUtility.FromJson<SaveData>(req.downloadHandler.text);
        }
    }
}
