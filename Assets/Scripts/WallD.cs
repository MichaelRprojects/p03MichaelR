using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallD : MonoBehaviour
{
    public static bool pisRWallrun = false;
    Collider ocollider;
    float size;
    float rotyw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    //public void OnCollisionEnter(Collision collision)
    {
        if (other.gameObject.layer == 6)
       //if (other.tag == "Enviormentt")
        {
            ocollider = other.GetComponent<Collider>();
            //size = ocollider.bounds.size.y;
            //Debug.Log(size);
            //rotyw = other.transform.rotation.eulerAngles.y;
            //Debug.Log(rotyw);
            if (ocollider.bounds.size.y > 1.1f)
            {
                if(other.transform.rotation.eulerAngles.y == 0)
                {
                    pisRWallrun = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pisRWallrun = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
