using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    private bool hasBomb;
    public float bombForce;
    public GameObject bombUISprite;
    void Start()
    {
        //Get all components neccesary
    }

    // Update is called once per frame
    void Update()
    {
        //bomb uses rb.addexplosiveforce
        //bomb ui sprite activate and deactivate
        //pickup on the map being respawnable
    }
}
