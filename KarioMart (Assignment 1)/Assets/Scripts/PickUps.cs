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
    //debug vars
    //public Transform bombPos;

    // Update is called once per frame
    void Update()
    {
        if (hasBomb)
        {
            bombUISprite.SetActive(true);
        }

        if (hasBomb && Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Collider collider in Physics.OverlapSphere(transform.position, bombRadius))
            {
                if (collider.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody targetRB = collider.GetComponent<Rigidbody>();
                    targetRB.AddExplosionForce(bombForce, transform.position, bombRadius);
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
