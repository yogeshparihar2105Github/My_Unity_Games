using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsUI : MonoBehaviour
{


    public void Select(int levelNum)
    {
        SoundManager.PlaySound("Click");
        SceneManager.LoadScene(levelNum + 2);
    }

}
