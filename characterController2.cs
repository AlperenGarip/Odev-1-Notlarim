using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float speed = 1.0f;
    public float moveDirection;

    private bool jump;
    private bool moving;
    private bool grounded = true;
    private Rigidbody2D _rigidbody2d;
    SpriteRenderer _spriterenderer;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _spriterenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        if (_rigidbody2d.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        _rigidbody2d.velocity = new Vector2(speed * moveDirection, _rigidbody2d.velocity.y);

        if (jump)
        {

            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, jumpForce);
            jump = false;
        }
    }

    private void Update()
    {
        if (grounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriterenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriterenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
            
        }
        else if (grounded)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }

        if(grounded && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Zemin"))
        {
            grounded = true;
            anim.SetBool("grounded", true);
        }
    }
}