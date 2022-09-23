using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundProve : MonoBehaviour
{
    private AudioManagerController amc;
    private float randomDialogueSound;

    // Start is called before the first frame update
    void Start()
    {
        amc = FindObjectOfType<AudioManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            amc.AudioPlay("Glitch sound");
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            randomDialogueSound = Random.Range(0,4);
            //Debug.Log(randomDialogueSound);

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

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            amc.AudioPlay("Door");
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            amc.AudioPlay("Button");
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            amc.AudioPlay("Box");
        }
    }
}
