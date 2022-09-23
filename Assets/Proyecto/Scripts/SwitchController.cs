using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private bool kgOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(kgOn == true)
        {
            
        }
        if(kgOn == false)
        {
           
        }
        Debug.Log(kgOn);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            kgOn = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        kgOn = false;
    }

}
