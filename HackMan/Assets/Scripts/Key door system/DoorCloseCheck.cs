using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseCheck : MonoBehaviour
{
    public PlayerMovement thePlayer;
    Collider doorCheckCollider;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        doorCheckCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollision2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(thePlayer.followingKey != null)
            {
               doorCheckCollider.isTrigger = true;
            }

        }   
    }
}
