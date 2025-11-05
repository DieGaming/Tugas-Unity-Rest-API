using System.Collections.Generic;
using UnityEngine;

public class PropsRandomizer : MonoBehaviour
{
    public List<GameObject> PropsSpawnPoint;
    public List<GameObject> ProbsPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps()
    {
        foreach (GameObject sp in PropsSpawnPoint)
        {
            int rand = Random.Range(0, ProbsPrefabs.Count);
            GameObject prop = Instantiate(ProbsPrefabs[rand], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }
}
