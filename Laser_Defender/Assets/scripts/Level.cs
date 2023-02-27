using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delay = 1f;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Game");
        
    }

    public void LoadGameOver()
    {
        StartCoroutine(GameDelay());
        
    }

    IEnumerator GameDelay()
        {
            
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("Game Over");
        }
        
    public void QuitGame()
    {
        Application.Quit();
    }
}
