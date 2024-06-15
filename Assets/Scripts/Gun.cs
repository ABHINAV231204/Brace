using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    public Light2D spotlight; // Assign your spotlight component in the inspector
    public float recoilforce = 0.1f;

    


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Create a new bullet instance
            GameObject bulletInstance = Instantiate(bulletPrefab);
            spotlight.intensity = Random.Range(2f, 6f);
            transform.Translate(Vector3.right * recoilforce * Time.deltaTime);
            


        }
    }
}