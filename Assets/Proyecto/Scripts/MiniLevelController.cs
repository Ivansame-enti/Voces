using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniLevelController : MonoBehaviour
{
    public SwitchController sw1;
    public SwitchController sw2;
    public SwitchController sw3;
    //public SwitchController sw4;
    private Transform player;
    public Transform respawn;
    public GameObject door1, door2;
    private float targetAngle=0.0f, targetAngle2=180.0f;
    public NormalDialogueController ndc;
    public GameObject camera;
    public GameObject pingu;
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //door2.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 1.0f * Time.deltaTime);
        if (ndc.textCount == 3 && !flag)
        {
            camera.GetComponent<CinemachineBrain>().enabled = true;
            pingu.transform.position = new Vector3(pingu.transform.position.x, pingu.transform.position.y, pingu.transform.position.z+3.0f);
            flag = true;
        } else if (ndc.textCount != 3) ndc.dialogPlaying = true;
        if (player.position.y < -10.0f) player.position = respawn.position;
        if (sw1.isPressed && sw2.isPressed && sw3.isPressed)
        {
            //Debug.Log("hola");
            if (targetAngle < 180) targetAngle += 30.0f * Time.deltaTime;
            door1.transform.localRotation = Quaternion.Euler(0, targetAngle, 0);

            if (targetAngle2 > 5) targetAngle2 -= 30.0f * Time.deltaTime;
            door2.transform.localRotation = Quaternion.Euler(0, targetAngle2, 0);
        } else
        {
            targetAngle = 0.0f;
            targetAngle2 = 180.0f;
            door1.transform.localRotation = Quaternion.Euler(0, targetAngle, 0);
            door2.transform.localRotation = Quaternion.Euler(0, targetAngle2, 0);
        }
    }
}
