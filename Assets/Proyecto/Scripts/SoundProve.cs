using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundProve : MonoBehaviour
{
    private AudioManagerController amc;
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
            Debug.Log("Space key was pressed.");
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("Space key was pressed.");
        }
    }
}
