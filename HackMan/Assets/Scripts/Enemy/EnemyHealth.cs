using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator myAnimator;
    public int Lives = 1;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Lives--;
            myAnimator.SetTrigger("Dead");
        }
        
    }

    private void Update()
    {
        if (Lives <= 0)
        {
            Destroy(gameObject,1f);
        }
    }

}
