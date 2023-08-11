using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedGate : MonoBehaviour
{

    Rigidbody2D rb;
    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>(); 
    }


    void Update()
    {
        if(Input.GetKeyDown("g"))
        {
            rb.velocity = new Vector2(0f, 1f);
            StartCoroutine(StopGate());
        }
    }
    IEnumerator StopGate()
    {
        yield return new WaitForSeconds(3f);
        rb.velocity = new Vector2(0f, 0f);
    }
}
