using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headcollider : MonoBehaviour
{

    GameObject Enemy;
    public BoxCollider2D headcollider;
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
        
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        //jump on enemy
        Enemy enemy = Enemy.GetComponent<Enemy>();
        enemy.JumpedOn();
        Debug.Log(" jump on enemy is triggering");


        //*********unused*********//
        // if (other.gameObject.name == headcollider.name)
        //Enemy.GetComponent<SpriteRenderer>().flipY = true;
        // Enemy.GetComponent<Collider2D>().enabled = false;
        //Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
        //Enemy.transform.position = Enemy.transform.position + movement * Time.captureFramerate;                




    }
    
    }
    
