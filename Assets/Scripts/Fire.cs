using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fire : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKeySit;
    public KeyCode interactKeyStand;
    public UnityEvent interactActionSit;
    public UnityEvent interactActionStand;
    public GameObject controlText;
    
    void Update()
    {
        controlText.SetActive(isInRange);
        if(isInRange)
        {            

            if(Input.GetKeyDown(interactKeySit))
            {
                interactActionSit.Invoke();
            }

            if (Input.GetKeyDown(interactKeyStand))
            {
                interactActionStand.Invoke();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            isInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            isInRange= false;
        }
    }
}
