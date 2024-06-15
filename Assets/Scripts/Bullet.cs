using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // Adjust for desired speed

    void Start()
    {
        Rigidbody2D bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = new Vector3(-bulletSpeed, 0f, 0f);
    }

    // Handle collisions or other bullet behavior (optional)
}
