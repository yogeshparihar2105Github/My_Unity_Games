using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float DelayInSec = 2f;
    [SerializeField] GameObject losePanel;

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);   
    }

    public void LoadNextlevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<GameSession>().ResetGame();  
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<GameSession>().ResetGame();
    }

    //for activation of the Game Over panel
    public void LoadGameOver()
    {       
        StartCoroutine(LevelLoadDelay());
    }

    IEnumerator LevelLoadDelay()
    {
        
        yield return new WaitForSeconds(DelayInSec);
        Time.timeScale = 0f;
        losePanel.SetActive(true);

    }
    
}

