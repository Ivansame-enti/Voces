using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeInFinished : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("FadeInFinished"))
        {
            panel.SetActive(false);
        }
    }
}
