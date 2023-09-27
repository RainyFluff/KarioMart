using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove1 : MonoBehaviour
{
    private Rigidbody rb;

    public float force = 5;

    public float backForce = 3f;

    private float horizontalRotation;

    public float rotationSpeed = 0.001f;

    public float maxSpeed = 30f;

    public float maxBackSpeed = 18f;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(-transform.right*force, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.S) && rb.velocity.magnitude < maxBackSpeed)
        {
            rb.AddForce(transform.right*backForce, ForceMode.Acceleration);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0,-1*rotationSpeed);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,0,1*rotationSpeed);
        }
        
        
        
    }
}
