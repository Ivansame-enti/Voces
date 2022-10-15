using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public ChangeWorldController cwd;
    public GameObject goodWorld;
    public GameObject badWorld;
    public GameObject player;
    private ChangeWorldController changeWorld;
    private PlayerPushBoxController ppbc;
    private PlayerMovement pm;
    private float normalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        changeWorld = player.GetComponent<ChangeWorldController>();
        ppbc = player.GetComponent<PlayerPushBoxController>();
        pm = player.GetComponent<PlayerMovement>();
        normalSpeed = pm._speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            if (cwd.goodWorldBool)
            {
                collision.gameObject.transform.parent = badWorld.transform;
                //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z-2.0f);
            }
            else collision.gameObject.transform.parent = goodWorld.transform;
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z - 1.5f);
        }
        
        if(collision.gameObject.tag == "Player")
        {
            ppbc.cubeGrabbedRight = false;
            ppbc.cubeGrabbedLeft = false;
            ppbc.cubeGrabbedUp = false;
            ppbc.cubeGrabbedDown = false;
            pm._speed = normalSpeed;
            changeWorld.changeWorld = true;
            //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z - 1.5f);
            
        }
    }
}
