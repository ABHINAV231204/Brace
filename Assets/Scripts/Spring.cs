using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
  public  PlayerMovement pm;
    Animator myAnimator;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)    
    {
       if(other.tag=="Player")
        {
            myAnimator.SetBool("isActivate", true);
        }
        
        StartCoroutine(WaitBeforeActivate());

    }

    IEnumerator WaitBeforeActivate()
    {
        yield return new WaitForSeconds(0.5f);
        myAnimator.SetBool("isActivate", false);
    }
}
