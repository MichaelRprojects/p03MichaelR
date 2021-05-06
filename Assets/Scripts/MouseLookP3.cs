using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookP3 : MonoBehaviour
{
    public Transform playerBody;
    float xRotation = 0f;
    float camtilt = 0f;
    float rwmxcamtilt = 25f;
    float lwmxcamtilt = -25f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if (PMovement.isdead == false)
        //{
            //was *500f * Time.deltaTime; at end next 2
            float mouseX = Input.GetAxis("Mouse X") * 5f;
            float mouseY = Input.GetAxis("Mouse Y") * 5f;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            if (PMovementP3.pwrtilt == false)
            {
                //transform.localRotation = Quaternion.Euler(xRotation, 0f, camtilt);
                if (camtilt > 0)
                {
                //camtilt += Time.deltaTime * -rwmxcamtilt * 2;
                }
            }
            if (PMovementP3.pwrtilt == true)
            {
                transform.localRotation = Quaternion.Euler(xRotation, 0f, camtilt);
                if (camtilt < rwmxcamtilt)
                {
                //2
                    camtilt += Time.deltaTime * rwmxcamtilt * 4;
                }
            }
        if (PMovementP3.pwltilt == false || PMovementP3.pwrtilt == false)
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, camtilt);
            if (camtilt > 0)
            {
                camtilt += Time.deltaTime * -rwmxcamtilt * 2;
            }
            if (camtilt < 0)
            {
                camtilt += Time.deltaTime * -lwmxcamtilt * 2;
            }
        }
        if (PMovementP3.pwltilt == true)
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, camtilt);
            if (camtilt > lwmxcamtilt)
            {
                //2
                camtilt += Time.deltaTime * lwmxcamtilt * 4;
            }
        }
        playerBody.Rotate(Vector3.up * mouseX);
        //}
        //if (PMovement.isdead == true)
        //{
            //Cursor.lockState = CursorLockMode.None;
        //}
    }
}
