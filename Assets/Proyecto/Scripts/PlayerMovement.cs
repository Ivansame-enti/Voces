using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private AudioManagerController amc;

    private void Start()
    {
        amc = FindObjectOfType<AudioManagerController>();
    }

    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _jumpForce = 300;

    void Update()
    {
        var vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;
        if((Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0) && !amc.GetAudioPlaying("FootSteps")) amc.AudioPlay("FootSteps");
        else if ((Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) && amc.GetAudioPlaying("FootSteps")) amc.AudioStop("FootSteps");
        //Debug.Log(vel);
        //if ((vel.x!=0 || vel.z!=0) && !amc.GetAudioPlaying("FootSteps")) amc.AudioPlay("FootSteps");
        //else if((vel.x != 0 && vel.z != 0) && amc.GetAudioPlaying("FootSteps")) amc.AudioStop("FootSteps");
        if (Input.GetKeyDown(KeyCode.Space)) _rb.AddForce(Vector3.up * _jumpForce);
    }
}
    
