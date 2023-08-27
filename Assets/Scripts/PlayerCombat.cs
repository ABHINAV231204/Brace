using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator playerAnim;
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;

    float attackNextTime = 0f;

    public LayerMask enemyLayers;


    void Update()
    {
        if (Time.time >= attackNextTime)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Attack();
                attackNextTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //play attack animation
        playerAnim.SetTrigger("Attack");

        //detecting enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<DamageScript>().TakeDamage(attackDamage);
        }

        //deal damage to the enemies 
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
