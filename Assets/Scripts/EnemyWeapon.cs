using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public int attackDamage = 20;

    public float attackRange = 1f;

    public Vector3 attackOffset;
    public LayerMask playerMask;
    public Transform attackPoint;

    
    void Start()
    {
        
    }

    public void Attack()
    {        
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);

        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("We hit " + player.name);
            GameObject.Find("Jack").GetComponent<PlayerCombat>().TakeDamagePlayer(attackDamage);
        }

        
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
