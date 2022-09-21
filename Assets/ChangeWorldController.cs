using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorldController : MonoBehaviour
{
    public GameObject goodWorld;
    public GameObject badWorld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SendGoodMessage();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SendBadMessage();
        }
    }

    void SendGoodMessage()
    {
        goodWorld.SetActive(true);
        badWorld.SetActive(false);
        Debug.Log("Bueno");
    }

    void SendBadMessage()
    {
        goodWorld.SetActive(false);
        badWorld.SetActive(true);
        Debug.Log("Malo");
    }
}
