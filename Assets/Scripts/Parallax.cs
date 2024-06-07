using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour

{
    private float startingPosition;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x*parallaxEffect;
        transform.position = new Vector3(startingPosition + distance, transform.position.y, transform.position.z);

        
    }
}