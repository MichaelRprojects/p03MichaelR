using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovementP3 : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam1;
    //public Transform startpos;
    float camtilt = 0f;
    float lmxcamtilt = 25f;

    bool isWallrun = false;
    public static bool pisWallrun = false; 

    //12 24 14 22 8 12.5 8 14
    float speed = 8f;
    float runspeed = 14f;

    //Vector3 recmove;
    Vector3 lmove;
    Vector3 move;
    //bool cmove = true;

    float wallspeed = 10f;

    bool stopup = true;
    public static bool pwrtilt = false;

    public static Vector3 walldir;
    public static Vector3 walldir2;


    //was-9.8
    float gravity = -22.8f;
    //was 3
    float jumpHeight = 6.5f;
    int jumpnum = 2;
    bool rwalljumpa = false;
    bool rwjmping = false;
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //!isgrounded
        if (!isGrounded)
        {
            if (WallD.pisRWallrun == true && hit.normal.y < .1f)
            {
                walldir2 = hit.normal;
                Debug.DrawRay(hit.point, walldir2, Color.red, 2.5f);
            }
        }
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

        //if (WallD.pisRWallrun == false)
        //{
        //if (isGrounded)
        //{
            Vector3 move = transform.right * x + transform.forward * z;
        //}
        //if (!isGrounded)
        //{
            //Vector3 move = transform.right * x + transform.forward * z + lmove;
        //}

        controller.Move(move * (speed / airslow) * Time.deltaTime);
        //}
        //if (WallD.pisRWallrun == true)
        //{
        //Vector3 move = transform.forward * z;
        //controller.Move(move * (speed / airslow) * Time.deltaTime);
        //}
        //}

        //Debug.DrawRay(hit.point, hit.normal, Color.red, 2.5f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Vector3 lmove = move;
            velocity += Mathf.Sqrt(jumpHeight * -2f * gravity) * Vector3.up;
            jumpnum = 1;
        }
        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            if (jumpnum >= 1)
            {
                velocity.y = 0;
                velocity += Mathf.Sqrt(jumpHeight * -2f * gravity) * Vector3.up;

                if (rwalljumpa == true)
                {
                    rwjmping = true;
                    //velocity += Mathf.Sqrt(jumpHeight * -2f * gravity) * -Vector3.right;
                    //controller.Move(-transform.right * 400f * Time.deltaTime);
                }

                jumpnum = 0;
            }
        }
        if (rwjmping == true)
        {
            controller.Move(walldir2 * speed * 6f * Time.deltaTime);
            controller.Move(transform.forward * 18f * Time.deltaTime);
            controller.Move(transform.up * 18f * Time.deltaTime);
            DlHlpr.DelayAction(this, rwjmpingf, .25f);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //recmove = move;

        if(isGrounded)
        {
            airslow = 1f;
            jumpnum = 2;
            pwrtilt = false;
            stopup = true;
            rwalljumpa = false;
            Vector3 lmove = move;
            //if (cmove == true)
            //{
                //movelm();
                //DlHlpr.DelayAction(this, cmovet, 1f);
            //}
            //Debug.Log("lmmmmmmmm:" + lmove);
            //Debug.Log("m:" + move);
            //Debug.Log("rrrrrrm:" + recmove);
            //Debug.Log("lm:" + lmove);
        }

        if (!isGrounded)
        {
            //was 2 1.75
            airslow = 1.4f;
            //Debug.Log("lm:" + lmove);
            //Debug.Log("m:" + move);
            //controller.Move(lmove * (speed / airslow) * 120f * Time.deltaTime);
        }

        if (isGrounded && velocity.y < 0)
        {
            if (WallD.pisRWallrun == false)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (Input.GetAxis("Vertical") > 0)
                    {
                        Setspeed2();
                    }
                    if (Input.GetAxis("Vertical") < 0)
                    {
                        speed = 12f;
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
        }



        if (WallD.pisRWallrun == true)
        {
            if (!isGrounded)
            {
                pwrtilt = true;
                //rwalljumpa = false;

                //Vector3 Lerpdirec = Vector3.Lerp(transform.right, walldir.normalized, 2f * Time.deltaTime);
                //*transform.rot
                //transform.rotation = Quaternion.FromToRotation(Vector3.right, Lerpdirec);

                //transform.rotation = Quaternion.FromToRotation(Vector3.right, Lerpdirec);

                //float pang = Vector3.Angle(walldir.normalized, transform.rotation);

                //Debug.Log(wallang);

                //Vector3 move2 = walldir.normalized * 10f * Time.deltaTime;

                //controller.Move(wallang * 20f * Time.deltaTime);

                //transform.localRotation = Quaternion.Euler(walldir.normalized);
                //if (velocity)
                if (Input.GetAxis("Vertical") > 0)
                {
                    if (stopup == true)
                    {
                        velocity.y = 0;
                        stopup = false;
                    }

                    jumpnum = 2;

                    rwalljumpa = true;

                    controller.Move(transform.forward * wallspeed * Time.deltaTime);
                    //24
                    controller.Move(transform.right * 24f * Time.deltaTime);

                    //if (walldir.normalized.x > 0)
                    //{
                    //Vector3 Lerpdirec = Vector3.Lerp(transform.right, walldir.normalized, 20f * Time.deltaTime);
                    //transform.rotation = Quaternion.FromToRotation(Vector3.right, Lerpdirec);
                    //Vector3 Lerpdirec = Vector3.Lerp(transform.right, walldir.normalized, 2f * Time.deltaTime);
                    //transform.rotation = Quaternion.FromToRotation(Vector3.right, Lerpdirec);
                    //transform.rotation = Quaternion.FromToRotation(-Vector3.right, walldir.normalized);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, walldir.normalized, 20f * Time.deltaTime);
                    //}
                    if (walldir.normalized.x < 0)
                    {
                        //transform.rotation = Quaternion.FromToRotation(Vector3.right, walldir.normalized);
                    }
                        //Vector3 wallang = Vector3.Cross(walldir.normalized, Vector3.up);
                        //controller.Move(transform.rotate.wallang);
                        //float wallangx = wallang.x;
                        //transform.rotation = Quaternion.FromToRotation(Vector3.right, wallang);
                        //transform.localEulerAngles = new Vector3(wallang);
                        //Debug.Log("W:" + wallang);
                        //if (wallang.x > -1)
                        //{
                        //Vector3 Lerpdirec = Vector3.Lerp(-transform.right, wallang, 2f * Time.deltaTime);
                        //Debug.Log("gL:" + Lerpdirec);
                        //transform.rotation = Quaternion.FromToRotation(Vector3.right, Lerpdirec);
                        //}
                        //if (wallang.x < -1)
                        //{
                        //Vector3 Lerpdirec = Vector3.Lerp(transform.right, wallang, 2f * Time.deltaTime);
                        //Debug.Log("lL:" + Lerpdirec);
                        //transform.rotation = Quaternion.FromToRotation(Vector3.right, Lerpdirec);
                        //}

                        //Debug.Log(wallang);
                        //Debug.Log(Lerpdirec);
                    if (velocity.y == 0)
                    {
                        //.8
                        gravity = -1.8f;
                    }
                }
                if (velocity.y <= 0)
                {
                    //.8
                    gravity = -1.8f;
                }

            }
        }
        if (WallD.pisRWallrun == false)
        {
            pwrtilt = false;
            stopup = true;
            gravity = -22.8f;
            rwalljumpa = false;
        }
    }
    public void Setspeed2()
    {
        speed = runspeed;
    }
    void rwjmpingf()
    {
        rwjmping = false;
    }
    void movelm()
    {
        //Vector3 lmove = recmove;
        //Debug.Log("lm:" + lmove);
        //cmove = false;
        //DlHlpr.DelayAction(this, cmovet, 1f);
    }
    void cmovet()
    {
        //cmove = true;
    }
}
