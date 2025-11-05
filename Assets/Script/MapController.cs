using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Header("Terrain Settings")]
    public List<GameObject> terrainChunk;
    public GameObject Player;
    public float CheckerRadius;
    public LayerMask TerrainMask;

    [Header("Optimization")]
    public List<GameObject> SpawnedChunk;
    GameObject lastestChunk;
    public float MaxOpDist;
    float OpDist;
    float optimizerCoolDown;
    public float OptimizationCoolDownDur;

    [Header("Runtime Info")]
    public GameObject CurrentChunk;

    private Vector3 noTerrainPosition;
    private PlayerMovement pm;

    void Start()
    {
        pm = FindAnyObjectByType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        if (!CurrentChunk) return;

        // --- RIGHT ---
        if (pm.moveDir.x > 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Right").position, CheckerRadius, TerrainMask))
            {
                noTerrainPosition = CurrentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        // --- LEFT ---
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Left").position, CheckerRadius, TerrainMask))
            {
                noTerrainPosition = CurrentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        // --- UP ---
        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Up").position, CheckerRadius, TerrainMask))
            {
                noTerrainPosition = CurrentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        // --- DOWN ---
        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Down").position, CheckerRadius, TerrainMask))
            {
                noTerrainPosition = CurrentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        // --- RIGHT-UP ---
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("RightUp").position, CheckerRadius, TerrainMask))
            {
                noTerrainPosition = CurrentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }
        }
        // --- LEFT-UP ---
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("LeftUp").position, CheckerRadius, TerrainMask))
            {
                noTerrainPosition = CurrentChunk.transform.Find("LeftUp").position;
                SpawnChunk();
            }
        }
        // --- RIGHT-DOWN ---
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("RightDown").position, CheckerRadius, TerrainMask))
            {
                noTerrainPosition = CurrentChunk.transform.Find("RightDown").position;
                SpawnChunk();
            }
        }
        // --- LEFT-DOWN ---
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("LeftDown").position, CheckerRadius, TerrainMask))
            {
                noTerrainPosition = CurrentChunk.transform.Find("LeftDown").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = UnityEngine.Random.Range(0, terrainChunk.Count);
        lastestChunk = Instantiate(terrainChunk[rand], noTerrainPosition, quaternion.identity);
        SpawnedChunk.Add(lastestChunk);
    }

    void ChunkOptimizer()
    {
        optimizerCoolDown -= Time.deltaTime;

        if (optimizerCoolDown <= 0f)
        {
            optimizerCoolDown = OptimizationCoolDownDur;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in SpawnedChunk)

        {
            OpDist = Vector3.Distance(Player.transform.position, chunk.transform.position);
            if(OpDist > MaxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
