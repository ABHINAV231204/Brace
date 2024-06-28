using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletspeed : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right*speed*Time.deltaTime;
    }

    void OnTriggerEnter2D (Collider2D hitinfo)
        {
            DamageScript ds=hitinfo.GetComponent<DamageScript>();
            if(ds!=null)
            {
                ds.TakeDamage(200);
            }
           GameObject impactInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        
        float impactEffectDuration = 0.5f; 
        Destroy(impactInstance, impactEffectDuration);


        }
    
}
