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
    public bool cubeGrabbed=false;
    PlayerMovement pm;
    float originalVelocity;
    public float pullSpeed;
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

        if (!cubeGrabbed)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Debug.DrawRay(transform.position, Vector3.right * distance, Color.yellow);

                if (Physics.Raycast(ray, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbed = true;
                    //Debug.Log(hit.distance);
                }
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                Debug.DrawRay(transform.position, Vector3.left * distance, Color.yellow);

                if (Physics.Raycast(ray2, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbed = true;
                    //Debug.Log(hit.distance);
                }
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                Debug.DrawRay(transform.position, Vector3.back * distance, Color.yellow);

                if (Physics.Raycast(ray3, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbed = true;
                    //Debug.Log(hit.distance);
                }
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                Debug.DrawRay(transform.position, Vector3.forward * distance, Color.yellow);

                if (Physics.Raycast(ray4, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbed = true;
                    //Debug.Log(hit.distance);
                }
            }
            else
            {
                if (Physics.Raycast(ray, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbed = true;
                } else if (Physics.Raycast(ray2, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbed = true;
                } else if (Physics.Raycast(ray3, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbed = true;
                } else if (Physics.Raycast(ray4, out hit, distance) && hit.transform.tag == "Box" && Input.GetKey(KeyCode.Space))
                {
                    cubeGrabbed = true;
                }
            }
        }
        //Debug.Log(pm._speed);
        if (cubeGrabbed)
        {
            pm._speed = originalVelocity / 2;
            Vector3 vector = transform.position - hit.transform.position;
            Vector3 pullDir = vector.normalized;
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) hit.rigidbody.velocity += pullDir * (pullSpeed * Time.deltaTime);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                cubeGrabbed = false;
                pm._speed = originalVelocity;
            }
        }
    }
}
