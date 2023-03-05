using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public static float scoreValue = 0f;
    Text score;
    public GameObject panel;
    public float targetScore;
    // Start is called before the first frame update
    void Start()
    {   
        score = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        panelActivation();
        score.text = "SCORE : " + scoreValue;
        
        
    }
    
    
    public void panelActivation()
    {

        if(scoreValue >= targetScore)
                {
                    panel.SetActive(true);
                }
    }
}
