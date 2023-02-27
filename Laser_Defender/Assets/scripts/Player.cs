using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    public float health = 200f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 1f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;

    Coroutine firingCoroutine;

    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.7f;

    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0,1)] float shootSoundVolume = 0.27f;

    float minX;
    float maxX;
    float minY;
    float maxY; 

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
        {
            FindObjectOfType<Level>().LoadGameOver();
            Destroy(gameObject,0.1f);
            GameObject explosion = Instantiate(deathVFX,transform.position,Quaternion.identity);
            Destroy(explosion, durationOfExplosion);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        }
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
           firingCoroutine =  StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }

    }

    IEnumerator FireContinuously()
    {
        while (true)
            {
                GameObject laser;
                laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;

                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);

                Destroy(laser,5f);

                yield return new WaitForSeconds(projectileFiringPeriod);
            }
        
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
        //Move horizontally
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
       
        //Move Vertically
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        //Changing the player position based on the Input we are getting from the above line
        transform.position = new Vector2(newXPos, newYPos);

    }
   
}
