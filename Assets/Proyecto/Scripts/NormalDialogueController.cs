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
    public int textCount;
    private AudioManagerController amc;
    private float randomDialogueSound;


    // Start is called before the first frame update
    void Start()
    {
        amc = FindObjectOfType<AudioManagerController>();
        textCount = 0;
        textEnded = true;
        dialogPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            dialogPlaying = true;
        }*/

        if (dialogPlaying)
        {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;

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
                    textCount = 3;
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
        else this.gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;

    }

    IEnumerator ShowText(string t)
    {
        for (int i = 0; i < t.Length; i++)
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

            currentText = t.Substring(0, i + 1);
            text.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
        textEnded = true;
    }
}
