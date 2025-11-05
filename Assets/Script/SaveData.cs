using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public int playerScore;
    public string currentLevel;

    // Add more fields here (e.g., inventory, stats)
}