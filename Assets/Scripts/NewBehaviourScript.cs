using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float totalMana = 100;
    public bool isShield = false;
    public bool isFire = false;

    public float shieldCost = 100;
    public float fireCost = 100;


    public SpriteRenderer sr;

    public GameObject shield;
    public float shieldHealth = 50;
    public bool shieldEnabled = false;

    public Transform firePoint;
    public GameObject bullet;

    public manaBar mb;
    float currentMana;

    public AudioSource Sfx;
    public AudioClip shieldsound;
    public AudioClip boltsound;



    
    void Start()
        {
            mb.setMaxMana(totalMana);
            mb.setMana(totalMana);
            currentMana = totalMana;
        }
    void Update()
    {
        if(currentMana<totalMana)
        regain();
        
         if(Input.GetKeyDown(KeyCode.E) && currentMana-shieldCost>=0 && isShield)
        InitiateShield();
      
        if(shieldHealth<=0)
                {
                    shieldEnabled=false;
                    shieldHealth = 50;
                    shield.SetActive(false);
                }

        if(Input.GetKeyDown(KeyCode.Q) && currentMana-fireCost>=0 && isFire)
        shoot();

       
    }
    void InitiateShield()
        {
            Sfx.PlayOneShot(shieldsound);
            shield.SetActive(true);
            shieldEnabled=true;
            currentMana-=shieldCost;
            mb.setMana(currentMana);
        }
    void shoot()
        {
            Sfx.PlayOneShot(boltsound);

            currentMana-=fireCost;
            Instantiate(bullet,firePoint.position,firePoint.rotation);
                       mb.setMana(currentMana);



        }
        void regain()
            {
                currentMana+=1.5f*Time.deltaTime;
            mb.setMana(currentMana);

            }
}
