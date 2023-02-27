using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSomeTime : MonoBehaviour
{
    public int time;
   
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, time);
    }
}
