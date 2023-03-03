using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Starting Position")]
    float startingX = -2.625f;
    float startingY = -9f;
    float moveBy = 1.75f;
    int health = 3;
    [Header("Explosion")]
    [SerializeField] GameObject explosionVFXprefab;
    [SerializeField] GameObject explosionPoint;
    [Header("Sounds")]
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;


    private void Start()
    {
        Vector2 startingPosition = new Vector2(startingX, startingY);
        transform.position = startingPosition;
        
    }
    private void Update()
    {
        Move();
        
    }

    //PC movement
    private void Move()
    {
        //move right
       if(transform.position.x < 2.625f)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector2 newPos = new Vector2(transform.position.x + moveBy, transform.position.y);

                transform.position = newPos;
            }
        }

       //move left
        if (transform.position.x > -2.625f)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector2 newPos = new Vector2(transform.position.x - moveBy, transform.position.y);

                transform.position = newPos;
            }
        }

    }

    //Android Movement
    public void MoveLeft()
    {
        if (transform.position.x > -2.625f)
        {
            Vector2 newPos = new Vector2(transform.position.x - moveBy, transform.position.y);

            transform.position = newPos;
        }
            
    }

    public void MoveRight()
    {
        if (transform.position.x < 2.625f)
        {
            Vector2 newPos = new Vector2(transform.position.x + moveBy, transform.position.y);

            transform.position = newPos;
        }

    }


    //for health system
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        health--;
        Explode();
        GetComponent<AudioSource>().PlayOneShot(hitSound);

        if (health <= 0)
        {
            FindObjectOfType<Level>().LoadGameOver();
            Explode();
            GetComponent<AudioSource>().PlayOneShot(deathSound);
            Destroy(gameObject,0.4f);      
        }

    }

    private void Explode()
    {
        Instantiate(explosionVFXprefab, explosionPoint.transform.position, transform.rotation);
    }

    public int GetHealth()
    {
        return health;
    }
}
