using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int Lives = 5;
    
    [SerializeField] Text healthText;

    private void Start()
    {
        healthText = GetComponent<Text>();
        healthText.text = Lives.ToString();
    }
    public void DecreaseHealth()
    {
        if(Lives>0)
        {
            Lives--;
            CurrentHealth();
        }
        
    }

    public int CurrentHealth()
    {
        healthText.text = Lives.ToString();
        return Lives;
    }
    

}
