using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public bool isPlayerOne = true;
   private float currentTime;
   public float timeToMove = 2f;
   private Rigidbody _rb;
   public float maxSpeed = 10;
   public float backMaxSpeed = 7;
   private float xVelocity;
   public float rotationSpeed = 0.01f;
   private KeyCode forward;
   private KeyCode backward;
   private KeyCode right;
   private KeyCode left;
   public ParticleSystem speedTrails;
   private void Start()
   {
       
       _rb = GetComponent<Rigidbody>();
       
       //decided to make the different player inputs like this rather than implementing the Input System
       //reasoning: it didn't go well and I didn't wanna waste time on it, so this here is placeholder
       //Until I (hopefully) solve it.
       if (isPlayerOne)
       {
           forward = KeyCode.W;
           backward = KeyCode.S;
           right = KeyCode.D;
           left = KeyCode.A;
       }
       else if (!isPlayerOne)
       {
           forward = KeyCode.UpArrow;
           backward = KeyCode.DownArrow;
           right = KeyCode.RightArrow;
           left = KeyCode.LeftArrow;
       }
   }

   // Update is called once per frame
    void Update()
    {
        //particleForces();
        //forward and backward movement uses a lerp and addforce.forcemode.acelleration
        // This is because I wanted to give the player an increased sense of acelleration, starting really slow and then getting faster.
        if (Input.GetKey(forward)) {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.time;
                xVelocity = Mathf.Lerp(_rb.velocity.x, maxSpeed, currentTime / timeToMove);
                //Debug.Log(xVelocity);
                //The duck playermodels have some fucked up transforms, this can be changed by opening them up in blender
                //But I can't be bothered to learn blender enough to fix it so I chose to hardcode a solution.
                _rb.AddForce(-transform.right * xVelocity, ForceMode.Acceleration);
            }
            else
            {
                currentTime = 0;
            }
        }
        else if (Input.GetKey(backward))
        {
            
                if (currentTime <= timeToMove)
                {
                    currentTime += Time.time;
                    xVelocity = Mathf.Lerp(_rb.velocity.x, -backMaxSpeed, currentTime / timeToMove);
                    //Debug.Log(xVelocity);
                    _rb.AddForce(-transform.right * xVelocity, ForceMode.Acceleration);
                }
                else
                {
                    currentTime = 0;
                }
        }
        //very simple code to rotate the player left or right
        if (Input.GetKey(left))
        {
            transform.Rotate(0,0,-1*rotationSpeed);
        }
        if (Input.GetKey(right))
        {
            transform.Rotate(0,0,1*rotationSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Turbo());
        }
    }
   //wanted to add some speedlines to make it look prettier and give an increased sense of speed (feedback)
    /*void particleForces()
    {
        ParticleSystem.MainModule main = speedTrails.main;
        ParticleSystem.ForceOverLifetimeModule speedTrailsForce = speedTrails.forceOverLifetime;
        speedTrailsForce.x = Mathf.Abs(_rb.velocity.x);
        speedTrailsForce.z = _rb.velocity.z;
        Debug.Log(_rb.velocity.x);
        //main.startSpeed = new ParticleSystem.MinMaxCurve(0,_rb.velocity.magnitude);
        //Debug.Log(_rb.velocity.magnitude);
    }
    */
//a "turbo" or "sprint" that is incredibly simple
    IEnumerator Turbo()
    {
        maxSpeed = maxSpeed * 2;
        yield return new WaitForSeconds(2);
        maxSpeed = maxSpeed / 2;
    }
}
