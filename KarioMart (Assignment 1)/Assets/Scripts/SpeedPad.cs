using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPad : MonoBehaviour
{
    //Speedpad, just activates a function inside of the playermovement script, simple, doesn't need to be complicated
    private void OnTriggerEnter(Collider other)
    {
       PlayerMovement playermovement = other.GetComponent<PlayerMovement>();
       if (playermovement != null)
       {
           playermovement.StartCoroutine("SpeedBoost");
           Debug.Log("PlayerMovement found");
       }
    }
    
    //Hardcoded speedboost, simply checks if the player has collided with it and then runs a courountine in the playermovement script.
}
