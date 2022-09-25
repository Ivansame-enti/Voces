using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{

    public GameObject player,box;
    public Vector3 jump;
    Rigidbody playerRb,boxRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
        boxRb = box.GetComponent<Rigidbody>();
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
            playerRb.AddForce(jump, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "Box")
        {
            boxRb.AddForce(jump, ForceMode.Impulse);
        }
    }

}
