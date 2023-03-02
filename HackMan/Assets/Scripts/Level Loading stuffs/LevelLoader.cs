using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void MainMenu()
    {
        SoundManager.PlaySound("Click");
        SceneManager.LoadScene(0);
    }
    public void NextLevelLoad()
    {
        SoundManager.PlaySound("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Replay()
    {
        SoundManager.PlaySound("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
