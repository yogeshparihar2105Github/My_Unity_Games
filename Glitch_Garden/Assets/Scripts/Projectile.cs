using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float damageAmount = 50f;

   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var enemyHealth = otherCollider.GetComponent<EnemyHealth>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if(attacker && enemyHealth)
        {
            enemyHealth.DealDamage(damageAmount);
            Destroy(gameObject);
        }
       
    }
}
