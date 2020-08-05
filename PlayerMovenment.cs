using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Text collectables;
    [SerializeField] private float hurtforce = 10f;

    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthBar;

    private Scene scene;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        collectables.text = PlayerPrefs.GetInt("Collectables", 0).ToString();

        scene = SceneManager.GetActiveScene();
       

    }



    // Update is called once per frame/////controlls and movements in this update method
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
        Restart();
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

            if(coin > PlayerPrefs.GetInt("Collectables", 0))
            {
                PlayerPrefs.SetInt("Collectables", coin);
                collectables.text = coin.ToString();
            }
            

        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("Collectables");
        collectables.text = "0";
    }


    // apply knockback effect to player, give damage and trigger hurt animation 
    void OnCollisionEnter2D(Collision2D other)
    {
        //hurtforce and hurt animation + damage(+1)
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
            TakeDamage(1);


        }

        //take player of the game by one hit
        else if(other.gameObject.tag == "Killable")
        {
            TakeDamage(3);
        }
        
    }

    //player takes damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    //player has hit max damage restart scene
    void Restart()
    {
        if(currentHealth < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //fixed update
        void FixedUpdate()

    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        animator.SetBool("IsHurt", false);
    }

// simple state machine that detect the current state of the player
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

        else if (state == State.Hurt)
        {
            Debug.Log("Is hurt is working");
           
        }
        else
        {
            state = State.Idle;
            Debug.Log("isidle is true");
        }
    }
}
