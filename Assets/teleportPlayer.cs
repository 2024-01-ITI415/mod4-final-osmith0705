using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class teleportPlayer : MonoBehaviour
{
    public GameObject start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = start.transform.position;
    }
}
