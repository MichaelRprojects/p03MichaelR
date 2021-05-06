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
    public static bool stpWllRn = false;
    bool walltimed = false;
    bool walltimed2 = true;
    bool walltimed3 = true;

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
    public static bool pwltilt = false;

    public static Vector3 walldir;
    public static Vector3 walldir2;

    [SerializeField] AudioClip Jmp1S = null;
    [SerializeField] AudioClip Jmp2S = null;
    [SerializeField] AudioClip FootsS = null;

    bool playfoot = true;

    //was-9.8
    float gravity = -22.8f;
    //was 3
    float jumpHeight = 6.5f;
    int jumpnum = 2;
    bool rwalljumpa = false;
    bool lwalljumpa = false;
    bool fwalljumpa = false;
    bool rwjmping = false;
    bool lwjmping = false;
    bool fwjmping = false;
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
            //&& hit.normal.y < .05f
            if (WallD.pisRWallrun == true)
            {
                walldir2 = hit.normal;
                //Debug.Log("wny:" + walldir2);
                //1.297
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
            //AHlpr.PlayClip2D(Jmp1S);
            velocity += Mathf.Sqrt(jumpHeight * -2f * gravity) * Vector3.up;
            jumpnum = 1;
        }
        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            if (jumpnum >= 1)
            {
                //AHlpr.PlayClip2D(Jmp2S);
                velocity.y = 0;
                velocity += Mathf.Sqrt(jumpHeight * -2f * gravity) * Vector3.up;

                if (WallD.pisRWallrun == false)
                {
                    if (WallD3.pisLWallrun == false)
                    {
                        if (WallD2.pisFWallrun == false)
                        {
                            AHlpr.PlayClip2D(Jmp2S);
                        }
                    }
                }

                if (rwalljumpa == true)
                {
                    rwjmping = true;
                    //velocity += Mathf.Sqrt(jumpHeight * -2f * gravity) * -Vector3.right;
                    //controller.Move(-transform.right * 400f * Time.deltaTime);
                }
                if (lwalljumpa == true)
                {
                    lwjmping = true;
                }
                if (fwalljumpa == true)
                {
                    if (rwalljumpa == false)
                    {
                        fwjmping = true;
                    }
                    if (lwalljumpa == false)
                    {
                        fwjmping = true;
                    }
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
        if (lwjmping == true)
        {
            controller.Move(walldir2 * speed * 6f * Time.deltaTime);
            controller.Move(transform.forward * 18f * Time.deltaTime);
            controller.Move(transform.up * 18f * Time.deltaTime);
            DlHlpr.DelayAction(this, lwjmpingf, .25f);
        }
        if (fwjmping == true)
        {
            //if (rwjmping == false)
            //{
                controller.Move(-transform.forward * 18f * Time.deltaTime);
                controller.Move(transform.up * 18f * Time.deltaTime);
                DlHlpr.DelayAction(this, fwjmpingf, .5f);
            //}
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //if (jumpnum >= 1)
            //{
                AHlpr.PlayClip2D(Jmp1S);
            //}
        }

        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            if (WallD.pisRWallrun == true)
            {
                AHlpr.PlayClip2D(Jmp1S);
            }
            if (WallD3.pisLWallrun == true)
            {
                AHlpr.PlayClip2D(Jmp1S);
            }
            if (WallD2.pisFWallrun == true)
            {
                AHlpr.PlayClip2D(Jmp1S);
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //recmove = move;
        //Debug.Log("sp:" + speed);
        //Debug.Log("sp:" + stpWllRn);

        if (isGrounded)
        {
            airslow = 1f;
            jumpnum = 2;
            pwrtilt = false;
            pwltilt = false;
            stopup = true;
            rwalljumpa = false;
            lwalljumpa = false;
            fwalljumpa = false;
            Vector3 lmove = move;
            //P3Timer.instance.EndT();
            walltimed = false;
            stpWllRn = false;
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
                        //12
                        speed = 8f;
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //12
            speed = 8f;
        }

        if (isGrounded || WallD.pisRWallrun == true || WallD3.pisLWallrun == true || WallD2.pisFWallrun == true)
        {
                if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
                {
                if (playfoot == true)
                {
                    AHlpr.PlayClip2D(FootsS);
                    playfoot = false;
                    DlHlpr.DelayAction(this, playfoott, .35f);
                }
                }
        }

        if (WallD.pisRWallrun == true)
        {
            if (!isGrounded)
            {
                //.05
                if (walldir2.y < .1f && walldir2.y > -.1f)
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
                        //.05
                        //if (walldir2.y < .1f && walldir2.y > -.1f)
                        //{
                        if (stpWllRn == false)
                        {
                            //if (P3Timer.ptimergoing == false)
                            //{
                            //P3Timer.instance.BeginT();
                            //}
                            //Debug.Log("sp:" + stpWllRn);
                            walltimed = true;
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

                            //Debug.Log("sp:" + speed);

                            //if (walldir.normalized.x > 0)
                            //{
                            //Vector3 Lerpdirec = Vector3.Lerp(transform.right, walldir2, 20f * Time.deltaTime);
                            //Debug.DrawLine(transform.right, walldir2, Color.blue, 1f);
                            //transform.rotation = Quaternion.FromToRotation(Vector3.right, Lerpdirec);
                            //Vector3 Lerpdirec = Vector3.Lerp(transform.right, walldir.normalized, 2f * Time.deltaTime);
                            //transform.rotation = Quaternion.FromToRotation(Vector3.right, Lerpdirec);
                            //transform.rotation = Quaternion.FromToRotation(-Vector3.right, walldir2);
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
                        //}
                    }
                    if (velocity.y <= 0)
                    {
                        //.8
                        gravity = -1.8f;
                    }
                }

            }
        }

        if (WallD3.pisLWallrun == true)
        {
            if (!isGrounded)
            {
                //.05
                if (walldir2.y < .1f && walldir2.y > -.1f)
                {
                    //Debug.Log("Left");
                    pwltilt = true;
                    if (Input.GetAxis("Vertical") > 0)
                    {
                        if (stpWllRn == false)
                        {
                            //if (P3Timer.ptimergoing == false)
                            //{
                            //P3Timer.instance.BeginT();
                            //}
                            walltimed = true;
                            if (stopup == true)
                            {
                                velocity.y = 0;
                                stopup = false;
                            }

                            jumpnum = 2;

                            lwalljumpa = true;

                            controller.Move(transform.forward * wallspeed * Time.deltaTime);
                            //24
                            controller.Move(-transform.right * 24f * Time.deltaTime);
                            if (velocity.y == 0)
                            {
                                //.8
                                gravity = -1.8f;
                            }
                        }
                    }
                    if (velocity.y <= 0)
                    {
                        //.8
                        gravity = -1.8f;
                    }
                }
            }
        }

        if (WallD2.pisFWallrun == true)
        {
            if (!isGrounded)
            {
                //.05
                if (walldir2.y < .1f && walldir2.y > -.1f)
                {
                    //fwalljumpa = true;
                    if (Input.GetAxis("Vertical") > 0)
                    {
                        if (stpWllRn == false)
                        {
                            //if (P3Timer.ptimergoing == false)
                            //{
                            //P3Timer.instance.BeginT();
                            //}
                            walltimed = true;
                            jumpnum = 2;
                            velocity.y = 5f;
                            //if (stopup == true)
                            //{
                            //velocity.y = 0;
                            //stopup = false;
                            //}
                            fwalljumpa = true;
                            if (velocity.y == 0)
                            {
                                //.8
                                gravity = -1.8f;
                            }
                        }
                    }
                    if (velocity.y <= 0)
                    {
                        //.8
                        gravity = -1.8f;
                    }
                }
            }
        }
        if (walltimed == true)
        {
            walltimed3 = true;
            if (walltimed2 == true)
            {
                P3Timer.instance.BeginT();
                walltimed2 = false;
            }
        }
        if (walltimed == false)
        {
            walltimed2 = true;
            if (walltimed3 == true)
            {
                P3Timer.instance.EndT();
            }
        }
            //Debug.Log("right" + WallD.pisRWallrun);
            //Debug.Log("left" + WallD3.pisLWallrun);
            //Debug.Log("forward" + WallD2.pisFWallrun);
        if (WallD.pisRWallrun == false)
        {
            pwrtilt = false;
            stopup = true;
            gravity = -22.8f;
            rwalljumpa = false;
            walltimed = false;
            //P3Timer.instance.EndT();
        }
        if (WallD3.pisLWallrun == false)
        {
            pwltilt = false;
            stopup = true;
            gravity = -22.8f;
            lwalljumpa = false;
            walltimed = false;
            //P3Timer.instance.EndT();
        }
        if (WallD2.pisFWallrun == false)
        {
            stopup = true;
            gravity = -22.8f;
            fwalljumpa = false;
            walltimed = false;
            //P3Timer.instance.EndT();
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
    void lwjmpingf()
    {
        lwjmping = false;
    }
    void fwjmpingf()
    {
        fwjmping = false;
    }
    void playfoott ()
    {
        playfoot = true;
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
