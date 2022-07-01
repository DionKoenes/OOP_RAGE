using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            spriteRenderer.enabled = true;                                                                                                                     
        }
    }
}
