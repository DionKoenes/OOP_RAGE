using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private LayerMask whatIsKillingObstacle;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D colspike)
    {
        if (colspike.gameObject.name.Equals("Spike"))
        {
            anim.SetTrigger("Death");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Lava"))
        {
            anim.SetTrigger("Death");
        }

        if (col.gameObject.name.Equals("Void"))
        {
            anim.SetTrigger("Death");
        }
    }
}
