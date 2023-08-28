using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public Transform Player;
    public GameObject character;

    public int maxHealth = 10;
    public int health;

    public float interactRange = 10f;

    public Vector2 hurtVelocity = new Vector2(10f, 10f);

    public bool isAlive = true;
    public bool isFlipped = false;

    Rigidbody2D rb;

    void Start()
    {
        health = maxHealth;
        rb = character.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {        
        character.GetComponent<Animator>().SetBool("isRunning", Vector2.Distance(Player.position, character.transform.position) <= interactRange);        
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

    public void LookAtPlayer()        
    {
        Vector3 flipped = transform.localScale;
        flipped.z = -1f;

        if (transform.position.x > Player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }

        else if(transform.position.x<Player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
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
