using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(clip);
    }
}
