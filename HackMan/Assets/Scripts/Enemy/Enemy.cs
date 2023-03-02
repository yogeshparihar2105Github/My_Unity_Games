using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float dist;
    public float howClose = 10f;

    [SerializeField] AIPath aiPath;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();     
        player = FindObjectOfType<PlayerMovement>().transform;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(FindObjectOfType<PlayerMovement>())
        {
            dist = Vector2.Distance(player.position, transform.position);
        }
        else
        {
            return;
        }

        if (dist <= howClose)
        {
            aiPath.canSearch = true;
            aiPath.canMove = true;
            myAnimator.SetBool("CanMove", true);
        }
        else
        {
            aiPath.canSearch = false;
            aiPath.canMove = false;
            myAnimator.SetBool("CanMove", false);
        }

    }
}
