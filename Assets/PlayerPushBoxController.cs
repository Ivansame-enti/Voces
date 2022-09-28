using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushBoxController : MonoBehaviour
{
    public float distance;
    public LayerMask layerMask;
    RaycastHit2D hit;
    GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (Input.GetAxis("Horizontal") > 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector3.right * transform.localPosition.x, distance, layerMask);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector3.left * transform.localPosition.x, distance, layerMask);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector3.back * transform.localPosition.x, distance, layerMask);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector3.forward * transform.localPosition.x, distance, layerMask);
        }
        else hit = Physics2D.Raycast(transform.position, Vector3.right * transform.localPosition.x, distance, layerMask);

        if(hit.collider != null && Input.GetKey(KeyCode.Space))
        {
            box = hit.collider.gameObject;
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (Input.GetAxis("Horizontal") > 0){
            Gizmos.DrawLine(transform.position, (Vector3)transform.position + Vector3.right * transform.localPosition.x * distance);
        } else if(Input.GetAxis("Horizontal") < 0)
        {
            Gizmos.DrawLine(transform.position, (Vector3)transform.position + Vector3.left * transform.localPosition.x * distance);
        } else if (Input.GetAxis("Vertical") < 0)
        {
            Gizmos.DrawLine(transform.position, (Vector3)transform.position + Vector3.back * transform.localPosition.x * distance);
        } else if (Input.GetAxis("Vertical") > 0)
        {
            Gizmos.DrawLine(transform.position, (Vector3)transform.position + Vector3.forward * transform.localPosition.x * distance);
        } else Gizmos.DrawLine(transform.position, (Vector3)transform.position + Vector3.right * transform.localPosition.x * distance);
        //Gizmos.DrawLine(transform.position, (Vector3)transform.position * transform.localPosition.x * distance);
    }
}
