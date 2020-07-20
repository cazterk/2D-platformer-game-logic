using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState
{
    public void Enter(PlayerMovenment playerMovenment)
    {
        
    }

    public void Enter(Player player)
    {
        throw new System.NotImplementedException();
    }

    public void Execute()
    {
       
    }

    public void Exit()
    {
       
    }

    public void OnTriggerEnter(Collider2D other)
    {
       
    }
}

public class RunningSate : IPlayerState
{
    public void Enter(PlayerMovenment playerMovenment)
    {
        
    }

    public void Enter(Player player)
    {
        throw new System.NotImplementedException();
    }

    public void Execute()
    {
       
    }

    public void Exit()
    {
       
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }
}

public class JumpingSate : IPlayerState
{
    public void Enter(PlayerMovenment playerMovenment)
    {

    }

    public void Enter(Player player)
    {
        throw new System.NotImplementedException();
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }
}

public class CrouchingSate : IPlayerState
{
    public void Enter(PlayerMovenment playerMovenment)
    {

    }

    public void Enter(Player player)
    {
        throw new System.NotImplementedException();
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }
}