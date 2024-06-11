using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Firespawner : MonoBehaviour

{
    public GameObject objectToSpawn;
    public Transform location;
    public GameObject khud;
    public GameObject towerkacollider;
    void Start()
    {
        Collider collider = towerkacollider.GetComponent<BoxCollider>();

        // Check if the collider exists
        if (collider != null)
        {
            Debug.Log("yes");
            // Disable the collider
            collider.enabled = false;
        }

    }


    public void SpawnObject()
    {
        
        Instantiate(objectToSpawn, new Vector3(1.0f, 10.0f, 3.0f), Quaternion.identity);
        
    }
    public void FixedUpdate()
    {   
        transform.position = new Vector3(location.position.x -2,location.position.y,0);
        transform.rotation = location.rotation ;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "firepoint")
        {
            SpawnObject();
            Debug.Log("Hello");
        }
        
        
    }

}

