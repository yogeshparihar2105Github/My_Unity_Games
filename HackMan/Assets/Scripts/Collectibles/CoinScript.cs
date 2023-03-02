using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private CoinCounter coinCounter;
    private int coinValue = 1;

    void Start()
    {
        coinCounter = FindObjectOfType<CoinCounter>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {   
            Destroy(gameObject);
            coinCounter.AddCoins(coinValue);
            SoundManager.PlaySound("Points_Up");

        }
    }
}
