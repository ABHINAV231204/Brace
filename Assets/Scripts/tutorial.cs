using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class tutorial : MonoBehaviour
{
    public GameObject cam;
    public TextMeshProUGUI instruction;
     
    // Start is called before the first frame update
    void Start()
    {
        
        instruction.text = " USE 'A' and 'D' to move ";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cam.transform.position);
        if (cam.transform.position.x > -41 && cam.transform.position.x < 7)
        {
            instruction.text = "USE 'A' and 'D' to move";
        }
        if(cam.transform.position.x > 7 && cam.transform.position.x < 50)
        {
            instruction.text = "Use 'T' to Toggle Torch";
            

        }
        else if(cam.transform.position.x > 50) {
            instruction.text = "Use 'Space' to Jump and Double Press for Double Jump";
        }
    }
}
