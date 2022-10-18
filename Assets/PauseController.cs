using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseController : MonoBehaviour
{
    public GameObject pauseUI,continueButtonn;
    private bool pauseState;
    private AudioManagerController amc;
    // Start is called before the first frame update
    void Start()
    {
        amc = FindObjectOfType<AudioManagerController>();
        pauseUI.SetActive(false);
        pauseState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseState == true)
        {
            if (amc.GetAudioPlaying("FootSteps")) amc.AudioStop("FootSteps");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pauseState == false)
        {
            pauseState = true;
            pauseUI.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(continueButtonn);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseState == true)
        {
    
            pauseState = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void continueButton()
    {
        pauseUI.SetActive(false);
        pauseState = false;
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        //Time.timeScale = 1;
        //SceneManager.LoadScene("MainMenu");
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
