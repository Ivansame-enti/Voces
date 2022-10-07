using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniLevelController : MonoBehaviour
{
    public SwitchController sw1;
    public SwitchController sw2;
    public SwitchController sw3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sw1.isPressed && sw2.isPressed && sw3.isPressed) SceneManager.LoadScene("Victory");
    }
}
