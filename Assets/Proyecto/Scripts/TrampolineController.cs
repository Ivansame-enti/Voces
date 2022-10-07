using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    public Vector3 jumpPlayer;
    public Vector3 jumpBox;
    private GameObject box;
    private bool bounce = false;
    // Start is called before the first frame update
    void Start()
    {
        //boxRb = box.GetComponent<Rigidbody>();
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bounce)
        {
            box.gameObject.GetComponent<Rigidbody>().AddForce(jumpBox, ForceMode.Impulse);
            bounce = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(jumpPlayer, ForceMode.Impulse);

        }
        if (collision.gameObject.tag == "Box")
        {
            box = collision.gameObject;
            bounce = true;
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(jumpBox, ForceMode.Impulse);
        }
    }

}