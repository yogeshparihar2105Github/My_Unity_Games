using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] Text HealthText;
    GameSession gameSession;


    void Start()
    {
        HealthText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();

    }

    void Update()
    {
        HealthText.text = gameSession.GetHealth().ToString();
    }
}
