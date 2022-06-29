using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    public Transform CameraTransform;
    public float speed = 12f;
    public float gravity = -9.81f;
    public
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    // Update is called once per frame

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 forwardmove = CameraTransform.forward;
        forwardmove.y = 0;
        Vector3 rightmove = CameraTransform.right;
        Vector3 move = rightmove*x+forwardmove*z;

        controller.Move(move*speed*Time.deltaTime);
        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}