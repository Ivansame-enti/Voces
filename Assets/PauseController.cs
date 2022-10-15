using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PauseController : MonoBehaviour
{
    public GameObject pauseUI;
    private bool pauseState;
    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        pauseState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseState == false)
        {
            pauseState = true;
            pauseUI.SetActive(true);
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
