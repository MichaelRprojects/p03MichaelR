using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallD2 : MonoBehaviour
{
    public static bool pisFWallrun = false;
    Collider ocollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //ontriger enter 
    public void OnTriggerStay(Collider other)
    //public void OnCollisionEnter(Collision collision)
    {
        if (other.gameObject.layer == 6)
        //if (other.tag == "Enviormentt")
        {
            ocollider = other.GetComponent<Collider>();
            if (ocollider.bounds.size.y > 1.1f)
            {
                //chwdir = true;
                //if(other.transform.rotation.eulerAngles.y == 0)
                //{
                pisFWallrun = true;
                //Debug.Log("forward");
                //}
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //chwdir = false;
        //Debug.Log("forward out");
        pisFWallrun = false;
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
