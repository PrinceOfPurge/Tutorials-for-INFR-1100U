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
    [SerializeField] private float Speed;

    public Rigidbody rb;
    public float walkSpeed = 5f;
    private float distanceToGround;
    bool isGrounded;
    public float jump = 5f;
    Vector2 move;
    Vector2 rotate;

    private Vector3 _moveDirection;
    // Start is called before the first frame update
    
    private void Awake(){
       
        InputManager.SetGameControls();
        rb = GetComponent<Rigidbody>();
        InputManager.Init(myPlayer:this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDirection;
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * (move.y * Time.deltaTime * walkSpeed),Space.Self);
            rb.AddForce(Vector3.forward * (move.x * Time.deltaTime * walkSpeed),Space.Self);
            isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>(). bounds.extents.y);
        }
    }

    public void Jump()
    {
        if (isGrounded){
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
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
