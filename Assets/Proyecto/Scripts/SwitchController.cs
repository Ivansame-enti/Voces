using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public bool isPressed;
    private AudioManagerController amc;
    private Vector3 originalScale;
    private Vector3 pressedScale;
    public Material materialPush;
    // Start is called before the first frame update
    void Start()
    {
        materialPush.SetColor("_EmissionColor", new Color(255, 255, 255) * 0);
        originalScale = this.transform.localScale;
        pressedScale = new Vector3(originalScale.x, originalScale.y-0.15f, originalScale.z);
        amc = FindObjectOfType<AudioManagerController>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            materialPush.SetColor("_EmissionColor", new Color(0, 150, 255) * 1f);
            Debug.Log("Apretado");
            if(!amc.GetAudioPlaying("Click1") && !amc.GetAudioPlaying("Click2")) amc.AudioPlay("Click1");
            isPressed = true;
            this.transform.localScale = pressedScale;
            //animator.Play("switch");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            Debug.Log("No Apretado");
            if (!amc.GetAudioPlaying("Click2") && !amc.GetAudioPlaying("Click1")) amc.AudioPlay("Click2");
            isPressed = false;
            this.transform.localScale = originalScale;
            materialPush.SetColor("_EmissionColor", new Color(255,255,255) * 0);
        }
    }

}
