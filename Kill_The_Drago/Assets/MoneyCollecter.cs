using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCollecter : MonoBehaviour
{
    GameObject moneyUI;
    [SerializeField] Text moneyText;

    int moneyScore;


    // Start is called before the first frame update
    void Start()
    {
        moneyUI = GameObject.Find("MoneyUI");
        moneyText = moneyUI.GetComponentInChildren<Text>();
    }

    private void Update() {
        moneyText.text = moneyScore.ToString();
    }
    
    public void IncreaseScore()
    {
        moneyScore += 10;
    }
}
