using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float pushX = 2f;
    [SerializeField] float pushY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.5f;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cached component
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockTheBallToPaddle();
            LaunchOnMouseClick();
        }      
    }

    private void LockTheBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(pushX, pushY);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = TweakingVelocity();

        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }

    }

    private Vector2 TweakingVelocity()
    {
        float x = Random.Range(0f, randomFactor);
        float y = Random.Range(0f, randomFactor);

        Vector2 velocityTweak = new Vector2(x, y);

        return velocityTweak;
    }
}
