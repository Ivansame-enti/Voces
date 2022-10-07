using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public bool isPressed;
    private AudioManagerController amc;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        amc = FindObjectOfType<AudioManagerController>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            amc.AudioPlay("Click1");
            isPressed = true;
            animator.Play("switch");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        amc.AudioPlay("Click2");
        animator.Play("switchOff");
        isPressed = false;
    }

}
