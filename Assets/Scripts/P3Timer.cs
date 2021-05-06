using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3Timer : MonoBehaviour
{
    public static P3Timer instance;
    private bool timergoing;
    public static bool ptimergoing = false;
    private float elapsedTime;
    private TimeSpan timeplaying;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timergoing = false;
    }
    public void BeginT()
    {
        timergoing = true;
        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
    }
    public void EndT()
    {
        elapsedTime = 0f;
        timergoing = false;
    }
    private IEnumerator UpdateTimer()
    {
        while (timergoing)
        {
            //deltaTime
            elapsedTime += Time.deltaTime;
            timeplaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlay = "Time: " + timeplaying.ToString("mm':'ss'.'ff");
            //Debug.Log(elapsedTime);
            //time.text = timePlay;
            yield return null;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (WallD2.pisFWallrun == true)
        {
            if (elapsedTime > 1.5f)
            {
                //Debug.Log("over");
                PMovementP3.stpWllRn = true;
                EndT();
            }
        }

        if (WallD2.pisFWallrun == false)
        {
            if (elapsedTime > 2.2f)
            {
                //Debug.Log("over");
                PMovementP3.stpWllRn = true;
                EndT();
            }
        }
    }
}
