using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public  AudioSource coin;
    GameObject CollectableItems;
    private Collider2D coll;

    void Start()
    {
       
        coll = GetComponent<Collider2D>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        coin.Play();

        
      }

    }
