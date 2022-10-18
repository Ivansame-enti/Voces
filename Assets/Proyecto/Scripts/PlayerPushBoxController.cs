using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushBoxController : MonoBehaviour
{
    public float distance;
   
    //public LayerMask layerMask;
    //bool hit;
    GameObject box;
    Transform thingToPull;
    Ray ray;
    Ray ray2;
    Ray ray3;
    Ray ray4;
    RaycastHit hit;
    public bool cubeGrabbedRight=false;
    public bool cubeGrabbedLeft = false;
    public bool cubeGrabbedUp = false;
    public bool cubeGrabbedDown = false;
    PlayerMovement pm;
    float originalVelocity;
    public float pullSpeed;
    public Animator animation;
    public bool mvBR,mvBL,mvBD,mvBU;
    // Start is called before the first frame update
    void Start()
    {
        //pullSpeed = 10.0f;
        pm = this.GetComponent<PlayerMovement>();
        originalVelocity = pm._speed;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = transform.position;
        ray.direction = Vector3.right;

        ray2.origin = transform.position;
        ray2.direction = Vector3.left;

        ray3.origin = transform.position;
        ray3.direction = Vector3.back;

        ray4.origin = transform.position;
        ray4.direction = Vector3.forward;

        if (!cubeGrabbedRight && !cubeGrabbedLeft && !cubeGrabbedUp && !cubeGrabbedDown)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Debug.DrawRay(transform.position, Vector3.right * distance, Color.yellow);

                if (Physics.Raycast(ray, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbedRight = true;
                    //Debug.Log(hit.distance);
                }
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                Debug.DrawRay(transform.position, Vector3.left * distance, Color.yellow);

                if (Physics.Raycast(ray2, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbedLeft = true;
                    //Debug.Log(hit.distance);
                }
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                Debug.DrawRay(transform.position, Vector3.back * distance, Color.yellow);

                if (Physics.Raycast(ray3, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbedDown = true;
                    //Debug.Log(hit.distance);
                }
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                Debug.DrawRay(transform.position, Vector3.forward * distance, Color.yellow);

                if (Physics.Raycast(ray4, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbedUp = true;
                    //Debug.Log(hit.distance);
                }
            }
            else
            {
                if (Physics.Raycast(ray, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbedRight = true;
                } else if (Physics.Raycast(ray2, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbedLeft = true;
                } else if (Physics.Raycast(ray3, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbedDown = true;
                } else if (Physics.Raycast(ray4, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbedUp = true;
                }
            }
            if (Physics.Raycast(ray, out hit, distance) && hit.transform.tag == "Box")
            {
                mvBR = true;
            }
            else if (Physics.Raycast(ray2, out hit, distance) && hit.transform.tag == "Box")
            {
                mvBL = true;

            }
            else if (Physics.Raycast(ray3, out hit, distance) && hit.transform.tag == "Box")
            {
                mvBD = true;

            }
            else if (Physics.Raycast(ray4, out hit, distance) && hit.transform.tag == "Box")
            {
                mvBU = true;
            }
            else
            {
                mvBR = false;
                mvBL = false;
                mvBD = false;
                mvBU = false;
                animation.SetBool("PushR", false);
                animation.SetBool("PushL", false);
                animation.SetBool("PushD", false);
                animation.SetBool("PushU", false);
            }
        }
        Debug.Log(mvBR);
        if (mvBR == true) animation.SetBool("PushR", true);
        else if (mvBL == true) animation.SetBool("PushL", true);
        else if (mvBD == true) animation.SetBool("PushD", true);
        else if (mvBU == true) animation.SetBool("PushU", true);

        //Debug.Log(pm._speed);
        if (cubeGrabbedRight)
        {
            animation.Play("boxRightAnim");
            //Debug.Log("Hola");
            pm._speed = originalVelocity / 2;
            Vector3 vector = transform.position - hit.transform.position;
            Vector3 pullDir = vector.normalized;
            if (Input.GetAxis("Horizontal") < 0) hit.rigidbody.velocity += pullDir * (pullSpeed * Time.deltaTime);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                cubeGrabbedRight = false;
                pm._speed = originalVelocity;
            }
        } else if (cubeGrabbedLeft)
        {
            animation.Play("boxLeftAnim");
            pm._speed = originalVelocity / 2;
            Vector3 vector = transform.position - hit.transform.position;
            Vector3 pullDir = vector.normalized;
            if (Input.GetAxis("Horizontal") > 0) hit.rigidbody.velocity += pullDir * (pullSpeed * Time.deltaTime);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                cubeGrabbedLeft = false;
                pm._speed = originalVelocity;
            }
        }
        else if (cubeGrabbedDown)
        {
            animation.Play("boxDownAnim");
            pm._speed = originalVelocity / 2;
            Vector3 vector = transform.position - hit.transform.position;
            Vector3 pullDir = vector.normalized;
            if (Input.GetAxis("Vertical") > 0) hit.rigidbody.velocity += pullDir * (pullSpeed * Time.deltaTime);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                cubeGrabbedDown = false;
                pm._speed = originalVelocity;
            }
        }
        else if (cubeGrabbedUp)
        {
            animation.Play("boxUpAnim");
            pm._speed = originalVelocity / 2;
            Vector3 vector = transform.position - hit.transform.position;
            Vector3 pullDir = vector.normalized;
            if (Input.GetAxis("Vertical") < 0) hit.rigidbody.velocity += pullDir * (pullSpeed * Time.deltaTime);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                cubeGrabbedUp = false;
                pm._speed = originalVelocity;
            }
        }
    }
}
