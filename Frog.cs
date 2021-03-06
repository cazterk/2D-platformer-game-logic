﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLenth = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    private Rigidbody2D rb;

    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        
    }


    private void Update()
    {
        if (animator.GetBool("Jumping"))
        {
            if(rb.velocity.y < 0.1)
            {
                animator.SetBool("Falling", true);
                animator.SetBool("Jumping", false);
            }
        }
        if (coll.IsTouchingLayers(ground) && animator.GetBool("Falling")){
            animator.SetBool("Falling", false);
        }
    }

    private void Move()
    {
        if (facingLeft)
        {
            //test to see if we are beyond leftCap
            if (transform.position.x > leftCap)
            {
                // make sure sprite is facing right location and if not face right
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }


                // test if frog is on ground
                if (coll.IsTouchingLayers(ground))
                {
                    //jump
                    rb.velocity = new Vector2(-jumpLenth, jumpHeight);
                    animator.SetBool("Jumping", true);
                }
            }
            // if it is not we are going to face right
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            //test to see if we are beyond leftCap
            if (transform.position.x < rightCap)
            {
                // make sure sprite is facing right location and if not face right
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }


                // test if frog is on ground
                if (coll.IsTouchingLayers(ground))
                {
                    //jump
                    rb.velocity = new Vector2(jumpLenth, jumpHeight);
                    animator.SetBool("Jumping", true);
                }
            }
            // if it is not we are going to face right
            else
            {
                facingLeft = true;
            }
        }
    }

   
   
}






