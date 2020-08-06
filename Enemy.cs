using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]protected Animator animator;

    private AudioSource deathclip;
    protected virtual void Start()
    {
        animator.GetComponent<Animator>();
        deathclip = GetComponent<AudioSource>();
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

    public void DeathClip()
    {
        deathclip.Play();
    }
}
