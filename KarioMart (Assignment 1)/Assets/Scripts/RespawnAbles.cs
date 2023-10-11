using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RespawnAbles : MonoBehaviour
{
    public List<GameObject> spawnPositions;
    private List<GameObject> currentlySpawnedBombs;
    public float spawnTime = 2;
    private float timeVar;
    void Update()
    {
        if (Time.time >= timeVar)
        {
            Debug.Log("spawn");
            timeVar = Time.time + spawnTime;
            foreach (GameObject spawns in spawnPositions)
            {
                GameObject bombSpawn = Instantiate(Resources.Load<GameObject>("Bomb"), spawns.transform.position, Quaternion.Euler(0, 0, 0));
                currentlySpawnedBombs.Add(bombSpawn);
            }
            foreach (GameObject spawnedBombs in currentlySpawnedBombs)
            {
                Destroy(spawnedBombs);
            }
        }
    }
}
