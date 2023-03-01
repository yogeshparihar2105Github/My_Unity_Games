﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public float speed, bound;
    private float coolDown;

    private bool up;

    private Animator anim;
    private Transform playerTransform;
    private PlayerAttack playerAttackScript;

    public GameObject fireBall;
    public Transform fireBallPos;

    private Rigidbody2D rb;
    private bool death;

    void Awake()
    {
        playerAttackScript = FindObjectOfType<PlayerAttack>();
        playerTransform = GameObject.Find("Assassin").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        bound = transform.position.y;
    }

    void Update()
    {
        if (death) return;

        if(Vector2.Distance(playerTransform.position, transform.position) <= 4 && coolDown == 0)
        {
            coolDown = 2.5f;
            anim.SetTrigger("Attack");
        }
        else if((Vector2.Distance(playerTransform.position, transform.position) > 4))
        {
            coolDown = 1.5f;
        }

        Movement();
        CoolDownTimer();
    }

    void Attack() //Attack is calling when dragon is doint animation of attack
    {
        if(playerAttackScript.enabled)
        {
            Instantiate(fireBall, fireBallPos.position, Quaternion.identity);
        }
        
    }

    void Movement()
    {
        if (up)
        {
            Vector3 pos = transform.position;
            pos.y += speed;
            transform.position = pos;
            if (transform.position.y > bound + 0.13f) up = false;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y -= speed;
            transform.position = pos;
            if (transform.position.y < bound - 0.13f) up = true;
        }

        //To change the direction of dragon
        if (transform.position.x < playerTransform.transform.position.x) transform.localScale = new Vector3(1, 1, 1);
        if (transform.position.x > playerTransform.transform.position.x) transform.localScale = new Vector3(-1, 1, 1);

    }

    void CoolDownTimer()
    {
        if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        if(coolDown < 0)
        {
            coolDown = 0;
        }
    }

    void Death()
    {
        rb.isKinematic = false;
        death = true;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ground")
        {
            rb.isKinematic = true;
            GetComponent<Collider2D>().enabled = false;
        }    
    }

}
