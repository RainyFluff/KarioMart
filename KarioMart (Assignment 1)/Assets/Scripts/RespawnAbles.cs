using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RespawnAbles : MonoBehaviour
{
    public List<GameObject> spawnPositions;
    public float spawnTime = 15;
    private float timeVar;
    void Update()
    {
        if (Time.time >= timeVar)
        {
            Debug.Log("spawn");
            timeVar = Time.time + spawnTime;
            foreach (GameObject spawns in spawnPositions)
            {
                GameObject bombSpawn = Instantiate(Resources.Load<GameObject>("BombRef"), spawns.transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
    }
    //Simple code that through a list of gameobjects; instantiates more gameobjects on their transform.positions. 
    //This enables me to spawn the bombs at predetermined spots on the track after a certain of time has passed.
    //I tried to also make them despawn here through then making a list of all spawned objects and using another foreach loop to destroy them.
    //This did not work since List.add() did not function correctly when put in a foreach loop.
    //The bombs never actually despawn so if given enough time they will pool up and probably crash the program. But this would take quite a lot of time
    //Where both players would basically not be moving at all as to not touch the bombs
    //Would be an issue in a bigger project, should be fine for such a small project like this
}
