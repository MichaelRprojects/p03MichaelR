using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallD : MonoBehaviour
{
    public static bool pisRWallrun = false;
    Collider ocollider;
    float size;
    float rotyw;
    bool chwdir = false;
    public bool isfright;
    public bool isbright;
    public bool iscenter;
    public static bool centerd = false;
    public static bool fcenterd = false;
    public static bool bcenterd = false;
    //public int directnum;
    [SerializeField] Transform Wallch;
    [SerializeField] Transform Wallche;
    [SerializeField] LayerMask Ground;
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
                chwdir = true;
                //if(other.transform.rotation.eulerAngles.y == 0)
                //{
                    pisRWallrun = true;
                //}
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        chwdir = false;
        pisRWallrun = false;
        //if (iscenter == true)
        //{
            //centerd = false;
        //}
        //if (isfright == true)
        //{
            //fcenterd = false;
        //}
        //if (isbright == true)
        //{
            //bcenterd = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (chwdir == true)
        {
            //*2.5 1f end .pos
            //Debug.DrawRay(Wallch.position, Wallche.position - Wallch.position, Color.blue, 2.5f);
            RaycastHit wallh;
            //lpos *2.5
            Physics.Raycast(Wallch.position, Wallche.position - Wallch.position, out wallh, 2.5f, Ground);

            if (wallh.transform != null)
            {
                //if(iscenter == true)
                //{
                    //centerd = true;
                //}
                //if (isfright == true)
                //{
                    //fcenterd = true;
                //}
                //if (isbright == true)
                //{
                    //bcenterd = true;
                //}
                PMovementP3.walldir += wallh.normal;
                //Debug.DrawRay(wallh.point, PMovementP3.walldir.normalized, Color.green, 2.5f);
                //Debug.DrawRay(wallh.point, PMovementP3.walldir.normalized, Color.red, 2.5f);
            }

            //Debug.DrawRay(Wallch.position, Wallch.transform.right * 2.5f, Color.blue, 1f);
            //RaycastHit pftyfvdeg;
            //Physics.Raycast(Wallch.position, Wallch.transform.right, out pftyfvdeg, 2.5f, Ground);
        }
    }
}
