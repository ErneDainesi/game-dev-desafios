using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(1f, 2000f)] private float movementForce = 50f;
    [SerializeField] [Range(1f, 200f)] private float maxSpeed = 5f;
    [SerializeField] [Range(1f, 200f)] private float jumpForce = 7f;
    public float MaxSpeed { get => maxSpeed; }
    private Rigidbody myRigidbody;
    private float cameraAxisX = 0f;
    private Vector3 playerDirection;
    private bool onGround = true;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RotatePlayer();
        ManagePlayerDirection();
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }
    
    private void FixedUpdate()
    {
        if (playerDirection != Vector3.zero && myRigidbody.velocity.magnitude < MaxSpeed)
        {
            myRigidbody.AddForce(transform.TransformDirection(playerDirection) * movementForce, ForceMode.Force);
        }
    }

    private void ManagePlayerDirection()
    {
        playerDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) playerDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) playerDirection += Vector3.back;
        if (Input.GetKey(KeyCode.D)) playerDirection += Vector3.right;
        if (Input.GetKey(KeyCode.A)) playerDirection += Vector3.left;
    }
    
    private void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2.5f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
