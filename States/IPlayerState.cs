using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    void Execute();
    void Enter(PlayerMovenment playerMovenment);
    void Exit();
    void OnTriggerEnter(Collider2D other);
    void Enter(Player player);
}
