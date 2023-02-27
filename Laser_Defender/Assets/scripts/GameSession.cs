using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    Player Playerhealth;


    void Awake()
    {
        SetUpSingleton();
        Playerhealth = FindObjectOfType<Player>();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberGameSessions>1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
   
   public int GetScore()
   {
       return score;
   }

   public float GetHealth()
   {
       
       return Playerhealth.health;
   }

   public void AddToScore(int scoreValue)
   {
       score += scoreValue;
   }

   public void ResetGame()
   {
       Destroy(gameObject);
   }
}
