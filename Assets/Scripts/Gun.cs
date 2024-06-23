using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;
using Cinemachine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Light2D spotlight;

    public KeyCode interactKeySit;
    public KeyCode interactKeyStand;
    public bool PlayerInGunArea;
    public UnityEvent interactActionSit;
    public UnityEvent interactActionStand;
    public bool characterisongun;

    public CinemachineImpulseSource impulseSource;

    void Start() { }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerInGunArea = true;
        }
    }

    void Update()
    {
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

            if (characterisongun && Input.GetKey(KeyCode.P))
            {
                GameObject bulletInstance = Instantiate(bulletPrefab);
                spotlight.intensity = Random.Range(2f, 6f);

                if (impulseSource != null)
                {
                    Debug.Log("impulse mil gaya bhai");
                    impulseSource.GenerateImpulse();
                }
            }
        }
    }
}
