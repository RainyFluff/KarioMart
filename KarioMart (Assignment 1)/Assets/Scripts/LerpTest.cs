using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
   private float currentTime;
   public float timeToMove = 2f;
   private Rigidbody _rb;
   public float maxSpeed = 10;
   public float backMaxSpeed = 7;
   private float xVelocity;
   public float rotationSpeed = 0.01f;
   public ParticleSystem speedTrails;
   private void Start()
   {
       _rb = GetComponent<Rigidbody>();
   }

   // Update is called once per frame
    void Update()
    {
        particleForces();
        if (Input.GetKey(KeyCode.W))
        {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.time;
                xVelocity = Mathf.Lerp(_rb.velocity.x, maxSpeed, currentTime / timeToMove);
                //Debug.Log(xVelocity);
                _rb.AddForce(transform.forward * xVelocity, ForceMode.Acceleration);
            }
            else
            {
                currentTime = 0;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            
                if (currentTime <= timeToMove)
                {
                    currentTime += Time.time;
                    xVelocity = Mathf.Lerp(_rb.velocity.x, -backMaxSpeed, currentTime / timeToMove);
                    //Debug.Log(xVelocity);
                    _rb.AddForce(transform.forward * xVelocity, ForceMode.Acceleration);
                }
                else
                {
                    currentTime = 0;
                }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,-1*rotationSpeed,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,1*rotationSpeed,0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Turbo());
        }
    }

    void particleForces()
    {
        var main = speedTrails.main;
        main.startSpeed = new ParticleSystem.MinMaxCurve(0,_rb.velocity.magnitude);
        Debug.Log(_rb.velocity.magnitude);
    }

    IEnumerator Turbo()
    {
        maxSpeed = maxSpeed * 2;
        yield return new WaitForSeconds(2);
        maxSpeed = maxSpeed / 2;
    }
}
