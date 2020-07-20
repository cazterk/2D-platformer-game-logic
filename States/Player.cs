using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterController2D


{
    private IPlayerState currentSate;
    // Start is called before the first frame update
    public void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(IPlayerState newState)
    {
        if (currentSate != null)
        {
            currentSate.Exit();
        }
        currentSate = newState;

        currentSate.Enter(this);

    }
}
