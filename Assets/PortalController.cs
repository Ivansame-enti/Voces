using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public ChangeWorldController cwd;
    public GameObject goodWorld;
    public GameObject badWorld;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            Debug.Log("ASASDASF");
            if (cwd.goodWorldBool)
            {
                collision.gameObject.transform.parent = badWorld.transform;
                //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z-2.0f);
            }
            else collision.gameObject.transform.parent = goodWorld.transform;
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z - 1.5f);
        }       
    }
}
