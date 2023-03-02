using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int coinScore;
    public Text scoreText;
    [SerializeField] int targetScore = 3;
    [SerializeField] Key key;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = coinScore.ToString();
        key = FindObjectOfType<Key>();
        key.gameObject.SetActive(false);
        
    }

    public void AddCoins(int numberOfCoins)
    {
        coinScore += numberOfCoins;
        scoreText.text = coinScore.ToString();

        if (coinScore == targetScore)
        {
            key.gameObject.SetActive(true);
        }
    }


}
