using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpawning : MonoBehaviour
{
   [SerializeField] GameObject dragon, spawningParticleVFX;

   SpriteRenderer sr;
   BoxCollider2D bc2d;
    [SerializeField] float dragonSpawingDelay = 0.25f;

    private void Awake() {
    dragon.GetComponent<SpriteRenderer>().enabled = false;
    dragon.GetComponent<Animator>().enabled = false;
    dragon.GetComponent<EnemyDragon>().enabled = false;
   }

   private void Start() {

        sr = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
    
   }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.gameObject.tag == "Player") 
        {
            sr.enabled = false;
            bc2d.enabled = false;
            GameObject particle = Instantiate(spawningParticleVFX, transform.position, Quaternion.identity);
            Invoke("ThingsAfterPlayingParticle",dragonSpawingDelay);
            
        }
   }


void ThingsAfterPlayingParticle()       // calling with invoke
{
     dragon.GetComponent<SpriteRenderer>().enabled = true;
     dragon.GetComponent<Animator>().enabled = true;
     dragon.GetComponent<EnemyDragon>().enabled = true;
    
}

}
