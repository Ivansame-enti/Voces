using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmergentDialogueController : MonoBehaviour
{
    private float timer;
    public float timerCD;
    public Image textBox;
    public TextMeshProUGUI text;
    public Sprite goodDialog;
    public Sprite normalDialog;
    public Sprite badDialog;
    public float textDelay = 0.05f;
    private string currentText = "";
    private AudioManagerController amc;
    private float randomDialogueSound;
    private string[] randomGoodDialogue = new string[] {
        "Te queremos hijo", 
        "Recuperate pronto", 
        "Hola Lucas!",
        "El medico ha dicho que estas mejorando",
        "Tu abuelo te da recuerdos",
        "Juguemos a futbol cuando salgas de aqui"
    };

    private string[] randomBadDialogue = new string[] {
        "Ojala no despiertes",
        "Lamentablemente su hijo no se recuperara",
        "Siempre te odie",
        "Lucas esta sangrando de nuevo!",
        "Sus resultados no son buenos",
        "No fuiste deseado"
    };

    int random;


    // Start is called before the first frame update
    void Start()
    {
        amc = FindObjectOfType<AudioManagerController>();
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().alpha = 0f;
        //this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && timer<=0)
        {
            //this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Dialogue", 0, 0.0f);
            GoodDialogue("Recuperate hijo mio");
            timer = timerCD;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) && timer <= 0)
        {
            //this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Dialogue", 0, 0.0f);
            NarrativeDialogue("Hoy fui a comprar al super");
            timer = timerCD;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3) && timer <= 0)
        {
            //this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Dialogue", 0, 0.0f);
            BadDialogue("Su hijo puede que no despierte");
            timer = timerCD;
        }


        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void GoodDialogue()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-290.0f, 304.0f), Random.Range(-147.0f, 123.0f), 0);
        random = Random.Range(0, randomGoodDialogue.Length);
        StartCoroutine(ShowText(randomGoodDialogue[random]));
        textBox.sprite = goodDialog;
        //text.text = t;
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Dialogue", 0, 0.0f);
    }

    public void GoodDialogue(string t)
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-290.0f, 304.0f), Random.Range(-147.0f, 123.0f), 0);
        StartCoroutine(ShowText(t));
        textBox.sprite = goodDialog;
        //text.text = t;
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Dialogue", 0, 0.0f);
    }

    public void NarrativeDialogue(string t)
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-290.0f, 304.0f), Random.Range(-147.0f, 123.0f), 0);
        StartCoroutine(ShowText(t));
        textBox.sprite = normalDialog;
        //text.text = t;
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Dialogue", 0, 0.0f);
    }

    public void BadDialogue()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-290.0f, 304.0f), Random.Range(-147.0f, 123.0f), 0);
        random = Random.Range(0, randomBadDialogue.Length);
        StartCoroutine(ShowText(randomBadDialogue[random]));
        textBox.sprite = badDialog;
        //text.text = t;
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Dialogue", 0, 0.0f);
    }

    public void BadDialogue(string t)
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-290.0f, 304.0f), Random.Range(-147.0f, 123.0f), 0);
        StartCoroutine(ShowText(t));
        textBox.sprite = badDialog;
        //text.text = t;
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Dialogue", 0, 0.0f);
    }

    IEnumerator ShowText(string t)
    {
        for(int i = 0; i < t.Length; i++)
        {
            randomDialogueSound = Random.Range(0, 4);
            if (!amc.GetAudioPlaying("Dialogue1") && !amc.GetAudioPlaying("Dialogue2") && !amc.GetAudioPlaying("Dialogue3") && !amc.GetAudioPlaying("Dialogue4"))
            {
                switch (randomDialogueSound)
                {
                    case 0:
                        amc.AudioPlay("Dialogue1");
                        break;
                    case 1:
                        amc.AudioPlay("Dialogue2");
                        break;
                    case 2:
                        amc.AudioPlay("Dialogue3");
                        break;
                    case 3:
                        amc.AudioPlay("Dialogue4");
                        break;
                    default:
                        amc.AudioPlay("Dialogue1");
                        break;
                }
            }

            currentText = t.Substring(0, i+1);
            text.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
    }
}
