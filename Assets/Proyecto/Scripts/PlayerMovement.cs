using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _speed = 1;
    public Animator animator;
    private AudioManagerController amc;
    private NormalDialogueController ndc;
    private void Start()
    {
        ndc = FindObjectOfType<NormalDialogueController>();
        amc = FindObjectOfType<AudioManagerController>();
    }

    
    [SerializeField] private Rigidbody _rb;

    void Update()
    {
        if (!ndc.dialogPlaying)
        {
            var vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
            vel.y = _rb.velocity.y;
            _rb.velocity = vel;

            if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !amc.GetAudioPlaying("FootSteps")) amc.AudioPlay("FootSteps");
            else if ((Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) && amc.GetAudioPlaying("FootSteps")) amc.AudioStop("FootSteps");

            animator.SetFloat("Horizontal", vel.x);
            animator.SetFloat("Vertical", vel.z);
            animator.SetFloat("Magnitude", vel.magnitude);
        }
    }
}
    
