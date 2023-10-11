using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRef : MonoBehaviour
{
    //Leftover code from when i tried to make the bombs despawn themselves after 15 seconds.
    //It didn't work and I did not have time to figure out why it didn't work.
    private float lifeTime = 15;

    private void Awake()
    {
        lifeTime =+ Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
