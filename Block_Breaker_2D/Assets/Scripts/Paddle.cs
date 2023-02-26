using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidth = 16;
    [SerializeField] float mousePosInScreenMIN;
    [SerializeField] float mousePosInScreenMAX;

    //cached reference
    gameSession gameSessionScript;
    Ball ballScript;

    private void Start()
    {
        gameSessionScript = FindObjectOfType<gameSession>();
        ballScript = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), mousePosInScreenMIN, mousePosInScreenMAX); 
        transform.position = paddlePos;

    }

    public float GetXPos()
    {
       if(gameSessionScript.IsAutoPlayEnabled())
        {
           return ballScript.transform.position.x;
        }
       else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }

}
