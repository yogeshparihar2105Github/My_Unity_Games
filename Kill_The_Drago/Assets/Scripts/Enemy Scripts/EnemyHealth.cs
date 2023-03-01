using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public int health;
    private Animator anim;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

   
    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Hit");
        health -= damage;
        if (health <= 0) { 
            gameObject.tag = "Untagged";
            anim.SetBool("Death", true);
        }
    }
}
