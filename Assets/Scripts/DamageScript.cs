using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public GameObject character;
    public int maxHealth = 10;
    public int health;
    public Vector2 hurtVelocity;

    public bool isAlive = true;
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isAlive)
        {
            health -= damage;
            //play hurt animation
            character.GetComponent<Rigidbody2D>().velocity = hurtVelocity;

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {        
        Debug.Log("Enemy Died");

        //play death animation
        character.GetComponent<Animator>().SetTrigger("Dead");
        character.GetComponent<CapsuleCollider2D>().enabled = false;
        character.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezePositionX ;             
                     


        //disable character
        isAlive = false;
    }
}
