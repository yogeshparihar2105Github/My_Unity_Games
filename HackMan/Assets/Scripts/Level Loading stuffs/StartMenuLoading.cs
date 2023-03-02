using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuLoading : MonoBehaviour
{
    public void LoadLevel_1()
    {
        SoundManager.PlaySound("Click");
        SceneManager.LoadScene(1);
    }

    public void LoadCredits()
    {
        SoundManager.PlaySound("Click");
        SceneManager.LoadScene(6);
    }

    public void QuitGAme()
    {
        SoundManager.PlaySound("Click");
        Application.Quit();
    }
}
