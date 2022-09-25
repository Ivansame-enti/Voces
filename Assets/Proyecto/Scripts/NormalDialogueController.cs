using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NormalDialogueController : MonoBehaviour
{
    public float textDelay = 0.05f;
    private string currentText = "";
    public TextMeshProUGUI text;
    public bool dialogPlaying;
    private string penguin1 = "Ven, sigueme!";
    private string penguin2 = "Vamos rapido, es por aqui";
    private bool textEnded;
    private int textCount;


    // Start is called before the first frame update
    void Start()
    {
        textCount = 0;
        textEnded = true;
        dialogPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogPlaying)
        {
            this.gameObject.SetActive(true);

            if (textEnded && textCount==0)
            {
                StartCoroutine(ShowText(penguin1));
                textEnded = false;
                textCount = 1;
            }

            if (Input.GetKeyDown(KeyCode.Space) && textEnded)
            {
                if (textCount == 2)
                {
                    dialogPlaying = false;
                    textEnded = false;
                }

                if (textCount == 1)
                {
                    StartCoroutine(ShowText(penguin2));
                    textEnded = false;
                    textCount = 2;
                }

                
            }
        }
        else this.gameObject.SetActive(false);
      
    }

    IEnumerator ShowText(string t)
    {
        for (int i = 0; i < t.Length; i++)
        {
            currentText = t.Substring(0, i + 1);
            text.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
        textEnded = true;
    }
}
