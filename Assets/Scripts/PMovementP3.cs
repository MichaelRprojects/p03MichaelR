using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovementP3 : MonoBehaviour
{
    public CharacterController controller;

    //12 24 14 22 8 12.5 8 14
    float speed = 8f;
    float runspeed = 14f;

    //was-9.8
    float gravity = -22.8f;
    //was 3
    float jumpHeight = 6.5f;
    int jumpnum = 2;
    float airslow = 1f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //controller.Move(move * speed * Time.deltaTime);
        controller.Move(move * (speed/airslow) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //if (jumpnum >= 2)
            //{
                velocity += Mathf.Sqrt(jumpHeight * -2f * gravity) * Vector3.up;
            //}
            jumpnum = 1;
        }
        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            if (jumpnum >= 1)
            {
                velocity.y = 0;
                velocity += Mathf.Sqrt(jumpHeight * -2f * gravity) * Vector3.up;
                jumpnum = 0;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(isGrounded)
        {
            airslow = 1f;
            jumpnum = 2;
        }

        if (!isGrounded)
        {
            //was 2 1.75
            airslow = 1.4f;
        }

        if (isGrounded && velocity.y < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetAxis("Vertical") >0)
                {
                    Setspeed2();
                }
                if (Input.GetAxis("Vertical") < 0)
                {
                    speed = 12f;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
        }

    }
    public void Setspeed2()
    {
        speed = runspeed;
    }
}