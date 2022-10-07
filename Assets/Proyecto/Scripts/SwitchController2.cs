using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController2 : MonoBehaviour
{
    public bool isPressed;
    private AudioManagerController amc;
    public GameObject puente;
    // Start is called before the first frame update
    void Start()
    {
        amc = FindObjectOfType<AudioManagerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            amc.AudioPlay("Click1");
            isPressed = true;
            puente.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        amc.AudioPlay("Click2");
        isPressed = false;
    }
}
