using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KillingObstacle : MonoBehaviour
{ 
    [SerializeField] protected LayerMask whatIsKillingObstacle;

    [SerializeField] protected GameObject Sprite;
    [SerializeField] protected GameObject Trail;
    [SerializeField] protected GameObject YouDied;

    protected Animator animator;
    protected AudioSource audioSource;
    protected SpriteRenderer youDiedSprite;

    protected PlayerController speed;
    protected PlayerController jumpForce;

    protected bool makeContact;


    private void Start()
    {
        animator = Sprite.GetComponent<Animator>();
        audioSource = Sprite.GetComponent<AudioSource>();
        youDiedSprite = YouDied.GetComponent<SpriteRenderer>();
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            makeContact = true;
            animator.SetTrigger("Death");
            audioSource.Play();
            youDiedSprite.enabled = true;
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
