using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _speed = 1;
    public Animator animator;
    private AudioManagerController amc;
    private NormalDialogueController ndc;
    private PlayerPushBoxController ppc;
    private Vector3 vel = new Vector3(0, 0, 0);
    private float random;
    private void Start()
    {
        ppc = this.GetComponent<PlayerPushBoxController>();
        ndc = FindObjectOfType<NormalDialogueController>();
        amc = FindObjectOfType<AudioManagerController>();
    }

    
    [SerializeField] private Rigidbody _rb;

    void Update()
    {
        if (!ndc.dialogPlaying)
        {           
            if(!ppc.cubeGrabbedRight && !ppc.cubeGrabbedLeft && !ppc.cubeGrabbedUp && !ppc.cubeGrabbedDown) vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
            else if ((ppc.cubeGrabbedRight || ppc.cubeGrabbedLeft) && Input.GetAxis("Horizontal") != 0) vel = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * _speed;
            else if ((ppc.cubeGrabbedDown  || ppc.cubeGrabbedUp) && Input.GetAxis("Vertical") != 0) vel = new Vector3(0, 0, Input.GetAxis("Vertical")) * _speed;

            vel.y = _rb.velocity.y;
            _rb.velocity = vel;

            if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !amc.GetAudioPlaying("FootSteps"))
            {
                random = Random.Range(0.7f, 1.5f);
                amc.ChangePitch("FootSteps", random);
                amc.AudioPlay("FootSteps");
            }
            else if ((Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) && amc.GetAudioPlaying("FootSteps")) amc.AudioStop("FootSteps");

            animator.SetFloat("Horizontal", vel.x);
            animator.SetFloat("Vertical", vel.z);
            animator.SetFloat("Magnitude", vel.magnitude);
        }
    }
}
    
