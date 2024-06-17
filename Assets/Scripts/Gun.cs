using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    public Light2D spotlight; // Assign your spotlight component in the inspector
    public float recoilforce = 0.1f;
    public KeyCode interactKeySit;
    public KeyCode interactKeyStand;
    public bool PlayerInGunArea;
    public UnityEvent interactActionSit;
    public UnityEvent interactActionStand;
    public bool characterisongun;
    

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerInGunArea = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        print(PlayerInGunArea);
        if (PlayerInGunArea)
        {

            if (Input.GetKeyDown(interactKeySit))
            {
                interactActionSit.Invoke();
                characterisongun = true;
               
            }

            if (Input.GetKeyDown(interactKeyStand))
            {
                interactActionStand.Invoke();
                characterisongun = false;
            }

            if(characterisongun) {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    // Create a new bullet instance
                    GameObject bulletInstance = Instantiate(bulletPrefab);
                    spotlight.intensity = Random.Range(2f, 6f);
                    transform.Translate(Vector3.right * recoilforce * Time.deltaTime);



                }
            }
            
        }
            
    }
}