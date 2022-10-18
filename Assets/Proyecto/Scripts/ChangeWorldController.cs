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
    public bool goodWorldBool;
    private AudioManagerController amc;
    private EmergentDialogueController ed;
    public PortalController portalController;
    public bool changeWorld;
    private NormalDialogueController ndc;
    private float originalY;
    private float timer2;

    // Start is called before the first frame update
    void Start()
    {
        ndc = FindObjectOfType<NormalDialogueController>();
        ed = FindObjectOfType<EmergentDialogueController>();
        amc = FindObjectOfType<AudioManagerController>();
        goodWorldBool = true;
        dg = mainCamera.GetComponent<DigitalGlitch>();
        ag = mainCamera.GetComponent<AnalogGlitch>();
        timer = changeCD;
        timer2 = Random.Range(2.0f, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= changeCD)
        {
            if (!ndc.dialogPlaying)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && !goodWorldBool)
                {
                    ed.timer = Random.Range(10, 20);
                    timer = 0;
                    StartCoroutine(waiter1());

                    //SendGoodMessage();
                }

                if (Input.GetKeyDown(KeyCode.LeftShift) && goodWorldBool)
                {
                    ed.timer = Random.Range(10, 20);
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
                if (changeWorld == true)
                {
                    changeWorld = false;
                    if (goodWorldBool == true)
                    {
                        StartCoroutine(BadGlitchEffect());
                        goodWorldBool = false;
                    }
                    else
                    {
                        StartCoroutine(GoodGlitchEffect());
                        goodWorldBool = true;
                    }

                }
            }
        }
        else timer += Time.deltaTime;

        if(!goodWorldBool)
        {
            if (timer2 <= 0)
            {
                if (!amc.GetAudioPlaying("Storm")) amc.AudioPlay("Storm");
                timer2 = Random.Range(2.0f, 7.0f);
            }
            else timer2 -= Time.deltaTime;
        }
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
        ag.enabled = true;
        for (float alpha = 0f; alpha <= 0.7; alpha += 0.1f)
        {
            dg.intensity = alpha;
            ag.scanLineJitter = alpha;
            ag.verticalJump = alpha;
            ag.horizontalShake = alpha;
            ag.colorDrift = alpha;
            yield return new WaitForSeconds(.1f);
        }

        goodWorld.SetActive(true);
        badWorld.SetActive(false);
        originalY = this.transform.position.y;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 5.0f, this.transform.position.z);

        RaycastHit hit;

        if (this.GetComponent<Rigidbody>().SweepTest(transform.position, out hit, 10.0f))
        {
            this.transform.position = new Vector3(this.transform.position.x, originalY + 1.0f, this.transform.position.z);
            Debug.Log("wsdasd");
            //aboutToCollide = true;
            //distanceToCollision = hit.distance;
        }
        else this.transform.position = new Vector3(this.transform.position.x, originalY, this.transform.position.z);
        dg.intensity = 0;
        ag.scanLineJitter = 0;
        ag.verticalJump = 0;
        ag.horizontalShake = 0;
        ag.colorDrift = 0;
        ag.enabled = false;

        amc.AudioPlay("Birds");
        if(amc.GetAudioPlaying("Storm")) amc.AudioStop("Storm");
        amc.ChangePitch("MainTheme", 1.0f);
        timer2 = Random.Range(2.0f, 7.0f);

    }

    IEnumerator BadGlitchEffect()
    {
        ag.enabled = true;
        for (float alpha = 0f; alpha <= 0.7; alpha += 0.1f)
        {
            dg.intensity = alpha;
            ag.scanLineJitter = alpha;
            ag.verticalJump = alpha;
            ag.horizontalShake = alpha;
            ag.colorDrift = alpha;

            yield return new WaitForSeconds(.1f);
        }

        goodWorld.SetActive(false);
        badWorld.SetActive(true);
        originalY = this.transform.position.y;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 5.0f, this.transform.position.z);

        RaycastHit hit;

        if (this.GetComponent<Rigidbody>().SweepTest(transform.position, out hit, 10.0f))
        {
            this.transform.position = new Vector3(this.transform.position.x, originalY + 1.0f, this.transform.position.z);
            //Debug.Log("wsdasd");
            //aboutToCollide = true;
            //distanceToCollision = hit.distance;
        }
        else this.transform.position = new Vector3(this.transform.position.x, originalY, this.transform.position.z);
        dg.intensity = 0;
        ag.scanLineJitter = 0;
        ag.verticalJump = 0;
        ag.horizontalShake = 0;
        ag.colorDrift = 0;
        ag.enabled = false;

        amc.AudioStop("Birds");
        amc.ChangePitch("MainTheme", 0.3f);


    }
}
