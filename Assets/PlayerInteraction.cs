using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    bool hasPush;
    //public GameObject platform;
    public GameObject box;
    private Vector3 boxPos;
    // Start is called before the first frame update
    void Start()
    {
        boxPos = box.transform.position;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PushButton")
        {
            if (Input.GetKey(KeyCode.Space) /*&& !hasPush*/)
            {
                box.SetActive(true);
                box.transform.position = boxPos;
                //platform.SetActive(false);
                //hasPush = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.gameObject.tag == "PushButton")
        {
            if (hasPush) hasPush = false;
        }*/
    }
}
