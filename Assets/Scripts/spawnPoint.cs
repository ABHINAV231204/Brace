using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    public PlayerCombat pc;
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D col)
   {
    if(col.gameObject.CompareTag("Player"))
    pc.spawnPoint.position = transform.position;
   }
}
