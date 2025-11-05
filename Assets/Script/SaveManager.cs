using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public int score;
    public string currentLevel = "Level_1";

    private void Start()
    {
        LoadGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            SaveGame();

        if (Input.GetKeyDown(KeyCode.F9))
            LoadGame();
    }

    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            playerPosition = player.position,
            playerScore = score,
            currentLevel = currentLevel
        };

        SaveSystem.SaveGame(data);
    }

    public void LoadGame()
    {
        SaveData data = SaveSystem.LoadGame();
        player.position = data.playerPosition;
        score = data.playerScore;
        currentLevel = data.currentLevel;
    }
}