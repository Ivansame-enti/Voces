using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    public Vector3 jumpPlayer;
    public Vector3 jumpBox;
    // Start is called before the first frame update
    void Start()
    {
        //boxRb = box.GetComponent<Rigidbody>();
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(jumpPlayer, ForceMode.Impulse);

        }
        if (collision.gameObject.tag == "Box")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(jumpBox, ForceMode.Impulse);
        }
    }

}
