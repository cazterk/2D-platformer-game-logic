using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public Animator animator;
    public void JumpedOnEagle()
    {
        animator.SetTrigger("Death");
    }
    public void Death()
    {
        Destroy(this.gameObject);
    }
}

