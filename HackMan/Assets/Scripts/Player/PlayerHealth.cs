using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    HealthDisplay healthDisplay;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject LevelCompletePanel;
    Animator myAnimator;

    private void Awake()
    {
        LevelCompletePanel = GameObject.Find("Level Complete Panel");
        GameOverPanel = GameObject.Find("GAme Over Panel");
    }

    private void Start()
    {
        LevelCompletePanel.SetActive(false);
        GameOverPanel.SetActive(false);

        healthDisplay = FindObjectOfType<HealthDisplay>();
        myAnimator = GetComponent<Animator>();
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.gameObject.tag == "Enemy")
            {
                healthDisplay.DecreaseHealth();
                myAnimator.SetTrigger("Hurt");
                SoundManager.PlaySound("Hurt");
                int lives = healthDisplay.CurrentHealth();
                if (lives <= 0)
                {
                    SoundManager.PlaySound("Die");
                    myAnimator.SetTrigger("Dead");
                    StartCoroutine(ActivatingGameOverPanel());

                }
            }
    }

    IEnumerator ActivatingGameOverPanel()
    {
        yield return new WaitForSeconds(1f);
        //set active the Game Over Panel
        GameOverPanel.SetActive(true);
        SoundManager.PlaySound("Game_Over");
        //Deactivate the LevelComplete Panel
        LevelCompletePanel.SetActive(false);

        Destroy(gameObject, 1.5f);
    }



}
