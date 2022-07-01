using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetect : MonoBehaviour
{   void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        //Destroy(gameObject);
    }
}
