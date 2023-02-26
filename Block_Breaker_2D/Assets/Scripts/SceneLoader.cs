using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //cached reference 
    gameSession GameSessionScript;

    private void Start()
    {
        GameSessionScript = FindObjectOfType<gameSession>();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex =  SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        GameSessionScript.ResetScore();
        SceneManager.LoadScene(0);
    }
}
