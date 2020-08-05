using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]protected Animator animator;
    

    protected virtual void Start()
    {
        animator.GetComponent<Animator>();
    }
    public void JumpedOn()
    {
        animator.SetTrigger("Death");
        transform.Translate(Vector3.left * 3);
    }
    public void Death()
    {
        Destroy(this.gameObject);
    }
}
