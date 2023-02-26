using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameSession : MonoBehaviour
{
   [Range(0.1f, 10f)] [SerializeField] float gameSpeed;

    [SerializeField] int currentScore = 0;

    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] bool isAutoPlayEnabled;

    public Text scoreText;
    

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<gameSession>().Length;

        if(gameStatusCount>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
