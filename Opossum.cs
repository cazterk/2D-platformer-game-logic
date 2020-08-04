using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    //[SerializeField] private float jumpLenth = 10f;
   //[SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    private Rigidbody2D rb;

    private bool facingLeft = true;
    public float moveSpeed = 3f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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

                transform.Translate(Vector3.left * Time.deltaTime  * moveSpeed);

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
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

            }
            // if it is not we are going to face right
            else
            {
                facingLeft = true;
            }
        }
    }

}
