using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator fadeOutAnim;
    private AudioManagerController amc;
    private bool ending = false;
    private float volume;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        amc = FindObjectOfType<AudioManagerController>();
        volume = amc.GetVolume("MainTheme");
        timer = volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){
            Invoke("FadeOut", 0.5f);
            ending = true;
        }

        if (ending)
        {
            if (timer > 0)
            {
                amc.ChangeVolume("MainTheme", timer);
                timer -= Time.deltaTime/10;
            } else
            {
                SceneManager.LoadScene("Puzzle2");
            }
        }
    }

    void FadeOut()
    {
        fadeOutAnim.Play("FadeOut");
    }
}
