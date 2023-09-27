using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;

    public float force = 5;

    public InputActionReference move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var movementInput = move.action.ReadValue<Vector3>();
        
        rb.AddForce(movementInput * force, ForceMode.Acceleration);
        
        
        
        //Debug.DrawLine(transform.position, transform.forward, Color.red,2f);
    }

    private void OnMove()
    {
        Debug.Log("Move");
    }
}
