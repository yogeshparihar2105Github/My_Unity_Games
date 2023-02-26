using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    

    public void DealDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {

            TriggerDeathVFX();
            //Destroying the script and gameObject attached to it
            Destroy(gameObject); 
        }
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX)
        {
            return;
        }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
