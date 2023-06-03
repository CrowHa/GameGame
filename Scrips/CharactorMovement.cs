using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private BoxCollider2D bcol;
    [SerializeField] float movespeed = 7f;
    [SerializeField] float jumpforce = 7f;
    [SerializeField] private LayerMask jumpableground;
/*    [SerializeField] private AudioSource movesound;*/
    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private AudioSource BGsound;
    float dirX;

    private enum MovementState {idle, run, jump, fall };
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        bcol = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        BGsound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        dirX = Input.GetAxis("Horizontal");
        /*if (dirX != 0)
        {
            if (!movesound.isPlaying)
            {
                movesound.PlayDelayed(.1f);
            }
        }*/
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpsound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        UpdateAnimation();
    
    }
    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {     
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true ;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > 1f) {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        

        animator.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
       return Physics2D.BoxCast(bcol.bounds.center, bcol.bounds.size, 0f, Vector2.down, .1f, jumpableground);
    }
}
