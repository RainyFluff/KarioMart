using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    private bool hasBomb;
    public float bombForce = 100;
    public float bombRadius = 10;
    public GameObject bombUISprite;
    private RaycastHit hit;
    private Rigidbody rb;
    private PlayerMovement _playerMovement;
    private KeyCode usableKey;
    //All variables and a keycode for the bombs
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        //declaring important variables
    }

    void Update()
    {
        usableKey = _playerMovement.usable;
        if (hasBomb)
        {
            bombUISprite.SetActive(true);
        }
        else
        {
            bombUISprite.SetActive(false);
        }
 //decided to add the force from the bomb this way since its easy and accomplishes the effect im looking for.
        if (hasBomb && Input.GetKeyDown(usableKey))
        {
            foreach(Collider collider in Physics.OverlapSphere(transform.position, bombRadius))
            {
                if (collider.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody targetRB = collider.GetComponent<Rigidbody>();
                    targetRB.AddExplosionForce(bombForce, transform.position, bombRadius, 1);
                    if (targetRB == rb)
                    {
                        rb.AddExplosionForce(-bombForce, transform.position, bombRadius, 1);
                    }
                }
                Debug.Log(collider.transform);
            }
            hasBomb = false;
        }
        //bomb uses rb.addexplosiveforce
        //bomb ui sprite activate and deactivate
        //pickup on the map being respawnable
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bomb")
        {
            Destroy(other.gameObject);
            hasBomb = true;
        }
    }
}
