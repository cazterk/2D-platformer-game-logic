﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAl : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    [SerializeField] private float hurtforce = 10f;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    GameObject Enemy;
    GameObject Player;

    public Transform enemyGFX;



    // Start is called before the first frame update
    void Start()
    {

        Enemy = gameObject.transform.parent.gameObject;
        Player = gameObject.transform.parent.gameObject;

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        

        
    }
     void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {

        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }



   

    // Update is called once per frame
    void FixedUpdate()
    {

        if (path == null)
            return;

        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
            
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);


        if (distance< nextWayPointDistance)
        {
            currentWayPoint++;
        }
        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (force.x <= 0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }


    }
    void OnCollisionEnter2D(Collision2D other)
    {
      
        
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("tigger");
        }
        
        
        
        
        //Player.GetComponent<Rigidbody>();
        ////if (other.gameObject.tag == "Player")        ////{

        ////    if (Player.gameObject.transform.position.x > transform.position.x)
        ////    {
        ////        rb.velocity = new Vector2(-hurtforce, rb.velocity.y);
        ////    }
        ////    Destroy(Player.gameObject);
        ////}
        //////else
        //////{
        //////    rb.velocity = new vector2(hurtforce, rb.velocity.y);
        //////}
        //if (other.gameObject.tag == "Enemy")
        //{
        //    var rel = rb.position - other.rigidbody.position;
        //    if (rel.y > 0.5f)
        //    {
        //        rel.y = 0; // If you don't want to push him upwards.
        //        rel.Normalize();
        //        rb.AddForce(rel * hurtforce);
        //    }

        }
        


}
