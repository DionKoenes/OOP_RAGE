using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KillingObstacle : MonoBehaviour
{ 
    [SerializeField] protected LayerMask whatIsKillingObstacle;
    [SerializeField] protected GameObject Sprite;
    [SerializeField] protected GameObject Trail;

    Animator animator;

    protected PlayerController speed;
    protected PlayerController jumpForce;

    protected bool makeContact;

    private void Start()
    {
        animator = Sprite.GetComponent<Animator>();
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            animator.SetTrigger("Death");
            makeContact = true;
        }
    }

    protected void StopPlayer()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController playerScript = Player.GetComponent<PlayerController>();

        if (makeContact)
        {
            playerScript.Die();
        }
    }
}
