using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    bool hasPush;
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        hasPush = false;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PushButton")
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("A");
            }
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PushButton")
        {
            if (Input.GetKey(KeyCode.Space) && !hasPush)
            {
                platform.SetActive(false);
                hasPush = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PushButton")
        {
            if (hasPush) hasPush = false;
        }
    }
}
