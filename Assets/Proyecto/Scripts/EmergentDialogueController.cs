using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergentDialogueController : MonoBehaviour
{
    private float timer;
    public float timerCD;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().alpha = 0f;
        //this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        timer = timerCD;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && timer<=0)
        {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-316.0f, 335.0f), Random.Range(-147.0f, 123.0f), 0);
            //this.transform.position = new Vector3(Random.Range(-316.0f, 335.0f), Random.Range(-147.0f, 123.0f), 0);
            //m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
            Debug.Log("Hola");
            //Debug.Log("y: " + this.transform.position.y);

            //this.gameObject.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
            //this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Dialogue");
            //this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            timer = timerCD;
        }

        //Debug.Log(timer);

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            //this.gameObject.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().alpha = 0f;
            //this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
