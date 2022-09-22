using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public Animator animator;
    private void Start()
    {

    }

    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb;

    void Update()
        {
            var vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
            vel.y = _rb.velocity.y;
            _rb.velocity = vel;

        animator.SetFloat("Horizontal",vel.x);
        animator.SetFloat("Vertical", vel.z);
        animator.SetFloat("Magnitude", vel.magnitude);
        }
    }
    
