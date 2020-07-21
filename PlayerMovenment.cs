using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovenment : MonoBehaviour
{
    private enum State { Idle, Running, Jumping, Falling }
    private State state = State.Idle;
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    public float knockback;
    public float knockbackCount;
    public float knockbackLength;
    public bool knockFromRight;

    bool jump = false;
    bool crouch = false;
    bool run = false;
    bool isidle = false;
    [SerializeField] private int coin = 0;
    [SerializeField] private Text coinText;
    [SerializeField] 




    void Start()
    {


    }



    // Update is called once per frame
    void Update()
    {
        if (knockbackCount <= 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
                state = State.Jumping;
            }

            if (Input.GetButtonDown("Crouch"))

            {
                crouch = true;
                Debug.Log("is working");

            }
            else if (Input.GetButtonUp("Crouch"))

            {
                crouch = false;
            }

        }
        else
        {
            if (knockFromRight)            
                rb.velocity = new Vector2(-knockback, knockback);            
            if (!knockFromRight)            
                rb.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
            
        }

            //sate ,machine call
            VelocityState();
            //animator.SetInteger ("Speed", (int)state);
        
        }
    public void OnLanding()
    {

        animator.SetBool("IsJumping", false);

    }
    public void OnCrouching(bool isCrouching)
    {

        animator.SetBool("IsCrouching", isCrouching);


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coin += 1;
            coinText.text = coin.ToString();

        }
    }

    void FixedUpdate()

    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    //simple state machine implimentation
    private void VelocityState()
    {
        if (state == State.Jumping)
        {

            Debug.Log("i'm really jummping");
        }


        if (Mathf.Abs(horizontalMove) > Mathf.Epsilon)
        {
            //Moving
            state = State.Running;
            Debug.Log("i'm really moving");

        }
        //if (jump == true && horizontalMove < 0.01f  && isidle == true)
        //{

        //    state = State.Falling;
        //        Debug.Log("i'm really falling");
        //    }

            else
            {
                state = State.Idle;
                Debug.Log("i'm really idling");
            }
        }
    }

