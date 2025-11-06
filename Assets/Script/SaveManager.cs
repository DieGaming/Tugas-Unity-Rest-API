using UnityEngine;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public int score;
    public string currentLevel = "Level_1";

    private async void Start()
    {
        SaveData data = await SaveSystemREST.LoadGame();

        player.position = new Vector3(data.X, data.Y, data.Z);
        score = data.PlayerScore;
        currentLevel = data.CurrentLevel;
    }

    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            await SaveGame();

        if (Input.GetKeyDown(KeyCode.F9))
            await LoadGame();
    }

    public async Task SaveGame()
    {
        SaveData data = new SaveData
        {
            X = player.position.x,
            Y = player.position.y,
            Z = player.position.z,
            PlayerScore = score,
            CurrentLevel = currentLevel
        };

        await SaveSystemREST.SaveGame(data);

        return;
    }

    public async Task LoadGame()
    {
        SaveData data = await SaveSystemREST.LoadGame();

        player.position = new Vector3(data.X, data.Y, data.Z);
        score = data.PlayerScore;
        currentLevel = data.CurrentLevel;

        return;
    }
}
