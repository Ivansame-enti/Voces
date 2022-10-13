using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExtraEmergentDialogue : MonoBehaviour
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

    private string[] randomNeutralDialogue = new string[] {
        "Hoy fui a comprar al super",
        "Me puedes traer un cafe?",
        "Ahora vuelvo",
        "Si, gracias",
        "Ya me quedo yo esta noche",
        "..."
    };

    int random;
    public bool neutralDialogActivated;

    // Start is called before the first frame update
    void Start()
    {
        //amc = FindObjectOfType<AudioManagerController>();
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().alpha = 0f;
        //this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        timer = 0;
        timer = Random.Range(10, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0 && neutralDialogActivated)
        {
            random = Random.Range(0, 3);
            if (random == 0) NarrativeDialogue();
            else if (random == 1) GoodDialogue();
            else if (random >= 2) BadDialogue();
            timer = Random.Range(10, 15);
        }
        else
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

    public void NarrativeDialogue()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-290.0f, 304.0f), Random.Range(-147.0f, 123.0f), 0);
        random = Random.Range(0, randomNeutralDialogue.Length);
        StartCoroutine(ShowText(randomNeutralDialogue[random]));
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

    IEnumerator ShowText(string t)
    {
        for (int i = 0; i < t.Length; i++)
        {
            /*randomDialogueSound = Random.Range(0, 4);
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
            }*/

            currentText = t.Substring(0, i + 1);
            text.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
    }
}
