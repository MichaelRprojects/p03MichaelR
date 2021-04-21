using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookP3 : MonoBehaviour
{
    public Transform playerBody;
    float xRotation = 0f;
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

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        //}
        //if (PMovement.isdead == true)
        //{
            //Cursor.lockState = CursorLockMode.None;
        //}
    }
}
