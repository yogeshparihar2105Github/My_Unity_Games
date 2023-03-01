using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void open1()
    {
        SceneManager.LoadScene(1);
    }
    public void open2()
    {
        SceneManager.LoadScene(2);
    }
    public void open3()
    {
        SceneManager.LoadScene(3);
    }
    public void open4()
    {
        SceneManager.LoadScene(4);
    }
     public void open5()
    {
        SceneManager.LoadScene(5);
    }
}
