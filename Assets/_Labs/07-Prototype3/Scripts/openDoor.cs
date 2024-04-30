using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public playerScript player;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(player.keyCount == 4)
        {
            anim.Play("openDoor");
        }
    }
}
