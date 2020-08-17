using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float defaultSpeed = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    private Vector3 _velocity;
    private bool _isGrounded;

    private float _speed;
    private float _jumpRate = 1f;
    private float _nextJump;
    private Animator _animator;

    public Health health;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _speed = defaultSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if (!health.isDead)
        {
            // Player is not dead
            Movement();
        }
    }

    

    void Movement()
    {

        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");

        // Walking animations
        if ((_xMov != 0 || _zMov != 0) && Input.GetKey(KeyCode.LeftShift))
        {
            // Running
            _speed = defaultSpeed * 2;
            _animator.SetInteger("condition", 2);
        }
        else if ((_xMov != 0 || _zMov != 0) && !Input.GetKey(KeyCode.LeftShift))
        {
            // Walking
            _speed = defaultSpeed;
            _animator.SetInteger("condition", 1);

        }
        else
        {
            // Idling
            _animator.SetInteger("condition", 0);
        }

 

        // Lateral movement
        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;
        Vector3 move = (_movHorizontal + _movVertical).normalized * _speed;
        controller.Move(move * Time.deltaTime);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && _isGrounded && Time.time > _nextJump) 
        {
            _nextJump = Time.time + _jumpRate;    // Prevent input buffering of the jump
            _animator.SetBool("in_air", true);
            Invoke("Jump", 0.3f);
        }
        else
        {
            _animator.SetBool("in_air", false);
        }

        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
    }

    void Jump()
    {
        _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

    }


    
}
