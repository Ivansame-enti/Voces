using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorldController : MonoBehaviour
{
    public GameObject goodWorld;
    public GameObject badWorld;
    public GameObject mainCamera;
    private DigitalGlitch dg;
    private AnalogGlitch ag;
    private float timer;
    public float changeCD;
    private bool goodWorldBool;
    private AudioManagerController amc;
    private EmergentDialogueController ed;

    // Start is called before the first frame update
    void Start()
    {
        ed = FindObjectOfType<EmergentDialogueController>();
        amc = FindObjectOfType<AudioManagerController>();
        goodWorldBool = true;
        dg = mainCamera.GetComponent<DigitalGlitch>();
        ag = mainCamera.GetComponent<AnalogGlitch>();
        timer = changeCD;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= changeCD)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !goodWorldBool)
            {
                timer = 0;
                StartCoroutine(waiter1());
                
                //SendGoodMessage();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && goodWorldBool)
            {
                timer = 0;
                StartCoroutine(waiter2());
                /*
                ed.BadDialogue();
                amc.AudioPlay("Glitch sound");
                StartCoroutine(BadGlitchEffect());
                timer = 0;
                goodWorldBool = false;*/
                //SendBadMessage();
            }
        }
        else timer += Time.deltaTime;
    }

    /* void SendGoodMessage()
     {
         StartCoroutine(GoodGlitchEffect());

         //Debug.Log("Bueno");
     }

     void SendBadMessage()
     {
         goodWorld.SetActive(false);
         badWorld.SetActive(true);
         //Debug.Log("Malo");
     }*/

    IEnumerator waiter1()
    {
        ed.GoodDialogue();

        yield return new WaitForSeconds(2);
        
        amc.AudioPlay("Glitch sound");
        StartCoroutine(GoodGlitchEffect());        
        goodWorldBool = true;
    }

    IEnumerator waiter2()
    {
        ed.BadDialogue();

        yield return new WaitForSeconds(2);
        
        amc.AudioPlay("Glitch sound");
        StartCoroutine(BadGlitchEffect());
        goodWorldBool = false;
    }

    IEnumerator GoodGlitchEffect()
    {
        for (float alpha = 0f; alpha <= 0.7; alpha += 0.1f)
        {
            dg.intensity = alpha;
            ag.scanLineJitter = alpha;
            ag.verticalJump = alpha;
            ag.horizontalShake = alpha;
            ag.colorDrift = alpha;
            yield return new WaitForSeconds(.1f);
        }

        dg.intensity = 0;
        ag.scanLineJitter = 0;
        ag.verticalJump = 0;
        ag.horizontalShake = 0;
        ag.colorDrift = 0;
        goodWorld.SetActive(true);
        badWorld.SetActive(false);
        amc.ChangePitch("MainTheme", 1.0f);
    }

    IEnumerator BadGlitchEffect()
    {
        for (float alpha = 0f; alpha <= 0.7; alpha += 0.1f)
        {
            dg.intensity = alpha;
            ag.scanLineJitter = alpha;
            ag.verticalJump = alpha;
            ag.horizontalShake = alpha;
            ag.colorDrift = alpha;
            yield return new WaitForSeconds(.1f);
        }

        dg.intensity = 0;
        ag.scanLineJitter = 0;
        ag.verticalJump = 0;
        ag.horizontalShake = 0;
        ag.colorDrift = 0;
        goodWorld.SetActive(false);
        badWorld.SetActive(true);
        amc.ChangePitch("MainTheme", 0.3f);
    }
}
