using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed ;
        Vector2 move;
        Vector2 rotate;
        Rigidbody rb;
    private float distanceToGround;
     bool isGrounded;
     public float jump = 5f;
    public float walkSpeed = 5f;
    
    

    private Vector3 _moveDirection;
    // Start is called before the first frame update
    
    private void Awake(){
        InputManager.Init(this);
        InputManager.SetGameControls();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=Speed * Time.deltaTime * _moveDirection;
        
        {
            isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>(). bounds.extents.y);
        }
    }

    public void Jump()
    {
        if (isGrounded){
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        rb.AddForce(Vector3.forward * (move.y * Time.deltaTime * walkSpeed), ForceMode.Impulse);
        }
    }
    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDirection = newDirection;
    }
    
    internal void SetMovementDirection(Func<Vector3> readValue)
    {
        throw new NotImplementedException();
    }
}
