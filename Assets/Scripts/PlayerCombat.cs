using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerCombat : MonoBehaviour
{
    public Animator playerAnim;
    public Transform attackPoint;

    public LayerMask enemyLayers;
    public HealthBar hb;

    //Enemy range
    public float attackRange = 0.5f;
    public float attackRate = 2f;

    //Attack and Damage points 
    public int attackDamage = 40;
    public int playermaxHealth = 100;
    public int playerHealth;

    public bool isAlive;

    float attackNextTime = 0f;
    int currentLive = 3,totalLives=3;
    public TextMeshProUGUI lifeIndicator;
   
    public Transform spawnPoint;


    private void Start()
    {
        isAlive = GetComponent<PlayerMovement>().IsAlive;
        playerHealth = playermaxHealth;
        hb.setMaxHealth(playermaxHealth);
        hb.setHealth(playermaxHealth);
    }
    void Update()
    {
        //This section manages that the player can attack only 2 times (attack rate) in 1 second
        if (Time.time >= attackNextTime)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Attack();
                attackNextTime = Time.time + 1f / attackRate;
            }
        }
        if(currentLive<totalLives){
            if(isAlive){
            transform.position = spawnPoint.position;
            totalLives=currentLive;
            playerHealth = playermaxHealth;
            hb.setHealth(playerHealth);
            }
            else{
                hb.setHealth(0);
            }
        }
    }

    void Attack()
    {
        //play attack animation
        playerAnim.SetTrigger("Attack");

        //detecting enemies in range
        //Creates an virtual circle at the attack point to detect the layers that come in contact with it 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<DamageScript>().TakeDamage(attackDamage);
        }

        //deal damage to the enemies 
    }
      
    public void TakeDamagePlayer(int damage)
    {
        playerHealth -= damage;
        hb.setHealth(playerHealth);

        if (playerHealth <= 0)

        {
            currentLive--;
            lifeIndicator.text = ""+currentLive;
            if(currentLive == 0){
            playerAnim.SetTrigger("Death");
            isAlive = false;

            playerAnim.GetComponent<CapsuleCollider2D>().enabled = false;
            playerAnim.GetComponent<BoxCollider2D>().enabled = false;

            playerAnim.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;

            StartCoroutine(GameOverPause());

        }
        }
    }

    IEnumerator GameOverPause()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }
   

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void OnTriggerEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("spawnPoint")){
            Debug.Log("spaawn");
        }
    }
}