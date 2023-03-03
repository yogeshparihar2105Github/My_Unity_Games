using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] Text scoreText;
    GameSession gameSession;
    [SerializeField] AudioClip pointsUpClip;

    [SerializeField] int targetScore = 50;

    [SerializeField] GameObject winPanel;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameSession.GetScore() < targetScore)
        {
            ScoreUpdate();
            PlayAudio();
        }
    }

    public void ScoreUpdate()
    {
        FindObjectOfType<GameSession>().AddToScore(1);
    }

    public void PlayAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(pointsUpClip);
    }


    private void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
        WinPanel();
    }
    private void WinPanel()
    {
        if (gameSession.GetScore() >= targetScore)
        {
            StartCoroutine(ActivateWinPanel());
        }
    }

    IEnumerator ActivateWinPanel()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }
}
