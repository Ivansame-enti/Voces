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

    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("Hola");
            currentText = t.Substring(0, i+1);
            text.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
    }
}
