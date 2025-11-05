using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
            Debug.LogError("GameManager not found in scene!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Point"))
        {
            gameManager.score++;
            Debug.Log("Score increased: " + gameManager.score);
            Destroy(other.gameObject);
            gameManager.SaveGame();
        }
    }
}
