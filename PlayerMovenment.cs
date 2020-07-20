using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovenment : MonoBehaviour
{
    private enum State { Idle, Running, Jumping, }
    private State state = State.Idle;
    public CharacterController2D controller;
    public Animator animator;
    private Rigidbody2D rb;
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
    public void OnLanding() {

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

    private void VelocityState()
    {
        if(state == State.Jumping)
        {
            jump = true;
            Debug.Log("i'm really jummping");
        }
        if(Mathf.Abs(runSpeed) > Mathf.Epsilon)
        {
            //Moving
            state = State.Running;
            Debug.Log("i'm really moving");
        }
    }
}
