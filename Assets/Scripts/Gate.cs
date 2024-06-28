using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject cam;
    public key script;
    public Sprite gatenewsprite;
    private SpriteRenderer spriterend;
    // Start is called before the first frame update
    void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
    }

   // private void OnTriggerEnter2D(Collider2D collision)
    //{
     //   if (collision.tag == "Player")
       // {
         //   Debug.Log("playerneargate");
           // if (script.keyisequipped)
           // {  if (Input.GetKey(KeyCode.F))
            //    {
             //       spriterend.sprite = gatenewsprite;
               //     Debug.Log("onthegatewithkey");
                //}
          
          //  }
            
       // }
    //}
    // Update is called once per frame
    void FixedUpdate()
    {
        print(script.keyisequipped);
        if (cam.transform.position.x > 30 && cam.transform.position.x < 34)
        {
            if (script.keyisequipped)
            {
                spriterend.sprite = gatenewsprite;

            }
        }
    }
}
