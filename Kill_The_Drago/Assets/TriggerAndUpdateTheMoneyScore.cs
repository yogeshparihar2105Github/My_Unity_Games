using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAndUpdateTheMoneyScore : MonoBehaviour
{
    MoneyCollecter moneyCollecterScript;

    private void Start() {
        moneyCollecterScript = FindObjectOfType<MoneyCollecter>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            moneyCollecterScript.IncreaseScore();
            Destroy(gameObject);
        }
        
    }
}
