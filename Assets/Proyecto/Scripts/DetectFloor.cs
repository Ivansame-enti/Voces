using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFloor : MonoBehaviour
{
    public bool isJumping;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isJumping == false)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }
        else if(isJumping == true)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = true;
        }
    }
}
