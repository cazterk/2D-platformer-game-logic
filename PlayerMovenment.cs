using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovenment : MonoBehaviour
{
    private enum State { Idle, Running, Jumping, Hurt }
    private State state = State.Idle;
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    [SerializeField] private int coin = 0;
    [SerializeField] private Text coinText;
    [SerializeField] private float hurtforce = 10f;




    void Start()
    {


    }



    // Update is called once per frame
    void Update()
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
        VelocityState();
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
    // apply knockback effect to player
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemy")

        {
            
            if (other.gameObject.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(-hurtforce, rb.velocity.y);
                 Debug.Log("-hurtforce is working");
               


            }
            else
            {
                rb.velocity = new Vector2(hurtforce, rb.velocity.y);
                Debug.Log("hurtforce is working");
               

            }
            state = State.Hurt;
            animator.SetBool("IsHurt", true);


        }
     


    }



        void FixedUpdate()

    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        animator.SetBool("IsHurt", false);
    }

    private void VelocityState()
    {
        if (state == State.Jumping)
        {
            
            Debug.Log("i'm really jummping");
            animator.SetBool("IsHurt", false);
        }

       else if (Mathf.Abs(horizontalMove) > 0.1f)
        {
            //Moving
            state = State.Running;
            Debug.Log("i'm really moving");
           
        }

        else if (state != State.Hurt)
        {
            animator.SetBool("IsHurt", false);
        }

        else if (state == State.Hurt)
        {
            Debug.Log("Ishurt is working");
           
        }
        else
        {
            state = State.Idle;
            Debug.Log("isidle is true");
        }
    }
}
