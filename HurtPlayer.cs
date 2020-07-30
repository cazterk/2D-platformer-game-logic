using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{


    [SerializeField] private float hurtforce = 10f;
    public Rigidbody2D rb;
    public GameObject pl;
    public int damageToGive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
   // void OnCollisionEnter2D(Collision2D other)
   //{

   //     if (other.gameObject.tag == "Enemy" && pl.transform.position.x > pl.transform.position.x)
   //     {
   //         rb.velocity = new Vector2(hurtforce, rb.velocity.y);
   //         Debug.Log("-hurtforce is working");

   //     }
   //     else
   //    {
   //        rb.velocity = new Vector2(hurtforce, rb.velocity.y);
   //        Debug.Log("hurtforce is working");
   //     }


   // } 
}

    
