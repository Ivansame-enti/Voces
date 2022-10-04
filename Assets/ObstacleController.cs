using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    //public Transform camera;
    public Transform player;
    public Transform obstacle;
    public float zoomSpeed;
    public float distance=20.0f;


    // Start is called before the first frame update
    void Start()
    {
        //obstacle = player;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 screenPos = this.GetComponent<Camera>().WorldToScreenPoint(player.position);
        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(screenPos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);

        RaycastHit hit;
        //Debug.DrawRay(this.transform.position, camera.position, Color.yellow);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, distance))
        {
            
            if (hit.collider.gameObject.tag != "Player")
            {
                //Debug.Log("Holaaa");
                obstacle.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                obstacle = hit.transform;
                obstacle.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                //obstacle.gameObject.GetComponent<MeshRenderer>().enabled = false;

                /*if(Vector3.Distance(obstacle.position, transform.position) >= 3.0f && Vector3.Distance(transform.position, player.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }*/
            } else
            {
                //Debug.Log("A2");
                obstacle.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                /*if(Vector3.Distance(transform.position, player.position) >= 1.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }*/
            }
        }
    }
}
