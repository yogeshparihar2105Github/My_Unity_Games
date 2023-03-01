using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private GameObject[] enemies;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies.Length < 1)
        {  
            Invoke("LvlComplete", 1.3f);
        }
    }

    void LvlComplete()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }
}
