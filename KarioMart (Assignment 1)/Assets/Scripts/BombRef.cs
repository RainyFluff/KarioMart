using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRef : MonoBehaviour
{
    //Leftover code from when i tried to make the bombs despawn themselves after 15 seconds.
    //It didn't work and I did not have time to figure out why it didn't work.
    private float lifeTime;

    private void Awake()
    {
        lifeTime = 15 + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        if (Time.time == lifeTime)
        {
            Debug.Log("Destroyed");
            //Destroy(gameObject);
        }
    }
}
