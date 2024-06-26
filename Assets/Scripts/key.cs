using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class key : MonoBehaviour
{
    

    public GameObject keyobj;
    public bool keyisequipped;

    // Start is called before the first frame update
    void Start()

    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            keyisequipped = true;
            keyobj.SetActive(false);
            Destroy(keyobj);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
