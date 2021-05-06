using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AHlpr : MonoBehaviour
{
    //public static bool soundon = false;
    public static AudioSource PlayClip2D(AudioClip clip)
    {
        GameObject audioObject = new GameObject("2DAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        audioSource.clip = clip;
        //audioSource.volume volume;

        audioSource.Play();
        //if (audioSource.isPlaying)
        //{
            //soundon = true;
        //}

        //if (!audioSource.isPlaying)
        //{
            //soundon = false;
        //}
        Object.Destroy(audioObject, clip.length);
        return audioSource;
    }
}
