using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    

    Animator myAnimator;

    public Transform attackPos;
    public float attackRange;
    public LayerMask Enemies;
    public int damage = 1;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    public void Attack()
    {
        SoundManager.PlaySound("Attack");
        myAnimator.SetTrigger("Attack");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Enemies);
        for(int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyHealth>().Lives -= damage;
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
