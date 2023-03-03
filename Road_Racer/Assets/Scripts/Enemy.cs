using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
       transform.Translate(0, -speed *Time.deltaTime, 0);
    }
}
