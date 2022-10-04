using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniLevelController : MonoBehaviour
{
    public SwitchController sw1;
    public SwitchController sw2;
    public SwitchController sw3;
    private Transform player;
    public Transform respawn;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < -10.0f) player.position = respawn.position;
        if (sw1.isPressed && sw2.isPressed && sw3.isPressed) SceneManager.LoadScene("Victory");
    }
}
